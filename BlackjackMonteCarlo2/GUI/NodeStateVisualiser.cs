using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class NodeStateVisualiser : Form
    {
        private Common.Node node;
        public NodeStateVisualiser(Common.Node node)
        {
            this.node = node;
            InitializeComponent();
        }

        private void NodeStateVisualiser_Load(object sender, EventArgs e)
        {
            this.Text = "Node State Visualiser";

            DisplayCards dealerDisplay = new DisplayCards(dealerLabel.Location.X, dealerLabel.Location.Y + 25, new List<Common.DealerHand>() { node.game.CurrentState.DealerHand });

            playerLabel.Location = new Point(dealerLabel.Location.X + dealerDisplay.DisplayPanel.Width + 15, dealerLabel.Location.Y);
            DisplayCards playerDisplay = new DisplayCards(playerLabel.Location.X, playerLabel.Location.Y + 25, node.game.CurrentState.Players[0].PlayerHands);

            //Set node data
            visitsNumberLabel.Text = node.TimesVisited.ToString();
            valueNumberLabel.Text = node.Value.ToString();
            previousMoveValueLabel.Text = node.previousMove == null ? "None" : node.previousMove.ToString();
            deckCountLabel.Text = node.game.CurrentState.deck.Count.ToString();

            Controls.Add(playerDisplay.DisplayPanel);
            Controls.Add(dealerDisplay.DisplayPanel);

            this.FormClosed += (o, eA) => GC.Collect();
        }
    }
}
