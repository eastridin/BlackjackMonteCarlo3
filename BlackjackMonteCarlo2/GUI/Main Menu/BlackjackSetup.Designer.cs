
namespace BlackjackMonteCarlo2.GUI.Main_Menu
{
    partial class BlackjackSetup
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
            this.blackjackNewGameButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.playersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.numberOfPlayersLabel = new System.Windows.Forms.Label();
            this.playerCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.newGameParametersLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerCountUpDown)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // blackjackNewGameButton
            // 
            this.blackjackNewGameButton.AutoSize = true;
            this.blackjackNewGameButton.BackColor = System.Drawing.Color.ForestGreen;
            this.blackjackNewGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blackjackNewGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackjackNewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackjackNewGameButton.Location = new System.Drawing.Point(5, 5);
            this.blackjackNewGameButton.Margin = new System.Windows.Forms.Padding(0);
            this.blackjackNewGameButton.Name = "blackjackNewGameButton";
            this.blackjackNewGameButton.Size = new System.Drawing.Size(790, 57);
            this.blackjackNewGameButton.TabIndex = 2;
            this.blackjackNewGameButton.Text = "Start New Game";
            this.blackjackNewGameButton.UseVisualStyleBackColor = false;
            this.blackjackNewGameButton.Click += new System.EventHandler(this.BlackjackNewGameButtonClick);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.playersFlowLayoutPanel);
            this.mainPanel.Controls.Add(this.numberOfPlayersLabel);
            this.mainPanel.Controls.Add(this.playerCountUpDown);
            this.mainPanel.Controls.Add(this.newGameParametersLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 383);
            this.mainPanel.TabIndex = 3;
            // 
            // playersFlowLayoutPanel
            // 
            this.playersFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playersFlowLayoutPanel.AutoScroll = true;
            this.playersFlowLayoutPanel.Location = new System.Drawing.Point(10, 85);
            this.playersFlowLayoutPanel.Name = "playersFlowLayoutPanel";
            this.playersFlowLayoutPanel.Size = new System.Drawing.Size(779, 287);
            this.playersFlowLayoutPanel.TabIndex = 3;
            // 
            // numberOfPlayersLabel
            // 
            this.numberOfPlayersLabel.AutoSize = true;
            this.numberOfPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfPlayersLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfPlayersLabel.Location = new System.Drawing.Point(10, 51);
            this.numberOfPlayersLabel.Name = "numberOfPlayersLabel";
            this.numberOfPlayersLabel.Size = new System.Drawing.Size(128, 17);
            this.numberOfPlayersLabel.TabIndex = 2;
            this.numberOfPlayersLabel.Text = "Number of players:";
            // 
            // playerCountUpDown
            // 
            this.playerCountUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.playerCountUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerCountUpDown.ForeColor = System.Drawing.Color.White;
            this.playerCountUpDown.Location = new System.Drawing.Point(144, 51);
            this.playerCountUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.playerCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerCountUpDown.Name = "playerCountUpDown";
            this.playerCountUpDown.ReadOnly = true;
            this.playerCountUpDown.Size = new System.Drawing.Size(81, 23);
            this.playerCountUpDown.TabIndex = 1;
            this.playerCountUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.playerCountUpDown.ValueChanged += new System.EventHandler(this.PlayerCountUpDownValueChanged);
            // 
            // newGameParametersLabel
            // 
            this.newGameParametersLabel.AutoSize = true;
            this.newGameParametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameParametersLabel.ForeColor = System.Drawing.Color.White;
            this.newGameParametersLabel.Location = new System.Drawing.Point(7, 12);
            this.newGameParametersLabel.Name = "newGameParametersLabel";
            this.newGameParametersLabel.Size = new System.Drawing.Size(214, 25);
            this.newGameParametersLabel.TabIndex = 0;
            this.newGameParametersLabel.Text = "New game parameters:";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.blackjackNewGameButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 383);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.buttonPanel.Size = new System.Drawing.Size(800, 67);
            this.buttonPanel.TabIndex = 4;
            // 
            // BlackjackSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "BlackjackSetup";
            this.Text = "BlackjackSetup";
            this.Load += new System.EventHandler(this.BlackjackSetupLoad);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerCountUpDown)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button blackjackNewGameButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label numberOfPlayersLabel;
        private System.Windows.Forms.NumericUpDown playerCountUpDown;
        private System.Windows.Forms.Label newGameParametersLabel;
        private System.Windows.Forms.FlowLayoutPanel playersFlowLayoutPanel;
        private System.Windows.Forms.Panel buttonPanel;
    }
}