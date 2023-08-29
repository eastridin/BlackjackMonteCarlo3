using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlackjackMonteCarlo2.Game;

namespace BlackjackMonteCarlo2.Common
{
    [Serializable]
    public class PlayerInfo
    {
        #region Events
        public event PropertyChangedEventHandler BalanceChanged;
        #endregion

        #region Fields
        private int balance; //Private field exposed by property
        #endregion

        #region Properties
        public bool IsUser { get; set; }
        public int Balance
        {
            get { return balance; }
            set { balance = value; BalanceChanged?.Invoke(this, new PropertyChangedEventArgs("Balance")); } //Invokes event when balance changes so that external classes can modify their fields accordingly, such as in the GameWindow class.
        }
        #endregion

        #region Constructors
        public PlayerInfo() : this(true)
        {

        }
        public PlayerInfo(bool isUser, int balance = 1000)
        {
            IsUser = isUser;
            Balance = balance;
        }
        #endregion
    }

    [Serializable]
    public abstract class Player
    {
        public PlayerInfo Info { get; set; } //Used to link the players used in game to the ones stored in the gamewindow.
        public List<PlayerHand> PlayerHands { get; private set; }
        public Game.Game game;
        public bool userFinished; //States whether the player has played out all their hands
        public int Bet { set; get; }
        public int Winnings { set; get; }

        public Player() //Solely used for deserializing json save data into an object.
        {
            PlayerHands = new List<PlayerHand>();
        }

        public Player(Game.Game game, int bet, PlayerInfo info)
        {
            this.game = game;
            Bet = bet;
            Info = info;
            PlayerHands = new List<PlayerHand>();
            AddHand(); //Sets up the player for a game of blackjack.
        }

        public Player(Game.Game game, List<Common.PlayerHand> hands, int bet, PlayerInfo info) //Allows player to use pre-set hands.
        {
            this.game = game;
            Bet = bet;
            Info = info;
            PlayerHands = hands;
        }

        public void AddHand()
        {
            PlayerHands.Add(new PlayerHand(game, this, Bet));
            Info.Balance -= Bet; //Each time a hand is added, a bet must take place.
        }

        public void SetHands()
        {
            foreach (var hand in PlayerHands)
            {
                hand.SetHand();
            }
        }

        public abstract void TakeTurn(Game.Game game); //Abstract take turn to be implemented by the derived player types.
    }

    [Serializable]
    public class User : Player
    {
        public delegate void UserTakeTurnHandler(Game.Game game);
        public UserTakeTurnHandler UserTakeTurn;

        public User() //Solely used for deserializing json save data into an object.
        {

        }

        public User(Game.Game game, int bet, PlayerInfo info) : base(game, bet, info)
        {
            
        }

        public User(Game.Game game, List<PlayerHand> hands, int bet, PlayerInfo info) : base(game, hands, bet, info)
        {
            
        }

        public override void TakeTurn(Game.Game game)
        {
            UserTakeTurn?.Invoke(game); //Invokes event so that the GameWindow allows the user to make a turn for this user.
        }
    }

    [Serializable]
    public class AI : Player
    {
        public delegate void TreeSearchCompleteHandler(List<Node> trees, Dictionary<Moves, int> move, AI player);
        public TreeSearchCompleteHandler TreeSearchCompleted;

        #region Constructors

        public AI() //Solely used for deserializing json save data into an object.
        {

        }

        public AI(Game.Game game, int bet, PlayerInfo info) : base(game, bet, info)
        {
            
        }

        public AI(Game.Game game, List<PlayerHand> hands, int bet, PlayerInfo info) : base(game, hands, bet, info)
        {
            
        }
        #endregion

        #region Methods
        public override void TakeTurn(Game.Game game)
        {
            List<Node> trees = new List<Node>();
            int iterations = Properties.Settings.Default.aiIterations; //Loads the user selected amount of AI iterations.
            Dictionary<Game.Moves, int> move = new Dictionary<Game.Moves, int>(); //Sets the results dictionary, which will eventually decide which move will be made.
            move.Add(Game.Moves.Hit, 0);
            move.Add(Game.Moves.Stick, 0);
            move.Add(Game.Moves.Split, 0);
            move.Add(Game.Moves.DoubleDown, 0);

            //Outputs the current state of the game to the console.
            Console.WriteLine("Dealer hand: ");
            foreach (var card in game.CurrentState.DealerHand.Cards)
            {
                Console.Write($"{card.rank}, ");
            }
            Console.Write("\n");
            Console.WriteLine($"Player hands:");
            for (int i = 0; i < game.CurrentState.CurrentPlayer.PlayerHands.Count; i++)
            {
                Console.Write($"Hand {i}: ");
                foreach (var card in PlayerHands[i].Cards)
                {
                    Console.Write($"{card.rank}, ");
                }
                Console.Write("\n");
            }

            //Runs each AI iteration as a task so that it can be run on multiple threads asynchronously for greater performance.
            Task<(Game.Moves, Node)>[] taskList = new Task<(Game.Moves, Node)>[iterations];
            for (int i = 0; i < iterations; i++)
            {
                var task = Task.Run(() => GetBestMove(game));
                taskList[i] = task;
                //task.Wait(); //remove this later, just for debugging mcts
            }
            Task.WaitAll(taskList); //Waits for all the AI iterations to complete.

            foreach (var task in taskList) //Adds the results from each task to the dictionary key values.
            {
                move[task.Result.Item1] += 1;
                trees.Add(task.Result.Item2);
            }
            game.TreeSearchComplete(trees, move, this); //Notifies the game class that a tree search has completed.
            var moveToMake = move.Aggregate((l, r) => l.Value > r.Value ? l : r).Key; //Finds the key with the greatest value
            Console.WriteLine($"Move made: {moveToMake}");
            game.MakeMove(moveToMake); //Makes move with greatest value key.
        }

        public static (Game.Moves, Node) GetBestMove(Game.Game game)
        {
            Node tree = new Node(game.DeepCopy(true, true)); //Remove dealer hidden card so AI can't predict moves, remove all players except the player which will be explored.
            tree.game.CurrentState.deck = tree.game.Shuffle(tree.game.CurrentState.deck); //Reshuffles the deck so that the AI doesn't have an unfair advantage.
            tree.game.CurrentState.DealerHand.AddCard(); //Adds a new hidden card to the dealer.
            MCTS.Run(tree, Properties.Settings.Default.mctsMaxIterations, Properties.Settings.Default.uctConstant);

            return (EvaluateTree(tree), tree);
        }

        public static Game.Moves EvaluateTree(Node tree) //Evaluates which move to make based on the times visited by the MCTS
        {
            Node nodeToMakeMove = null;
            foreach (var child in tree.children)
            {
                if (nodeToMakeMove == null || child.TimesVisited > nodeToMakeMove.TimesVisited)
                {
                    nodeToMakeMove = child;
                }
            }
            return (Game.Moves)nodeToMakeMove.previousMove;
        }
        #endregion
    }
}

   