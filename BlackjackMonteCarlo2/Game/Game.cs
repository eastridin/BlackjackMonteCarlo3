using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BlackjackMonteCarlo2.Game
{
    [Serializable]
    public class Game
    {
        #region Setting fields
        #endregion

        #region Setting properties
        public GameState CurrentState { get; set; }
        #endregion

        #region Setting delegates
        public delegate void GameEventHandler(Game game);
        public delegate void DealerEventHandler(bool cardHidden);
        public delegate void DisplayEventHandler(Game game, bool cardHidden);
        public delegate void CardAddedHandler(Common.Hand hand, Common.Card card);
        public delegate void PlayerCardAddedHandler(Common.Player player, Common.PlayerHand hand, Common.Card card);
        #endregion

        #region Setting events
        [field: NonSerialized()]
        public event DisplayEventHandler DisplayChanged;
        [field: NonSerialized()]
        public event EventHandler PlayerChanged;
        [field: NonSerialized()]
        public event GameEventHandler GameStarted;
        [field: NonSerialized()]
        public event GameEventHandler TurnReady;
        [field: NonSerialized()]
        public event GameEventHandler UserTurnsEnded;
        [field: NonSerialized()]
        public event GameEventHandler GameFinished;
        [field: NonSerialized()]
        public event GameEventHandler GameEvaluated;
        [field: NonSerialized()]
        public event PlayerCardAddedHandler PlayerCardAdded;
        [field: NonSerialized()]
        public event CardAddedHandler DealerCardAdded;
        [field: NonSerialized()]
        public event DealerEventHandler DealerHandChanged;
        [field: NonSerialized()]
        public event GameEventHandler UserSplitCards;
        [field: NonSerialized()]
        public event GameEventHandler RefreshDisplay;
        [field: NonSerialized()]
        public event Common.AI.TreeSearchCompleteHandler TreeSearchCompleted;
        #endregion

        #region Constructors
        public Game(List<(bool, int, Common.PlayerInfo)> players, int numberOfDecks = 3) //Item1 checks if isuser, item2 is bet
        {
            SetGame(players, numberOfDecks);
        }

        public Game(GameSave gameSave, List<Common.PlayerInfo> playerInfos)
        {
            SetGame(gameSave, playerInfos);
        }

        public Game(List<(bool, int, Common.PlayerInfo)> players, GUI.GameWindow gameWindow, int numberOfDecks = 3)
        {
            SetEvents(gameWindow);
            SetGame(players, numberOfDecks);
        }

        public Game(GameSave gameSave, List<Common.PlayerInfo> playerInfos, GUI.GameWindow gameWindow)
        {
            SetEvents(gameWindow);
            SetGame(gameSave, playerInfos);
        }
        #endregion

        #region Methods
        public void TreeSearchComplete(List<Common.Node> nodes, Dictionary<Moves, int> moves, Common.AI player) //Passes complete tree search to GameWindow
        {
            TreeSearchCompleted?.Invoke(nodes, moves, player);
        }

        private void SetEvents(GUI.GameWindow gameWindow) //Set events for GameWindow to update UI
        {
            TurnReady += gameWindow.TurnIsReady;
            PlayerCardAdded += gameWindow.PlayerCardAdded;
            DealerCardAdded += gameWindow.DealerCardAdded;
            UserTurnsEnded += gameWindow.UserTurnsEnded;
            GameFinished += gameWindow.GameIsFinished;
            GameEvaluated += gameWindow.GameIsEvaluated;
            UserSplitCards += gameWindow.CardsSplit;
            RefreshDisplay += gameWindow.RefreshDisplays;
            TreeSearchCompleted += gameWindow.TreeSearchComplete;
        }

        private void SetGame(List<(bool, int, Common.PlayerInfo)> players, int numberOfDecks)
        {
            CurrentState = new GameState();
            CurrentState.deck = SetDeck(numberOfDecks);
            CurrentState.DealerHand = new Common.DealerHand(this);
            CurrentState.DealerHand.SetHand();
            TurnReady += TurnIsReady;
            foreach (var player in players) //create either a user type or ai type
            {
                if (player.Item1)
                {
                    var user = new Common.User(this, player.Item2, player.Item3);
                    CurrentState.Players.Add(user);
                    user.SetHands();
                }
                else
                {
                    var ai = new Common.AI(this, player.Item2, player.Item3);
                    CurrentState.Players.Add(ai);
                    ai.SetHands();
                }
            }
        }

        private void SetGame(GameSave gameSave, List<Common.PlayerInfo> playerInfos)
        {
            CurrentState = new GameState(); 
            CurrentState.deck = gameSave.deck;
            CurrentState.userTurnsEnded = gameSave.userTurnsEnded;
            CurrentState.gameFinished = gameSave.gameFinished;
            CurrentState.gameStarted = gameSave.gameStarted;
            CurrentState.DealerHand = gameSave.DealerHand;
            CurrentState.Players.AddRange(gameSave.Players);

            //Reset the references loaded from the save to reference the current game
            CurrentState.DealerHand.Game = this;
            CurrentState.gameStarted = false;

            for (int i = 0; i < CurrentState.Players.Count; i++) //Set the player object references to reference the current game objects
            {
                var player = CurrentState.Players[i];
                player.game = this;
                player.Info = playerInfos[i];
                foreach (var hand in player.PlayerHands)
                {
                    hand.Parent = player;
                    hand.Game = this;
                }
            }
        }

        public void StartGame()
        {
            RefreshDisplay?.Invoke(this);
            if (!CurrentState.gameStarted && !CurrentState.gameFinished)
            {
                CurrentState.gameStarted = true;
                GameStarted?.Invoke(this); //Invoke game started to notify GameWindow
                if (Is21(CurrentState.DealerHand)) //Finish the game if dealer gets a blackjack
                {
                    CurrentState.userTurnsEnded = true;
                    UserTurnsEnded?.Invoke(this);
                    EvaluateGame();
                }
                else
                {
                    SwitchPlayers(); //Set the player that is to play
                }
            }
            else
            {
                Console.WriteLine("Game cannnot be started");
            }
        }

        private List<Common.Card> SetDeck(int numOfDecks) //Sets the deck with the number of desired decks
        {
            List<Common.Card> cards = new List<Common.Card>();
            for (int i = 0; i < numOfDecks; i++)
            {
                foreach (var suitEnumValue in Enum.GetValues(typeof(Common.Card.Suit)))
                {
                    foreach (var rankEnumValue in Enum.GetValues(typeof(Common.Card.Rank)))
                    {
                        cards.Add(new Common.Card((Common.Card.Suit)suitEnumValue, (Common.Card.Rank)rankEnumValue));
                    }
                }
            }
            return Shuffle(cards); //Shuffle the deck for random cards
        }

        public List<Common.Card> Shuffle(List<Common.Card> cardsToShuffle) //Implements Fisher-Yates shuffle, O(n) time complexity
        {
            int endIndex = cardsToShuffle.Count - 1;
            while (endIndex > 0)
            {
                int randomIndex = Common.RandomNumGen.Next(0, endIndex + 1);
                var temp = cardsToShuffle[endIndex];
                cardsToShuffle[endIndex] = cardsToShuffle[randomIndex];
                cardsToShuffle[randomIndex] = temp;
                endIndex--;
            }
            return cardsToShuffle;
        }

        public Common.Card GetCard() //Returns the last card from the deck and removes that card from the deck.
        {
            var card = CurrentState.deck.Last();
            CurrentState.deck.Remove(card);
            return card;
        }

        private void SwitchPlayers() //Switches the current player to the next player in the list that hasn't finished their turns
        {
            CurrentState.CurrentPlayer = CurrentState.Players.Any(x => !x.userFinished) ? CurrentState.Players.Where(x => !x.userFinished).First() : null;
            if (CurrentState.CurrentPlayer == null)
            {
                Dealer(); //Dealer takes turn since all players have played their turns.
            }
            else
            {
                SwitchHands(); //Switches current hand in play
                PlayerChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SwitchHands()
        {
            CurrentState.HandInPlay = CurrentState.CurrentPlayer.PlayerHands.Any(x => !x.Played) ? CurrentState.CurrentPlayer.PlayerHands.Where(x => !x.Played).First() : null;
            if (CurrentState.HandInPlay == null)
            {
                EndPlayerTurn(); //Ends player turn as there are no hands left to play
            }
            else
            {
                if (Is21(CurrentState.HandInPlay)) //Hand is set to played if it reaches 21.
                {
                    HandInPlayFinished();
                }
                else
                {
                    TurnReady?.Invoke(this);
                }
            }
        }

        private void EndPlayerTurn() //Ends current player then moves to next player
        {
            CurrentState.CurrentPlayer.userFinished = true;
            SwitchPlayers();
        }

        private void HandInPlayFinished() //Ends current hand in play then moves to next hand
        {
            CurrentState.HandInPlay.Played = true;
            SwitchHands();
        }

        public void PlayerCardIsAdded(Common.Player player, Common.PlayerHand hand, Common.Card card)
        {
            PlayerCardAdded?.Invoke(player, hand, card);
        }

        public void DealerCardIsAdded(Common.Hand hand, Common.Card card)
        {
            DealerCardAdded?.Invoke(hand, card);
        }

        public static bool Is21(Common.Hand hand)
        {
            return hand.Values.Any(x => x == 21); //Checks if any of the values are 21 as there can be multiple values
        }

        private static bool IsBlackjack(Common.Hand hand)
        {
            return Is21(hand) && hand.Cards.Count == 2 ? true : false;
        }

        public static bool IsBust(Common.Hand hand)
        {
            return !hand.Values.Any(x => x <= 21);
        }

        private void TurnIsReady(Game game)
        {
            CurrentState.CurrentPlayer.TakeTurn(game); //Makes the current player (be it AI or user) take their turn
        }

        private void Hit() //Adds a card to the current hand in play from the deck
        {
            CurrentState.HandInPlay.userTurns++;
            CurrentState.HandInPlay.AddCard();
            if(IsBust(CurrentState.HandInPlay) || Is21(CurrentState.HandInPlay)) //Checks if hand is finished after hitting
            {
                HandInPlayFinished();
            }
            else
            {
                TurnReady?.Invoke(this);
            }
            DisplayChanged?.Invoke(this, !CurrentState.userTurnsEnded);
        }

        private void Stick() //Ends the current hand in play
        {
            CurrentState.HandInPlay.userTurns++;
            HandInPlayFinished();
            DisplayChanged?.Invoke(this, !CurrentState.userTurnsEnded);
        }

        private void DoubleDown() //Doubles the bet on the current hand in play, adds a card, then finishes the hand in play.
        {
            CurrentState.CurrentPlayer.Info.Balance -= CurrentState.HandInPlay.Bet;
            CurrentState.HandInPlay.Bet += CurrentState.HandInPlay.Bet;
            CurrentState.HandInPlay.AddCard();
            Stick();
        }

        private void Split() //Splits the current hand into two separate hands, with the first card in each being the hand that was split.
        {
            bool splitAces = CurrentState.HandInPlay.Cards.First().rank == Common.Card.Rank.Ace ? true : false;
            CurrentState.HandInPlay.userTurns++;
            UserSplitCards?.Invoke(this);
            SplitCards(CurrentState.CurrentPlayer.PlayerHands.IndexOf(CurrentState.HandInPlay));
            if (splitAces) //If there were split aces, hand is played as you cannot hit on split aces.
            {
                foreach (var hand in CurrentState.CurrentPlayer.PlayerHands)
                {
                    hand.Played = true;
                }
                EndPlayerTurn();
            }
            else
            {
                SwitchHands(); //Sets the new hand in play
            }
            DisplayChanged?.Invoke(this, !CurrentState.userTurnsEnded);
        }

        private void SplitCards(int splitIndex)
        {
            //Create two new hands with each having the first card being the card that was split, add them to the current player
            var hand1 = new Common.PlayerHand(this, CurrentState.CurrentPlayer, CurrentState.CurrentPlayer.Bet, true);
            var hand2 = new Common.PlayerHand(this, CurrentState.CurrentPlayer, CurrentState.CurrentPlayer.Bet, true);
            hand1.SetHand(new List<Common.Card> { CurrentState.CurrentPlayer.PlayerHands[splitIndex].Cards.First() });
            hand2.SetHand(new List<Common.Card> { CurrentState.CurrentPlayer.PlayerHands[splitIndex].Cards.Last() });
            CurrentState.CurrentPlayer.PlayerHands.AddRange(new Common.PlayerHand[] { hand1, hand2 });
            CurrentState.CurrentPlayer.PlayerHands.RemoveAt(splitIndex);
            //Add a card to each new hand.
            hand1.AddCard();
            hand2.AddCard();
        }

        public static bool CheckDoubleDown(Common.PlayerHand hand)
        {
            if (hand != null)
            {
                if (hand.userTurns == 0 && hand.Bet <= hand.Parent.Info.Balance) //Can only double down if the player has enough balance and hasn't made a move on that hand yet
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckSplit(Common.PlayerHand hand)
        {
            if (hand != null)
            {
                if (!hand.SplitChild && hand.Cards.Count == 2 && hand.Cards.First().rank == hand.Cards.Last().rank && hand.Bet <= hand.Parent.Info.Balance) //Checks the cards are the same rank and that the hand isn't already a split child
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Moves> GetAvailableMoves(Common.Player player) //Checks the available moves from the input player.
        {
            List<Moves> moves = new List<Moves>();
            if (!player.userFinished)
            {
                if(Game.Is21(player.game.CurrentState.HandInPlay) == false && Game.IsBust(player.game.CurrentState.HandInPlay) == false)
                {
                    moves.Add(Moves.Hit);
                }
                if (Game.CheckDoubleDown(player.game.CurrentState.HandInPlay))
                {
                    moves.Add(Moves.DoubleDown);
                }
                if (Game.CheckSplit(player.game.CurrentState.HandInPlay))
                {
                    moves.Add(Moves.Split);
                }
                moves.Add(Moves.Stick);
            }
            return moves;
        }

        public void MakeMove(Moves move) //This is what the players will use to make moves in the game.
        {
            switch (move)
            {
                case Moves.Hit:
                    Hit();
                    break;
                case Moves.Stick:
                    Stick();
                    break;
                case Moves.DoubleDown:
                    DoubleDown();
                    break;
                case Moves.Split:
                    Split();
                    break;
            }
        }

        private void Dealer() //Run the dealer logic
        {
            CurrentState.userTurnsEnded = true; //Marks the end of the player turns.
            UserTurnsEnded?.Invoke(this);
            while (!CurrentState.DealerHand.Values.Where(x => x <= 21).Any(x => x > 16) && CurrentState.DealerHand.Values.Any(x => x <= 21)) //Keep adding cards while the minimum value is less than 17.
            {
                CurrentState.DealerHand.AddCard();
            }
            DisplayChanged?.Invoke(this, !CurrentState.userTurnsEnded);
            EvaluateGame();
        }

        private void EvaluateGame()
        {
            CurrentState.gameFinished = true;
            GameFinished?.Invoke(this);
            for (int i = 0; i < CurrentState.Players.Count; i++)
            {
                foreach (var hand in CurrentState.Players[i].PlayerHands)
                {
                    hand.Result = CheckWinner(hand, CurrentState.DealerHand); //Checks each hand if it is a winner or not
                }
                CurrentState.Players[i].Winnings = CalculateWinnings(CurrentState.Players[i].PlayerHands);
                CurrentState.Players[i].userFinished = true;
            }
            GameEvaluated?.Invoke(this);
        }

        private Common.HandResult CheckWinner(Common.PlayerHand userHand, Common.Hand dealerHand)
        {
            if (IsBust(userHand))
            {
                return Common.HandResult.Dealer;
            }
            else if (IsBust(dealerHand))
            {
                return IsBlackjack(userHand) ? Common.HandResult.Blackjack : Common.HandResult.User;
            }

            //Checks the maximum valid value for the user and dealer to check the result
            int userMax = userHand.Values.Where(x => x <= 21).Max();
            int dealerMax = dealerHand.Values.Where(x => x <= 21).Max();
            if(userMax < dealerMax)
            {
                return Common.HandResult.Dealer;
            }
            else if(userMax > dealerMax)
            {
                return IsBlackjack(userHand) ? Common.HandResult.Blackjack : Common.HandResult.User;
            }
            return Common.HandResult.Draw;
        }

        private int CalculateWinnings(List<Common.PlayerHand> hands) //Gets the winnings based upon the bet for the hand
        {
            int result = 0;
            foreach (var hand in hands)
            {
                switch (hand.Result)
                {
                    case Common.HandResult.User:
                        result += hand.Bet + hand.Bet;
                        break;
                    case Common.HandResult.Draw:
                        result += hand.Bet;
                        break;
                    case Common.HandResult.Blackjack:
                        result += hand.Bet + (int)(hand.Bet * 1.5);
                        break;
                }
            }
            return result;
        }

        public Game ShallowCopy()
        {
            return (Game)this.MemberwiseClone();
        }

        public Game DeepCopy2(bool currentPlayerOnly, bool removeHoleCard) //could make this static 
        {
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            var original = this; //doing this so i can make it static easier l8r
            Game copy;
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, original);
                memoryStream.Position = 0;
                copy = (Game)binaryFormatter.Deserialize(memoryStream);
            }
            //Reset the event handlers
            copy.DisplayChanged = null;
            copy.PlayerChanged = null;
            copy.GameStarted = null;
            copy.TurnReady = null;
            copy.UserTurnsEnded = null;
            copy.GameFinished = null;
            copy.GameEvaluated = null;
            copy.PlayerCardAdded = null;
            copy.DealerCardAdded = null;
            copy.DealerHandChanged = null;
            copy.UserSplitCards = null;

            if (removeHoleCard)
            {
                var card = copy.CurrentState.DealerHand.Cards[0];
                copy.CurrentState.DealerHand.Cards.RemoveAt(0);
                copy.CurrentState.deck.Add(card);
            }

            if (currentPlayerOnly)
            {
                var copyCurrentPlayer = copy.CurrentState.Players[original.CurrentState.Players.IndexOf(original.CurrentState.CurrentPlayer)];
                copy.CurrentState.Players.Clear();
                copy.CurrentState.Players.Add(copyCurrentPlayer);
            }
            //sw.Stop();

            //Console.WriteLine($"deep copy {sw.ElapsedMilliseconds}ms");

            return copy;
        }

        public bool IsPrimitive(Type type)
        {
            return type == typeof(decimal) || type == typeof(string) || type.IsPrimitive ? true : false;
        }

        public Game DeepCopy(bool currentPlayerOnly, bool removeHoleCard)
        {
            Game copy = ShallowCopy();
            //Reset the event handlers
            copy.DisplayChanged = null;
            copy.PlayerChanged = null;
            copy.GameStarted = null;
            copy.TurnReady = null;
            copy.UserTurnsEnded = null;
            copy.GameFinished = null;
            copy.GameEvaluated = null;
            copy.PlayerCardAdded = null;
            copy.DealerCardAdded = null;
            copy.DealerHandChanged = null;
            copy.UserSplitCards = null;

            //Creates a new gamestate instance and copies all the data into the new gamestate
            copy.CurrentState = new GameState();
            copy.CurrentState.deck = new List<Common.Card>(CurrentState.deck);
            copy.CurrentState.DealerHand = new Common.DealerHand(copy);
            var dealerCards = new List<Common.Card>();
            dealerCards.AddRange(CurrentState.DealerHand.Cards);

            if (removeHoleCard) //Removes the hidden card from the dealer if it is stated in the method call
            {
                var card = dealerCards[0];
                dealerCards.RemoveAt(0);
                copy.CurrentState.deck.Add(card);
            }

            copy.CurrentState.DealerHand.SetHand(dealerCards);
            copy.CurrentState.gameFinished = CurrentState.gameFinished;
            copy.CurrentState.userTurnsEnded = CurrentState.userTurnsEnded;

            /*void AddPlayerToCopy(Common.Player player) //could make this public and static and use it in GameSave class
            {
                List<Common.PlayerHand> hands = new List<Common.PlayerHand>();
                var newPlayerInfo = new Common.PlayerInfo(player.Info.IsUser, player.Info.Balance);
                dynamic newPlayer = Activator.CreateInstance(player.GetType(), new object[] { copy, hands, player.Bet, newPlayerInfo }); //Uses reflection to create the player, as it could be either a user or an AI type
                foreach (var hand in player.PlayerHands)
                {
                    var cards = new List<Common.Card>();
                    hand.Cards.ForEach(x => cards.Add(x));
                    var newHand = new Common.PlayerHand(copy, newPlayer, hand.Bet);
                    newHand.SetHand(cards);
                    newHand.Played = hand.Played;
                    newHand.userTurns = hand.userTurns;
                    hands.Add(newHand);
                }
                copy.CurrentState.Players.Add(newPlayer);
            }*/

            if (!currentPlayerOnly)
            {
                foreach (var player in CurrentState.Players) //Adds every player to copy
                {
                    AddPlayerToCopy(copy, player);
                }
                copy.CurrentState.CurrentPlayer = copy.CurrentState.Players[CurrentState.Players.IndexOf(CurrentState.CurrentPlayer)];
            }
            else
            {
                AddPlayerToCopy(copy, CurrentState.CurrentPlayer); //Adds only current player to copy
                copy.CurrentState.CurrentPlayer = copy.CurrentState.Players[0];
            }

            if (CurrentState.HandInPlay == null)
            {
                copy.CurrentState.HandInPlay = null;
            }
            else //sets the copy handinplay
            {
                copy.CurrentState.HandInPlay = copy.CurrentState.CurrentPlayer.PlayerHands[this.CurrentState.CurrentPlayer.PlayerHands.IndexOf(this.CurrentState.HandInPlay)]; //index out of range when multiple userhands
            }

            return copy;
        }

        public static void AddPlayerToCopy(Game copy, Common.Player player)
        {
            List<Common.PlayerHand> hands = new List<Common.PlayerHand>();
            var newPlayerInfo = new Common.PlayerInfo(player.Info.IsUser, player.Info.Balance);
            dynamic newPlayer = Activator.CreateInstance(player.GetType(), new object[] { copy, hands, player.Bet, newPlayerInfo }); //Uses reflection to create the player, as it could be either a user or an AI type
            foreach (var hand in player.PlayerHands) //Creates a new instance of each hand and adds it to the player copy
            {
                var cards = new List<Common.Card>();
                hand.Cards.ForEach(x => cards.Add(x));
                var newHand = new Common.PlayerHand(copy, newPlayer, hand.Bet);
                newHand.SetHand(cards);
                newHand.Played = hand.Played;
                newHand.userTurns = hand.userTurns;
                hands.Add(newHand);
            }
            copy.CurrentState.Players.Add(newPlayer);
        }
        #endregion
    }

    public enum Moves
    {
        Hit,
        Stick,
        DoubleDown,
        Split
    }
}
