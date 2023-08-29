namespace BlackjackMonteCarlo2.GUI.Main_Menu
{
    partial class SimulateWindow
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.simulationStatusValue = new System.Windows.Forms.Label();
            this.simulationStatusLabel = new System.Windows.Forms.Label();
            this.endingBalanceValueLabel = new System.Windows.Forms.Label();
            this.endingBalanceLabel = new System.Windows.Forms.Label();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.numberOfSimulations = new System.Windows.Forms.NumericUpDown();
            this.betAmount = new System.Windows.Forms.NumericUpDown();
            this.startingBalance = new System.Windows.Forms.NumericUpDown();
            this.numberOfSimulationsLabel = new System.Windows.Forms.Label();
            this.betAmountLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.simulateGameButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.resultsPanel.SuspendLayout();
            this.parametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSimulations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingBalance)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.resultsPanel);
            this.mainPanel.Controls.Add(this.parametersPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // resultsPanel
            // 
            this.resultsPanel.Controls.Add(this.simulationStatusValue);
            this.resultsPanel.Controls.Add(this.simulationStatusLabel);
            this.resultsPanel.Controls.Add(this.endingBalanceValueLabel);
            this.resultsPanel.Controls.Add(this.endingBalanceLabel);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.resultsPanel.Location = new System.Drawing.Point(390, 0);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(410, 450);
            this.resultsPanel.TabIndex = 5;
            // 
            // simulationStatusValue
            // 
            this.simulationStatusValue.AutoSize = true;
            this.simulationStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulationStatusValue.ForeColor = System.Drawing.Color.Black;
            this.simulationStatusValue.Location = new System.Drawing.Point(165, 18);
            this.simulationStatusValue.Name = "simulationStatusValue";
            this.simulationStatusValue.Size = new System.Drawing.Size(121, 16);
            this.simulationStatusValue.TabIndex = 13;
            this.simulationStatusValue.Text = "Not yet determined";
            // 
            // simulationStatusLabel
            // 
            this.simulationStatusLabel.AutoSize = true;
            this.simulationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulationStatusLabel.ForeColor = System.Drawing.Color.White;
            this.simulationStatusLabel.Location = new System.Drawing.Point(49, 18);
            this.simulationStatusLabel.Name = "simulationStatusLabel";
            this.simulationStatusLabel.Size = new System.Drawing.Size(111, 16);
            this.simulationStatusLabel.TabIndex = 12;
            this.simulationStatusLabel.Text = "Simulation status:";
            // 
            // endingBalanceValueLabel
            // 
            this.endingBalanceValueLabel.AutoSize = true;
            this.endingBalanceValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endingBalanceValueLabel.ForeColor = System.Drawing.Color.Black;
            this.endingBalanceValueLabel.Location = new System.Drawing.Point(165, 61);
            this.endingBalanceValueLabel.Name = "endingBalanceValueLabel";
            this.endingBalanceValueLabel.Size = new System.Drawing.Size(121, 16);
            this.endingBalanceValueLabel.TabIndex = 11;
            this.endingBalanceValueLabel.Text = "Not yet determined";
            // 
            // endingBalanceLabel
            // 
            this.endingBalanceLabel.AutoSize = true;
            this.endingBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endingBalanceLabel.ForeColor = System.Drawing.Color.White;
            this.endingBalanceLabel.Location = new System.Drawing.Point(98, 61);
            this.endingBalanceLabel.Name = "endingBalanceLabel";
            this.endingBalanceLabel.Size = new System.Drawing.Size(61, 16);
            this.endingBalanceLabel.TabIndex = 10;
            this.endingBalanceLabel.Text = "Balance:";
            // 
            // parametersPanel
            // 
            this.parametersPanel.Controls.Add(this.numberOfSimulations);
            this.parametersPanel.Controls.Add(this.betAmount);
            this.parametersPanel.Controls.Add(this.startingBalance);
            this.parametersPanel.Controls.Add(this.numberOfSimulationsLabel);
            this.parametersPanel.Controls.Add(this.betAmountLabel);
            this.parametersPanel.Controls.Add(this.balanceLabel);
            this.parametersPanel.Controls.Add(this.parametersLabel);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.parametersPanel.Location = new System.Drawing.Point(0, 0);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Size = new System.Drawing.Size(390, 450);
            this.parametersPanel.TabIndex = 4;
            // 
            // numberOfSimulations
            // 
            this.numberOfSimulations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.numberOfSimulations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfSimulations.ForeColor = System.Drawing.Color.White;
            this.numberOfSimulations.Location = new System.Drawing.Point(187, 137);
            this.numberOfSimulations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numberOfSimulations.Name = "numberOfSimulations";
            this.numberOfSimulations.Size = new System.Drawing.Size(81, 23);
            this.numberOfSimulations.TabIndex = 9;
            this.numberOfSimulations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // betAmount
            // 
            this.betAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.betAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.betAmount.ForeColor = System.Drawing.Color.White;
            this.betAmount.Location = new System.Drawing.Point(187, 98);
            this.betAmount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.betAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.betAmount.Name = "betAmount";
            this.betAmount.Size = new System.Drawing.Size(81, 23);
            this.betAmount.TabIndex = 8;
            this.betAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // startingBalance
            // 
            this.startingBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingBalance.ForeColor = System.Drawing.Color.White;
            this.startingBalance.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.startingBalance.Location = new System.Drawing.Point(187, 61);
            this.startingBalance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startingBalance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startingBalance.Name = "startingBalance";
            this.startingBalance.Size = new System.Drawing.Size(81, 23);
            this.startingBalance.TabIndex = 7;
            this.startingBalance.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numberOfSimulationsLabel
            // 
            this.numberOfSimulationsLabel.AutoSize = true;
            this.numberOfSimulationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfSimulationsLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfSimulationsLabel.Location = new System.Drawing.Point(27, 139);
            this.numberOfSimulationsLabel.Name = "numberOfSimulationsLabel";
            this.numberOfSimulationsLabel.Size = new System.Drawing.Size(143, 16);
            this.numberOfSimulationsLabel.TabIndex = 6;
            this.numberOfSimulationsLabel.Text = "Number of simulations:";
            // 
            // betAmountLabel
            // 
            this.betAmountLabel.AutoSize = true;
            this.betAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.betAmountLabel.ForeColor = System.Drawing.Color.White;
            this.betAmountLabel.Location = new System.Drawing.Point(27, 100);
            this.betAmountLabel.Name = "betAmountLabel";
            this.betAmountLabel.Size = new System.Drawing.Size(139, 16);
            this.betAmountLabel.TabIndex = 5;
            this.betAmountLabel.Text = "Bet amount per game:";
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceLabel.ForeColor = System.Drawing.Color.White;
            this.balanceLabel.Location = new System.Drawing.Point(27, 63);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(108, 16);
            this.balanceLabel.TabIndex = 4;
            this.balanceLabel.Text = "Starting balance:";
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parametersLabel.ForeColor = System.Drawing.Color.White;
            this.parametersLabel.Location = new System.Drawing.Point(12, 9);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(283, 25);
            this.parametersLabel.TabIndex = 1;
            this.parametersLabel.Text = "Simulate blackjack parameters:";
            // 
            // simulateGameButton
            // 
            this.simulateGameButton.BackColor = System.Drawing.Color.ForestGreen;
            this.simulateGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulateGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulateGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateGameButton.Location = new System.Drawing.Point(5, 5);
            this.simulateGameButton.Name = "simulateGameButton";
            this.simulateGameButton.Size = new System.Drawing.Size(790, 57);
            this.simulateGameButton.TabIndex = 3;
            this.simulateGameButton.Text = "Simulate";
            this.simulateGameButton.UseVisualStyleBackColor = false;
            this.simulateGameButton.Click += new System.EventHandler(this.SimulateGameButtonClick);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.simulateGameButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 383);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.buttonPanel.Size = new System.Drawing.Size(800, 67);
            this.buttonPanel.TabIndex = 2;
            // 
            // SimulateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "SimulateWindow";
            this.Text = "SimulateWindow";
            this.mainPanel.ResumeLayout(false);
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSimulations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingBalance)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel parametersPanel;
        private System.Windows.Forms.Button simulateGameButton;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.Label betAmountLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label numberOfSimulationsLabel;
        private System.Windows.Forms.NumericUpDown numberOfSimulations;
        private System.Windows.Forms.NumericUpDown betAmount;
        private System.Windows.Forms.NumericUpDown startingBalance;
        private System.Windows.Forms.Label endingBalanceValueLabel;
        private System.Windows.Forms.Label endingBalanceLabel;
        private System.Windows.Forms.Label simulationStatusValue;
        private System.Windows.Forms.Label simulationStatusLabel;
        private System.Windows.Forms.Panel buttonPanel;
    }
}