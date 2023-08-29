using System;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class SettingsMenu : Form
    {
        GameWindow gameWindow;
        //Set the default values to reset to.
        const int aiIterationsDefault = 1600;
        const int mctsMaxIterationsDefault = 200;
        const double uctConstantDefault = 2;
        const int blackjackDecksCountDefault = 3;
        public SettingsMenu()
        {
            InitializeComponent();
            //Remove players tab if there are no players to display.
            tabControl.TabPages.RemoveAt(0);
        }
        public SettingsMenu(GameWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            InitializeComponent();
            SetPlayersTab();
        }

        private void SettingsMenuLoad(object sender, EventArgs e)
        {
            this.Text = "Settings";
            ResetAiSettings();
            ResetBlackjackSettings();
        }

        private void SetPlayersTab()
        {
            for (int i = 0; i < gameWindow.players.Count; i++) //Adds a player setup control for each player in the game.
            {
                playersFlowLayoutPanel.Controls.Add(new PlayerSetupControl(i + 1, gameWindow.players[i].Player));
            }
        }

        private void ResetPlayerSettings() //Sets player settings to what they were.
        {
            for (int i = 0; i < gameWindow.players.Count; i++)
            {
                ((PlayerSetupControl)playersFlowLayoutPanel.Controls[i]).SetPlayerInfo(gameWindow.players[i].Player);
            }
        }

        private void ResetAiSettings() //Sets ai settings to what they were
        {
            aiIterationsUpDown.Value = Properties.Settings.Default.aiIterations;
            mctsMaxIterationsUpDown.Value = Properties.Settings.Default.mctsMaxIterations;
            uctConstantUpDown.Value = (decimal)Properties.Settings.Default.uctConstant;
        }

        private void ResetBlackjackSettings()
        {
            blackjackDecksCount.Value = Properties.Settings.Default.decksCount;
        }

        private void RevertChangesButtonClick(object sender, EventArgs e)
        {
            //Only reset player settings if this settingsmenu instance was opened with players available to be modified
            if (gameWindow != null)
            {
                ResetPlayerSettings();
            }
            ResetAiSettings();
            ResetBlackjackSettings();
        }

        private void SavePlayerSettings()
        {
            for (int i = 0; i < gameWindow.players.Count; i++)
            {
                gameWindow.players[i].Player.Balance = (int)((PlayerSetupControl)playersFlowLayoutPanel.Controls[i]).balanceValue.Value;
                gameWindow.players[i].Player.IsUser = ((PlayerSetupControl)playersFlowLayoutPanel.Controls[i]).playerTypeComboBox.SelectedIndex == 0 ? true : false;
            }
        }

        private void SaveAiSettings()
        {
            //Set AI settings to the user inputs
            Properties.Settings.Default.aiIterations = (int)aiIterationsUpDown.Value;
            Properties.Settings.Default.mctsMaxIterations = (int)mctsMaxIterationsUpDown.Value;
            Properties.Settings.Default.uctConstant = (double)uctConstantUpDown.Value;
        }
        
        private void SaveBlackjackSettings()
        {
            //Set blackjack settings to user inputs
            Properties.Settings.Default.decksCount = (int)blackjackDecksCount.Value;
        }

        private void SaveChangesButtonClick(object sender, EventArgs e)
        {
            //Only save player settings if this settingsmenu instance was opened with players available to be modified
            if (gameWindow != null)
            {
                SavePlayerSettings();
            }
            SaveAiSettings();
            SaveBlackjackSettings();
        }

        private void AISetDefaultsButtonClick(object sender, EventArgs e)
        {
            aiIterationsUpDown.Value = aiIterationsDefault;
            mctsMaxIterationsUpDown.Value = mctsMaxIterationsDefault;
            uctConstantUpDown.Value = (decimal)uctConstantDefault;
        }

        private void BlackjackSetDefaultsButtonClick(object sender, EventArgs e)
        {
            blackjackDecksCount.Value = blackjackDecksCountDefault;
        }

    }
}
