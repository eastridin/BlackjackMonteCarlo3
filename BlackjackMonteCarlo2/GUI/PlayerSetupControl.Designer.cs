
namespace BlackjackMonteCarlo2.GUI
{
    partial class PlayerSetupControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerNumberLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.playerTypeLabel = new System.Windows.Forms.Label();
            this.resetBalanceButton = new System.Windows.Forms.Button();
            this.balanceValue = new System.Windows.Forms.NumericUpDown();
            this.playerTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.balanceValue)).BeginInit();
            this.SuspendLayout();
            // 
            // playerNumberLabel
            // 
            this.playerNumberLabel.AutoSize = true;
            this.playerNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNumberLabel.Location = new System.Drawing.Point(7, 4);
            this.playerNumberLabel.Name = "playerNumberLabel";
            this.playerNumberLabel.Size = new System.Drawing.Size(95, 16);
            this.playerNumberLabel.TabIndex = 0;
            this.playerNumberLabel.Text = "Player number";
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(4, 29);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(49, 13);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Text = "Balance:";
            // 
            // playerTypeLabel
            // 
            this.playerTypeLabel.AutoSize = true;
            this.playerTypeLabel.Location = new System.Drawing.Point(4, 81);
            this.playerTypeLabel.Name = "playerTypeLabel";
            this.playerTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.playerTypeLabel.TabIndex = 2;
            this.playerTypeLabel.Text = "Player type:";
            // 
            // resetBalanceButton
            // 
            this.resetBalanceButton.Location = new System.Drawing.Point(3, 52);
            this.resetBalanceButton.Name = "resetBalanceButton";
            this.resetBalanceButton.Size = new System.Drawing.Size(87, 23);
            this.resetBalanceButton.TabIndex = 3;
            this.resetBalanceButton.Text = "Reset Balance";
            this.resetBalanceButton.UseVisualStyleBackColor = true;
            this.resetBalanceButton.Click += new System.EventHandler(this.ResetBalanceButtonClick);
            // 
            // balanceValue
            // 
            this.balanceValue.AutoSize = true;
            this.balanceValue.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.balanceValue.Location = new System.Drawing.Point(59, 27);
            this.balanceValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.balanceValue.Name = "balanceValue";
            this.balanceValue.Size = new System.Drawing.Size(53, 20);
            this.balanceValue.TabIndex = 4;
            this.balanceValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // playerTypeComboBox
            // 
            this.playerTypeComboBox.FormattingEnabled = true;
            this.playerTypeComboBox.Items.AddRange(new object[] {
            "User",
            "AI"});
            this.playerTypeComboBox.Location = new System.Drawing.Point(72, 78);
            this.playerTypeComboBox.Name = "playerTypeComboBox";
            this.playerTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerTypeComboBox.TabIndex = 5;
            // 
            // PlayerSetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.playerTypeComboBox);
            this.Controls.Add(this.balanceValue);
            this.Controls.Add(this.resetBalanceButton);
            this.Controls.Add(this.playerTypeLabel);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.playerNumberLabel);
            this.Name = "PlayerSetupControl";
            this.Size = new System.Drawing.Size(215, 140);
            ((System.ComponentModel.ISupportInitialize)(this.balanceValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerNumberLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label playerTypeLabel;
        private System.Windows.Forms.Button resetBalanceButton;
        public System.Windows.Forms.NumericUpDown balanceValue;
        public System.Windows.Forms.ComboBox playerTypeComboBox;
    }
}
