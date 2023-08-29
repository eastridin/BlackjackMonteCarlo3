using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class GameWindow : Form
    {
        public const int defaultBalance = 1000;
        private Bitmap backgroundImage;
        private DealerDisplay dealer;
        public List<PlayerDisplay> players = new List<PlayerDisplay>();
        private PlayerDisplay currentPlayer;
        private int currentPlayerIndex;
        private NumericUpDown betAmount = new NumericUpDown();
        private List<PlayerDisplay> playersInPlay = new List<PlayerDisplay>();
        private Game.Game game;
        private List<PlayerTreeDisplayData> trees;
        private List<PlayerTreeDisplayData> Trees { get { return trees; } set
            {
                trees = value;
                viewTreesToolStripMenuItem.Visible = trees.Count > 0 ? true : false;
            } }

        //Setting delegates and events
        delegate void SetupStartedHandler();
        private event SetupStartedHandler SetupStarted;
        delegate void GameStartedHandler();
        private event GameStartedHandler GameStarted;

        private GameWindow()
        {
            InitializeComponent();
            this.Text = "Blackjack";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            backgroundImage = new Bitmap(GUI.UI.table); //Set background image to table
            playersPanel.BackColor = Color.Transparent;
            betAmount.Value = 100;
            dealerPanel.BackColor = Color.Transparent;
            Trees = new List<PlayerTreeDisplayData>();

            //Set displays for each portion
            SetDealer();
            SetSetupPanel();
            SetDealerPanel();
            SetGamePanel();

            SetupStarted += OnSetupStart;
            GameStarted += OnGameStart;

            this.Disposed += (sender, e) => GC.Collect(); //Call garbage collector when this form is closed and disposed.
        }

        public GameWindow(Game.GameSave gameSave) : this()
        {
            var playersData = gameSave.Players.Select(x => $"{(x.Info.IsUser ? "user" : "ai")},{x.Info.Balance},{x.Bet}").ToList(); //Set the players according to the input gamesave
            SetPlayers(playersData);
        }
        public GameWindow(List<string> playersData) : this()
        {
            SetPlayers(playersData); //Set the players according to the input players data
            SetupStart(); //Start setup for each player
        }

        #region Methods
        private void SetupStart()
        {
            SetupStarted?.Invoke(); //Invoke setup started event to modify the display accordingly.
            //Reset references to any potential previous game
            playersInPlay.Clear(); 
            Trees.Clear();
            viewTreesToolStripMenuItem.Visible = false;
            currentPlayerIndex = 0;
            foreach (var player in players)
            {
                player.Circle.BackColor = Color.Transparent;
            }
            SetPlayersInfoPanel(PlayersInfoPanel.Balance);
            SetCurrentPlayer(); //Sets the first play to setup.
        }

        private void OnSetupStart() //Changes panels shown from game panels to setup panels.
        {
            gamePanel.Enabled = gamePanel.Visible = dealerPanel.Enabled = dealerPanel.Visible = false;
            setupPanel.Enabled = setupPanel.Visible = true;
        }

        private void SetCurrentPlayer() //Gets the next player from the players list that has not been setup/betted on yet.
        {
            if(currentPlayer != null)
            {
                currentPlayer.Circle.BackColor = Color.Transparent;

            }
            currentPlayer = currentPlayerIndex < players.Count ? players[currentPlayerIndex++] : null; //Sets the current player only if the index doesn't surpass the length of the players list.
            Console.Clear();
            if(currentPlayer != null)
            {
                currentPlayer.Circle.BackColor = Color.Aqua;
                Console.WriteLine($"User balance: {currentPlayer.Player.Balance}");
                betAmount.Maximum = currentPlayer.Player.Balance;
            }
            else
            {
                GameStart(); //If there are no more players left to setup, begin the game.
            }
        }

        private void SetPlayers(List<string> playersData) //Sets the player objects using the given input.
        {
            for (int i = 0; i < playersData.Count; i++)
            {
                int yValue = (i * i) + (-5 * i);
                string[] playersDatum = playersData[i].Split(','); //Split the string into an array to get each input value (player type, balance, bet)
                Common.PlayerInfo player = new Common.PlayerInfo(playersDatum[0] == "user", Convert.ToInt32(playersDatum[1]));
                players.Add(new PlayerDisplay(player, (i * 35) + (i * 88), -10 * yValue, Convert.ToInt32(playersDatum[2])));
                playersPanel.Controls.Add(players[i].DisplayPanel);
                players[i].DisplayPanel.BringToFront();
            }
        }

        private void SetDealer()
        {
            dealer = new DealerDisplay(0, 0);
        }

        #region Set Panels
        private void SetSetupPanel() //Initializes the setup panel.
        {
            Button betButton = new Button()
            {
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(238, 57, 57),
                Location = new Point(0, 0),
                Text = "Bet",
                Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White
            };
            betButton.FlatAppearance.BorderColor = Color.Black;
            betButton.Click += BetButtonClicked; //Run this method when the bet button is clicked
            setupPanel.Controls.Add(betButton);

            betAmount.Location = new Point(200, 0);
            betAmount.ValueChanged += BetAmountChanged;
            betAmount.Increment = 50;
            setupPanel.Controls.Add(betAmount);
            setupPanel.BackColor = Color.Transparent;

            Button skip = new Button()
            {
                Location = new Point(300, 0)
            };
            skip.Click += SkipClick;
        }

        private void SetGamePanel() //Initializes the game panel, sets each button.
        {
            this.SuspendLayout();

            Button hitButton = new Button()
            {
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(238, 57, 57),
                Location = new Point(0, 0),
                Text = "Hit",
                Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Tag = 0
            };
            hitButton.FlatAppearance.BorderColor = Color.Black;
            hitButton.Click += MoveButtonClick;

            Button stickButton = new Button()
            {
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(238, 57, 57),
                Location = new Point(175, 0),
                Text = "Stick",
                Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Tag = 1
            };
            stickButton.FlatAppearance.BorderColor = Color.Black;
            stickButton.Click += MoveButtonClick;

            Button doubleDownButton = new Button()
            {
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(238, 57, 57),
                Location = new Point(350, 0),
                Text = "Double Down",
                Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Tag = 2
            };
            doubleDownButton.FlatAppearance.BorderColor = Color.Black;
            doubleDownButton.Click += MoveButtonClick;

            Button splitButton = new Button()
            {
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(238, 57, 57),
                Location = new Point(525, 0),
                Text = "Split",
                Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Tag = 3
            };
            splitButton.FlatAppearance.BorderColor = Color.Black;
            splitButton.Click += MoveButtonClick;

            gamePanel.Controls.AddRange(new Control[] { hitButton, stickButton, doubleDownButton, splitButton });
            gamePanel.BackColor = Color.Transparent;

            this.ResumeLayout();
        }
        #endregion

        private void ResetDisplays() //Resets the display in each player and the dealer.
        {
            foreach (var player in players)
            {
                player.ResetDisplay();
            }
            dealer.ResetDisplay();
        }

        public void RefreshDisplays(Game.Game game)
        {
            //Remove any current hands in the players and dealers
            foreach (var player in players)
            {
                foreach (var hand in player.Hands)
                {
                    player.DisplayPanel.Controls.Remove(hand);
                }
                player.Hands.Clear();
            }
            foreach (var hand in dealer.Hands)
            {
                dealer.DisplayPanel.Controls.Remove(hand);
            }
            dealer.Hands.Clear();

            //Readd the current hands to the players and dealers
            foreach (var player in game.CurrentState.Players)
            {
                var playerDisplay = GetPlayer(player);
                foreach (var hand in player.PlayerHands)
                {
                    playerDisplay.AddHand(hand);
                }
            }
            SetPlayersInfoPanel(PlayersInfoPanel.Balance);
            dealer.AddHand(game.CurrentState.DealerHand);
        }

        private void SetPlayersInfoPanel(PlayersInfoPanel type)
        {
            foreach (var player in players)
            {
                if (!playersPanel.Contains(player.BalanceLabel)) //Add balance label if it isnt already shown
                {
                    playersPanel.Controls.Add(player.BalanceLabel);
                    player.BalanceLabel.BringToFront();
                }
            }
            switch (type) //Sets all the info for each player
            {
                case PlayersInfoPanel.Balance:
                    foreach (var player in players)
                    {
                        player.BalanceLabel.Text = $"Balance: {player.Player.Balance}";
                    }
                    break;
                case PlayersInfoPanel.Values:
                    break;
                case PlayersInfoPanel.Winnings:
                    break;
            }
        }



        private void SkipClick(object sender, EventArgs e) //Used to skip the betting process during the setup, only used during development and is not shown in the final product.
        {
            for (int i = currentPlayerIndex; i <= players.Count; i++)
            {
                BetButtonClicked(sender, e);
            }
        }

        private void BetAmountChanged(object sender, EventArgs e)
        {
            SetBetButton(); //Sets bet button to either say skip or bet
        }

        private void SetBetButton()
        {
            setupPanel.Controls[0].Text = betAmount.Value <= 0 ? "Skip" : "Bet"; //If bet is 0, button now says skip. Else, it says bet.
        }

        private void BetButtonClicked(object sender, EventArgs e)
        {
            currentPlayer.Bet = (int)betAmount.Value;
            if(currentPlayer.Bet > 0) //Only add the current player to the game if their bet is greater than 0
            {
                playersInPlay.Add(currentPlayer);
            }
            SetCurrentPlayer();
        }
        
        private void SetDealerPanel() //Initialises the dealer's panel
        {
            dealerPanel.Controls.Add(dealer.DisplayPanel);
            dealer.DisplayPanel.BringToFront();
        }

        private void MoveButtonClick(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => game.MakeMove((Game.Moves)((Button)sender).Tag))); //Finds the move that was made by checking the tag of sender, then makes that move.
        }

        public void GameStart() //Starts the game with the selected inputs.
        {
            List<(bool, int, Common.PlayerInfo)> playerList = playersInPlay.Select(x => (x.Player.IsUser, x.Bet, x.Player)).ToList();
            game = new Game.Game(playerList, this, Properties.Settings.Default.decksCount);
            GameStarted?.Invoke(); //Invoke gamestarted to modify UI accordingly 
            BeginInvoke(new Action(() => game.StartGame()));
        }

        public void GameStart(Game.GameSave gameSave)
        {
            game = new Game.Game(gameSave, players.Select(x => x.Player).ToList(), this);
            foreach (var player in game.CurrentState.Players)
            {
                playersInPlay.Add(players.Find(x => x.Player == player.Info)); //Sets the playersInPlay to the players that were loadded in.
            }
            GameStarted?.Invoke();//Invoke gamestarted to modify UI accordingly 
            BeginInvoke(new Action(() => game.StartGame()));
        }

        public void OnGameStart() //Hides setup panel, shows game input panel.
        {
            this.SuspendLayout();
            gamePanel.Enabled = gamePanel.Visible = dealerPanel.Enabled = dealerPanel.Visible = true;
            setupPanel.Enabled = setupPanel.Visible = false;
            this.ResumeLayout();
        }

        internal void TurnIsReady(Game.Game game) //Sets the possible moves for the user to make in the game panel, highlights which user's turn it is. Outputs values to console.
        {
            SetAvailableMoves(game);
            if (game.CurrentState.CurrentPlayer != null)
            {
                foreach (var player in playersInPlay)
                {
                    player.Circle.BackColor = Color.Transparent;
                }
                playersInPlay[game.CurrentState.Players.IndexOf(game.CurrentState.CurrentPlayer)].Circle.BackColor = Color.Aqua;
                if (game.CurrentState.HandInPlay != null)
                {
                    Console.Clear();
                    foreach (var card in game.CurrentState.HandInPlay.Cards)
                    {
                        Console.WriteLine($"value: {card.value.Last()}");
                    }
                    Console.WriteLine($"total value(s): {String.Join(", ", game.CurrentState.HandInPlay.Values)}");
                }
            }
        }

        internal void PlayerCardAdded(Common.Player player, Common.PlayerHand hand, Common.Card card) //Adds the card which was added to the player to the relevant player's display.
        {
            GetPlayer(player).AddCard(card, player.PlayerHands.IndexOf(hand));
        }

        internal void DealerCardAdded(Common.Hand hand, Common.Card card) //Adds the card which was added to the dealer to the dealer's display.
        {
            dealer.AddCard(card, 0);
            Console.Clear();
            foreach (var dealerCard in hand.Cards)
            {
                Console.WriteLine($"value: {String.Join(", ", dealerCard.value)}");
            }
            Console.WriteLine($"total value(s): {String.Join(", ", hand.Values)}");
        }

        internal void GameIsFinished(Game.Game sender)
        {
            //Place holder event handler just in case it is needed in potential further development
        }

        internal void GameIsEvaluated(Game.Game sender) //Modify the player's balances accordingly depending on game results, display colours to signify which players won and lost. (Green = win, yellow = draw, red = loss)
        {
            EvaluatePlayerWinnings(sender.CurrentState.Players);
            for (int i = 0; i < playersInPlay.Count; i++)
            {
                switch (sender.CurrentState.Players[i].PlayerHands[0].Result)
                {
                    case Common.HandResult.User:
                    case Common.HandResult.Blackjack:
                        playersInPlay[i].Circle.BackColor = Color.LightGreen;
                        break;
                    case Common.HandResult.Draw:
                        playersInPlay[i].Circle.BackColor = Color.Yellow;
                        break;
                    case Common.HandResult.Dealer:
                        playersInPlay[i].Circle.BackColor = Color.Red;
                        break;
                    default:
                        playersInPlay[i].Circle.BackColor = Color.Transparent;
                        break;
                }
            }
            MessageBox.Show("Done");
            ResetDisplays();
            SetupStart(); //Begins the setup once the user has acknowledged the results.
            GC.Collect();
        }

        internal void UserTurnsEnded(Game.Game sender) //Removes options to make moves, shows the dealers hidden card.
        {
            SetAvailableMoveButtons(false, false, false, false);
            dealer.ShowHiddenCard(sender);
        }

        internal void CardsSplit(Game.Game game) //Splits the hand in the display of the relevant player
        {
            GetPlayer(game.CurrentState.CurrentPlayer).SplitCards();
        }

        public void TreeSearchComplete(List<Common.Node> nodes, Dictionary<Game.Moves, int> moves, Common.AI player) //Adds a tree to the trees list once a tree search is completed.
        {
            if (Trees.Select(x => x.player).Contains(player) == false)
            {
                Trees.Add(new PlayerTreeDisplayData(player));
                viewTreesToolStripMenuItem.Visible = Trees.Count > 0 ? true : false;
            }
            Trees.Find(x => x.player == player).moves.Add((nodes, moves));
        }

        private PlayerDisplay GetPlayer(Common.Player player) //Gets player display of input player.
        {
            return playersInPlay[player.game.CurrentState.Players.IndexOf(player)];
        }

        private void SetAvailableMoves(Game.Game game) //Sets the currently available moves in at a given game state.
        {
            bool canHit = false, canStick = false, canDoubleDown = false, canSplit = false;

            if (game.CurrentState.CurrentPlayer != null && game.CurrentState.CurrentPlayer.GetType() == typeof(Common.User))
            {
                var moves = Game.Game.GetAvailableMoves(game.CurrentState.CurrentPlayer);
                canHit = moves.Contains(Game.Moves.Hit) ? true : false;
                canStick = moves.Contains(Game.Moves.Stick) ? true : false;
                canDoubleDown = moves.Contains(Game.Moves.DoubleDown) ? true : false;
                canSplit = moves.Contains(Game.Moves.Split) ? true : false;
            }

            SetAvailableMoveButtons(canHit, canStick, canDoubleDown, canSplit);
        }

        private void SetAvailableMoveButtons(bool canHit, bool canStick, bool canDoubleDown, bool canSplit) //Sets the buttons to the relevant inputs.
        {
            bool[] moves = new bool[] { canHit, canStick, canDoubleDown, canSplit };
            for (int i = 0; i < 4; i++)
            {
                gamePanel.Controls[i].Enabled = gamePanel.Controls[i].Visible = moves[i];
            }
        }

        private void EvaluatePlayerWinnings(List<Common.Player> players) //Modifies the balances of each player depending on their winnings.
        {
            for (int i = 0; i < players.Count; i++)
            {
                playersInPlay[i].Player.Balance += players[i].Winnings;
            }
        }

        private void PaintBackground(object sender, PaintEventArgs e) //Whenever the window is repainted, the background is drawn first.
        {
            Graphics g = e.Graphics;
            Rectangle windowArea = ClientRectangle;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.DrawImage(backgroundImage, windowArea);
        }

        private void WindowResized(object sender, EventArgs e) //Repaints the form whenever it is resized.
        {
            this.Refresh();
        }

        private void SettingsToolStripMenuItemClick(object sender, EventArgs e) //Display settings in a dialog so that program cannot be interacted with until settings has been closed.
        {
            SettingsMenu menu = new SettingsMenu(this);
            menu.ShowDialog();
        }

        private void HelpToolStripMenuItemClick(object sender, EventArgs e) //Display help menu
        {
            HelpWindow menu = new HelpWindow();
            menu.Show();
        }

        private void SaveGameToolStripMenuItemClick(object sender, EventArgs e) //Saves the game
        {
            //Checks if there is a valid game to be saved
            if(game != null && game.CurrentState.gameFinished == false)
            {
                if(SaveGame(game) == DialogResult.OK)
                {
                    MessageBox.Show("Game has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There is no game currently being played", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DialogResult SaveGame(Game.Game game)
        {
            var gameJson = JsonConvert.SerializeObject(new Game.GameSave(game.CurrentState), new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented, //This makes the json much more readable.
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All //This is required so that inherited classes that are stored in the json can be deserialized properly when the save is loaded.
            });
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "Save game",
                Filter = "Json Files (*.json)|*.json",
                InitialDirectory = $"{Directory.GetCurrentDirectory()}"
            };
            var dialogResult = saveDialog.ShowDialog();
            if(dialogResult == DialogResult.OK) //Only saves if the dialog is exited with an OK result.
            {
                File.WriteAllText($"{saveDialog.FileName}", gameJson);
            }
            return dialogResult;
        }
        #endregion

        private void HintToolStripMenuItemClick(object sender, EventArgs e)
        {
            //Checks if there is a current game in play to give a hint for.
            if (game != null && game.CurrentState.gameFinished == false)
            {
                //Runs the AI to find the best move.
                var iterations = Properties.Settings.Default.aiIterations;
                Dictionary<Game.Moves?, int> move = new Dictionary<Game.Moves?, int>();
                move.Add(Game.Moves.Hit, 0);
                move.Add(Game.Moves.Stick, 0);
                move.Add(Game.Moves.Split, 0);
                move.Add(Game.Moves.DoubleDown, 0);


                Task<(Game.Moves, Common.Node)>[] taskList = new Task<(Game.Moves, Common.Node)>[iterations];
                for (int i = 0; i < iterations; i++)
                {
                    var task = Task.Run(() => Common.AI.GetBestMove(game));
                    taskList[i] = task;
                }
                Task.WaitAll(taskList);
                foreach (var task in taskList)
                {
                    move[task.Result.Item1] += 1;
                }
                MessageBox.Show($"The suggested move by the AI is to: {move.Aggregate((l, r) => l.Value > r.Value ? l : r).Key}", "Suggested move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is no game in play", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewTreesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var treeVisualiser = new TreeVisualiser(trees, game); //Display the trees that have been stored
            treeVisualiser.Disposed += (sender2, e2) => GC.Collect();
            treeVisualiser.ShowDialog();
        }
    }

    #region Class definitions
    public class PlayerTreeDisplayData //Contains relevant date for each tree
    {
        public Common.Player player;
        public List<(List<Common.Node>, Dictionary<Game.Moves, int>)> moves;
        public PlayerTreeDisplayData(Common.Player player)
        {
            this.player = player;
            moves = new List<(List<Common.Node>, Dictionary<Game.Moves, int>)>();
        }
    }

    enum PlayersInfoPanel
    {
        Balance,
        Winnings,
        Values
    }
    #endregion
}
