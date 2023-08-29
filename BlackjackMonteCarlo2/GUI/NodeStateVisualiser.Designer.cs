
namespace BlackjackMonteCarlo2.GUI
{
    partial class NodeStateVisualiser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visitsLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.dealerLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.previousMoveLabel = new System.Windows.Forms.Label();
            this.visitsNumberLabel = new System.Windows.Forms.Label();
            this.valueNumberLabel = new System.Windows.Forms.Label();
            this.previousMoveValueLabel = new System.Windows.Forms.Label();
            this.deckLabel = new System.Windows.Forms.Label();
            this.deckCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // visitsLabel
            // 
            this.visitsLabel.AutoSize = true;
            this.visitsLabel.Location = new System.Drawing.Point(15, 9);
            this.visitsLabel.Name = "visitsLabel";
            this.visitsLabel.Size = new System.Drawing.Size(34, 13);
            this.visitsLabel.TabIndex = 0;
            this.visitsLabel.Text = "Visits:";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(15, 36);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(37, 13);
            this.valueLabel.TabIndex = 1;
            this.valueLabel.Text = "Value:";
            // 
            // dealerLabel
            // 
            this.dealerLabel.AutoSize = true;
            this.dealerLabel.Location = new System.Drawing.Point(17, 116);
            this.dealerLabel.Name = "dealerLabel";
            this.dealerLabel.Size = new System.Drawing.Size(41, 13);
            this.dealerLabel.TabIndex = 2;
            this.dealerLabel.Text = "Dealer:";
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(76, 116);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(39, 13);
            this.playerLabel.TabIndex = 3;
            this.playerLabel.Text = "Player:";
            // 
            // previousMoveLabel
            // 
            this.previousMoveLabel.AutoSize = true;
            this.previousMoveLabel.Location = new System.Drawing.Point(15, 62);
            this.previousMoveLabel.Name = "previousMoveLabel";
            this.previousMoveLabel.Size = new System.Drawing.Size(81, 13);
            this.previousMoveLabel.TabIndex = 4;
            this.previousMoveLabel.Text = "Previous Move:";
            // 
            // visitsNumberLabel
            // 
            this.visitsNumberLabel.AutoSize = true;
            this.visitsNumberLabel.Location = new System.Drawing.Point(120, 9);
            this.visitsNumberLabel.Name = "visitsNumberLabel";
            this.visitsNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.visitsNumberLabel.TabIndex = 5;
            this.visitsNumberLabel.Text = "label1";
            // 
            // valueNumberLabel
            // 
            this.valueNumberLabel.AutoSize = true;
            this.valueNumberLabel.Location = new System.Drawing.Point(120, 36);
            this.valueNumberLabel.Name = "valueNumberLabel";
            this.valueNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.valueNumberLabel.TabIndex = 6;
            this.valueNumberLabel.Text = "label1";
            // 
            // previousMoveValueLabel
            // 
            this.previousMoveValueLabel.AutoSize = true;
            this.previousMoveValueLabel.Location = new System.Drawing.Point(120, 62);
            this.previousMoveValueLabel.Name = "previousMoveValueLabel";
            this.previousMoveValueLabel.Size = new System.Drawing.Size(35, 13);
            this.previousMoveValueLabel.TabIndex = 7;
            this.previousMoveValueLabel.Text = "label1";
            // 
            // deckLabel
            // 
            this.deckLabel.AutoSize = true;
            this.deckLabel.Location = new System.Drawing.Point(15, 89);
            this.deckLabel.Name = "deckLabel";
            this.deckLabel.Size = new System.Drawing.Size(92, 13);
            this.deckLabel.TabIndex = 8;
            this.deckLabel.Text = "Deck Card Count:";
            // 
            // deckCountLabel
            // 
            this.deckCountLabel.AutoSize = true;
            this.deckCountLabel.Location = new System.Drawing.Point(120, 89);
            this.deckCountLabel.Name = "deckCountLabel";
            this.deckCountLabel.Size = new System.Drawing.Size(35, 13);
            this.deckCountLabel.TabIndex = 9;
            this.deckCountLabel.Text = "label1";
            // 
            // NodeStateVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deckCountLabel);
            this.Controls.Add(this.deckLabel);
            this.Controls.Add(this.previousMoveValueLabel);
            this.Controls.Add(this.valueNumberLabel);
            this.Controls.Add(this.visitsNumberLabel);
            this.Controls.Add(this.previousMoveLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.dealerLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.visitsLabel);
            this.Name = "NodeStateVisualiser";
            this.Text = "NodeStateVisualiser";
            this.Load += new System.EventHandler(this.NodeStateVisualiser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label visitsLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label dealerLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label previousMoveLabel;
        private System.Windows.Forms.Label visitsNumberLabel;
        private System.Windows.Forms.Label valueNumberLabel;
        private System.Windows.Forms.Label previousMoveValueLabel;
        private System.Windows.Forms.Label deckLabel;
        private System.Windows.Forms.Label deckCountLabel;
    }
}