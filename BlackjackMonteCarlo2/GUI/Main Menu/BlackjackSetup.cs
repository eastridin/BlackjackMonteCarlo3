using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI.Main_Menu
{
    public partial class BlackjackSetup : Form
    {
        List<PlayerSetupControl> players = new List<PlayerSetupControl>();
        public BlackjackSetup()
        {
            InitializeComponent();
            this.Text = "Blackjack";
            this.BackColor = Color.Green;
        }

        private void BlackjackSetupLoad(object sender, EventArgs e)
        {
            for (int i = 1; i < playerCountUpDown.Value + 1; i++) //Initializes the player setup controls when the form is opened
            {
                var newPlayer = new PlayerSetupControl(i);
                players.Add(newPlayer);
                playersFlowLayoutPanel.Controls.Add(newPlayer);
            }
        }

        private void PlayerCountUpDownValueChanged(object sender, EventArgs e) //Removes or adds a player when the value is changed, depending on if the value went up or down
        {
            if(playerCountUpDown.Value > players.Count)
            {
                var newPlayer = new PlayerSetupControl((int)playerCountUpDown.Value);
                players.Add(newPlayer);
                playersFlowLayoutPanel.Controls.Add(newPlayer);
            }
            else if(playerCountUpDown.Value < players.Count)
            {
                var playerToRemove = players.Last();
                playersFlowLayoutPanel.Controls.Remove(playerToRemove);
                players.Remove(playerToRemove);
            }
        }

        private void BlackjackNewGameButtonClick(object sender, EventArgs e)
        {
            SuspendLayout();
            var playerData = new List<string>();
            foreach (var player in players)
            {
                var playerType = player.playerTypeComboBox.SelectedIndex == 0 ? "user" : "ai"; //Creates a new player with the chosen player type
                playerData.Add($"{playerType},{player.balanceValue.Value},0");
            }
            GameWindow game = new GameWindow(playerData);
            game.Show(); //Shows the game window
            ResumeLayout();
        }
    }
}
