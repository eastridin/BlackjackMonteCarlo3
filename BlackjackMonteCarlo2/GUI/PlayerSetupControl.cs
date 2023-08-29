using System;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class PlayerSetupControl : UserControl
    {
        public PlayerSetupControl(int playerNumber)
        {
            InitializeComponent();
            playerNumberLabel.Text = $"Player number {playerNumber}";
            balanceValue.Value = 1000;
            playerTypeComboBox.SelectedIndex = playerNumber == 1 ? 1 : 0;
        }

        public PlayerSetupControl(int playerNumber, Common.PlayerInfo player)
        {
            InitializeComponent();
            playerNumberLabel.Text = $"Player number {playerNumber}";
            SetPlayerInfo(player);
        }

        public void SetPlayerInfo(Common.PlayerInfo player)
        {
            if (balanceValue.Maximum < player.Balance) //If the current balance is above the current maximum value that can be input, the new maximum is set to the balance.
            {
                balanceValue.Maximum = player.Balance;
            }
            balanceValue.Value = player.Balance;
            playerTypeComboBox.SelectedIndex = player.IsUser ? 0 : 1; //Sets selected user or AI accordingly.
        }

        private void ResetBalanceButtonClick(object sender, EventArgs e)
        {
            balanceValue.Value = 1000;
        }
    }
}
