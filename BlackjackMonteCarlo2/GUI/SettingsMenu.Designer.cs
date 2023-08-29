
namespace BlackjackMonteCarlo2.GUI
{
    partial class SettingsMenu
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.playerTab = new System.Windows.Forms.TabPage();
            this.playersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gameTab = new System.Windows.Forms.TabPage();
            this.blackjackSettingsPanel = new System.Windows.Forms.Panel();
            this.blackjackSetDefaultsButton = new System.Windows.Forms.Button();
            this.numberOfDecksLabel = new System.Windows.Forms.Label();
            this.blackjackDecksCount = new System.Windows.Forms.NumericUpDown();
            this.blackjackSettingsLabel = new System.Windows.Forms.Label();
            this.aiSettingsPanel = new System.Windows.Forms.Panel();
            this.uctConstantUpDown = new System.Windows.Forms.NumericUpDown();
            this.aiSetDefaultsButton = new System.Windows.Forms.Button();
            this.mctsMaxIterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.aiIterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.mctsIterationsLabel = new System.Windows.Forms.Label();
            this.uctConstantLabel = new System.Windows.Forms.Label();
            this.aiIterationsLabel = new System.Windows.Forms.Label();
            this.aiSettingsLabel = new System.Windows.Forms.Label();
            this.revertChangesButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.playerTab.SuspendLayout();
            this.gameTab.SuspendLayout();
            this.blackjackSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackjackDecksCount)).BeginInit();
            this.aiSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uctConstantUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mctsMaxIterationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aiIterationsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.playerTab);
            this.tabControl.Controls.Add(this.gameTab);
            this.tabControl.Location = new System.Drawing.Point(12, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 396);
            this.tabControl.TabIndex = 10;
            // 
            // playerTab
            // 
            this.playerTab.Controls.Add(this.playersFlowLayoutPanel);
            this.playerTab.Location = new System.Drawing.Point(4, 22);
            this.playerTab.Name = "playerTab";
            this.playerTab.Padding = new System.Windows.Forms.Padding(3);
            this.playerTab.Size = new System.Drawing.Size(768, 370);
            this.playerTab.TabIndex = 0;
            this.playerTab.Text = "Player";
            this.playerTab.UseVisualStyleBackColor = true;
            // 
            // playersFlowLayoutPanel
            // 
            this.playersFlowLayoutPanel.Location = new System.Drawing.Point(6, 3);
            this.playersFlowLayoutPanel.Name = "playersFlowLayoutPanel";
            this.playersFlowLayoutPanel.Size = new System.Drawing.Size(756, 360);
            this.playersFlowLayoutPanel.TabIndex = 0;
            // 
            // gameTab
            // 
            this.gameTab.Controls.Add(this.blackjackSettingsPanel);
            this.gameTab.Controls.Add(this.aiSettingsPanel);
            this.gameTab.Location = new System.Drawing.Point(4, 22);
            this.gameTab.Name = "gameTab";
            this.gameTab.Padding = new System.Windows.Forms.Padding(3);
            this.gameTab.Size = new System.Drawing.Size(768, 370);
            this.gameTab.TabIndex = 1;
            this.gameTab.Text = "Game";
            this.gameTab.UseVisualStyleBackColor = true;
            // 
            // blackjackSettingsPanel
            // 
            this.blackjackSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blackjackSettingsPanel.Controls.Add(this.blackjackSetDefaultsButton);
            this.blackjackSettingsPanel.Controls.Add(this.numberOfDecksLabel);
            this.blackjackSettingsPanel.Controls.Add(this.blackjackDecksCount);
            this.blackjackSettingsPanel.Controls.Add(this.blackjackSettingsLabel);
            this.blackjackSettingsPanel.Location = new System.Drawing.Point(7, 152);
            this.blackjackSettingsPanel.Name = "blackjackSettingsPanel";
            this.blackjackSettingsPanel.Size = new System.Drawing.Size(247, 124);
            this.blackjackSettingsPanel.TabIndex = 1;
            // 
            // blackjackSetDefaultsButton
            // 
            this.blackjackSetDefaultsButton.Location = new System.Drawing.Point(52, 93);
            this.blackjackSetDefaultsButton.Name = "blackjackSetDefaultsButton";
            this.blackjackSetDefaultsButton.Size = new System.Drawing.Size(130, 28);
            this.blackjackSetDefaultsButton.TabIndex = 9;
            this.blackjackSetDefaultsButton.Text = "Set Defaults";
            this.blackjackSetDefaultsButton.UseVisualStyleBackColor = true;
            this.blackjackSetDefaultsButton.Click += new System.EventHandler(this.BlackjackSetDefaultsButtonClick);
            // 
            // numberOfDecksLabel
            // 
            this.numberOfDecksLabel.AutoSize = true;
            this.numberOfDecksLabel.Location = new System.Drawing.Point(22, 28);
            this.numberOfDecksLabel.Name = "numberOfDecksLabel";
            this.numberOfDecksLabel.Size = new System.Drawing.Size(93, 13);
            this.numberOfDecksLabel.TabIndex = 2;
            this.numberOfDecksLabel.Text = "Number of Decks:";
            // 
            // blackjackDecksCount
            // 
            this.blackjackDecksCount.Location = new System.Drawing.Point(122, 26);
            this.blackjackDecksCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.blackjackDecksCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blackjackDecksCount.Name = "blackjackDecksCount";
            this.blackjackDecksCount.Size = new System.Drawing.Size(117, 20);
            this.blackjackDecksCount.TabIndex = 1;
            this.blackjackDecksCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // blackjackSettingsLabel
            // 
            this.blackjackSettingsLabel.AutoSize = true;
            this.blackjackSettingsLabel.Location = new System.Drawing.Point(5, 5);
            this.blackjackSettingsLabel.Name = "blackjackSettingsLabel";
            this.blackjackSettingsLabel.Size = new System.Drawing.Size(95, 13);
            this.blackjackSettingsLabel.TabIndex = 0;
            this.blackjackSettingsLabel.Text = "Blackjack Settings";
            // 
            // aiSettingsPanel
            // 
            this.aiSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aiSettingsPanel.Controls.Add(this.uctConstantUpDown);
            this.aiSettingsPanel.Controls.Add(this.aiSetDefaultsButton);
            this.aiSettingsPanel.Controls.Add(this.mctsMaxIterationsUpDown);
            this.aiSettingsPanel.Controls.Add(this.aiIterationsUpDown);
            this.aiSettingsPanel.Controls.Add(this.mctsIterationsLabel);
            this.aiSettingsPanel.Controls.Add(this.uctConstantLabel);
            this.aiSettingsPanel.Controls.Add(this.aiIterationsLabel);
            this.aiSettingsPanel.Controls.Add(this.aiSettingsLabel);
            this.aiSettingsPanel.Location = new System.Drawing.Point(7, 7);
            this.aiSettingsPanel.Name = "aiSettingsPanel";
            this.aiSettingsPanel.Size = new System.Drawing.Size(247, 139);
            this.aiSettingsPanel.TabIndex = 0;
            // 
            // uctConstantUpDown
            // 
            this.uctConstantUpDown.Location = new System.Drawing.Point(121, 78);
            this.uctConstantUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.uctConstantUpDown.Name = "uctConstantUpDown";
            this.uctConstantUpDown.Size = new System.Drawing.Size(117, 20);
            this.uctConstantUpDown.TabIndex = 8;
            this.uctConstantUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // aiSetDefaultsButton
            // 
            this.aiSetDefaultsButton.Location = new System.Drawing.Point(51, 106);
            this.aiSetDefaultsButton.Name = "aiSetDefaultsButton";
            this.aiSetDefaultsButton.Size = new System.Drawing.Size(130, 28);
            this.aiSetDefaultsButton.TabIndex = 1;
            this.aiSetDefaultsButton.Text = "Set Defaults";
            this.aiSetDefaultsButton.UseVisualStyleBackColor = true;
            this.aiSetDefaultsButton.Click += new System.EventHandler(this.AISetDefaultsButtonClick);
            // 
            // mctsMaxIterationsUpDown
            // 
            this.mctsMaxIterationsUpDown.Location = new System.Drawing.Point(121, 52);
            this.mctsMaxIterationsUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.mctsMaxIterationsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mctsMaxIterationsUpDown.Name = "mctsMaxIterationsUpDown";
            this.mctsMaxIterationsUpDown.Size = new System.Drawing.Size(117, 20);
            this.mctsMaxIterationsUpDown.TabIndex = 7;
            this.mctsMaxIterationsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // aiIterationsUpDown
            // 
            this.aiIterationsUpDown.Location = new System.Drawing.Point(121, 26);
            this.aiIterationsUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.aiIterationsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aiIterationsUpDown.Name = "aiIterationsUpDown";
            this.aiIterationsUpDown.Size = new System.Drawing.Size(117, 20);
            this.aiIterationsUpDown.TabIndex = 6;
            this.aiIterationsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mctsIterationsLabel
            // 
            this.mctsIterationsLabel.AutoSize = true;
            this.mctsIterationsLabel.Location = new System.Drawing.Point(28, 54);
            this.mctsIterationsLabel.Name = "mctsIterationsLabel";
            this.mctsIterationsLabel.Size = new System.Drawing.Size(86, 13);
            this.mctsIterationsLabel.TabIndex = 5;
            this.mctsIterationsLabel.Text = "MCTS Iterations:";
            // 
            // uctConstantLabel
            // 
            this.uctConstantLabel.AutoSize = true;
            this.uctConstantLabel.Location = new System.Drawing.Point(37, 80);
            this.uctConstantLabel.Name = "uctConstantLabel";
            this.uctConstantLabel.Size = new System.Drawing.Size(77, 13);
            this.uctConstantLabel.TabIndex = 2;
            this.uctConstantLabel.Text = "UCT Constant:";
            // 
            // aiIterationsLabel
            // 
            this.aiIterationsLabel.AutoSize = true;
            this.aiIterationsLabel.Location = new System.Drawing.Point(48, 28);
            this.aiIterationsLabel.Name = "aiIterationsLabel";
            this.aiIterationsLabel.Size = new System.Drawing.Size(66, 13);
            this.aiIterationsLabel.TabIndex = 1;
            this.aiIterationsLabel.Text = "AI Iterations:";
            // 
            // aiSettingsLabel
            // 
            this.aiSettingsLabel.AutoSize = true;
            this.aiSettingsLabel.Location = new System.Drawing.Point(4, 4);
            this.aiSettingsLabel.Name = "aiSettingsLabel";
            this.aiSettingsLabel.Size = new System.Drawing.Size(58, 13);
            this.aiSettingsLabel.TabIndex = 0;
            this.aiSettingsLabel.Text = "AI Settings";
            // 
            // revertChangesButton
            // 
            this.revertChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.revertChangesButton.Location = new System.Drawing.Point(177, 408);
            this.revertChangesButton.Name = "revertChangesButton";
            this.revertChangesButton.Size = new System.Drawing.Size(154, 30);
            this.revertChangesButton.TabIndex = 12;
            this.revertChangesButton.Text = "Revert changes";
            this.revertChangesButton.UseVisualStyleBackColor = true;
            this.revertChangesButton.Click += new System.EventHandler(this.RevertChangesButtonClick);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveChangesButton.Location = new System.Drawing.Point(13, 407);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(157, 31);
            this.saveChangesButton.TabIndex = 11;
            this.saveChangesButton.Text = "Save changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButtonClick);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.revertChangesButton);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.tabControl);
            this.Name = "SettingsMenu";
            this.Text = "SettingsMenu";
            this.Load += new System.EventHandler(this.SettingsMenuLoad);
            this.tabControl.ResumeLayout(false);
            this.playerTab.ResumeLayout(false);
            this.gameTab.ResumeLayout(false);
            this.blackjackSettingsPanel.ResumeLayout(false);
            this.blackjackSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackjackDecksCount)).EndInit();
            this.aiSettingsPanel.ResumeLayout(false);
            this.aiSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uctConstantUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mctsMaxIterationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aiIterationsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage playerTab;
        private System.Windows.Forms.TabPage gameTab;
        private System.Windows.Forms.FlowLayoutPanel playersFlowLayoutPanel;
        private System.Windows.Forms.Panel aiSettingsPanel;
        private System.Windows.Forms.Label uctConstantLabel;
        private System.Windows.Forms.Label aiIterationsLabel;
        private System.Windows.Forms.Label aiSettingsLabel;
        private System.Windows.Forms.Label mctsIterationsLabel;
        private System.Windows.Forms.Button revertChangesButton;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.NumericUpDown mctsMaxIterationsUpDown;
        private System.Windows.Forms.NumericUpDown aiIterationsUpDown;
        private System.Windows.Forms.Button aiSetDefaultsButton;
        private System.Windows.Forms.NumericUpDown uctConstantUpDown;
        private System.Windows.Forms.Panel blackjackSettingsPanel;
        private System.Windows.Forms.Button blackjackSetDefaultsButton;
        private System.Windows.Forms.Label numberOfDecksLabel;
        private System.Windows.Forms.NumericUpDown blackjackDecksCount;
        private System.Windows.Forms.Label blackjackSettingsLabel;
    }
}