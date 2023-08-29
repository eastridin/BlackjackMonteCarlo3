using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI.Main_Menu
{
    public partial class SimulateWindow : Form
    {
        public SimulateWindow()
        {
            InitializeComponent();
            this.Text = "Simulate Blackjack";
        }

        private void SimulateGameButtonClick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            int balance = (int)startingBalance.Value;

            for (int i = 0; i < (int)numberOfSimulations.Value; i++)
            {
                simulationStatusValue.Text = $"{i + 1} / {(int)numberOfSimulations.Value}"; //Displays the current status of the simulations
                balance = SimulateGame(i + 1, balance); //Runs another simulation and sets balance after it has taken place
                endingBalanceValueLabel.Text = balance.ToString();
                GC.Collect(); //Call garbage collector after a simulation completes to reduce memory usage
            }
            endingBalanceValueLabel.Text = balance.ToString();
        }

        private int SimulateGame(int iterationNum, int balance)
        {
            var game = new Game.Game(new List<(bool, int, Common.PlayerInfo)>()
                {
                    (false, (int)betAmount.Value, new Common.PlayerInfo(false, balance))
                }, Properties.Settings.Default.decksCount);
            game.StartGame(); //Creates a new game with an AI and plays it through.
            Console.WriteLine($"Simulation {iterationNum} complete");
            return game.CurrentState.Players[0].Info.Balance + game.CurrentState.Players[0].Winnings; //Returns the new balance after the game has been played through.
        }
    }
}
