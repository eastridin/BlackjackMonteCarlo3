namespace BlackjackMonteCarlo2.GUI
{
    partial class TreeVisualiser
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
            this.treePanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.leftTreeButton = new System.Windows.Forms.Button();
            this.rightTreeButton = new System.Windows.Forms.Button();
            this.drawTreeButton = new System.Windows.Forms.Button();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.iterationsCompletedLabel = new System.Windows.Forms.Label();
            this.moveMadeValueLabel = new System.Windows.Forms.Label();
            this.moveMadeLabel = new System.Windows.Forms.Label();
            this.splitValueLabel = new System.Windows.Forms.Label();
            this.doubleDownValueLabel = new System.Windows.Forms.Label();
            this.stickValueLabel = new System.Windows.Forms.Label();
            this.hitValueLabel = new System.Windows.Forms.Label();
            this.splitLabel = new System.Windows.Forms.Label();
            this.doubleDownLabel = new System.Windows.Forms.Label();
            this.stickLabel = new System.Windows.Forms.Label();
            this.hitLabel = new System.Windows.Forms.Label();
            this.indexLabel = new System.Windows.Forms.Label();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.moveComboBox = new System.Windows.Forms.ComboBox();
            this.playerComboBax = new System.Windows.Forms.ComboBox();
            this.selectedMoveLabel = new System.Windows.Forms.Label();
            this.selectedPlayerLabel = new System.Windows.Forms.Label();
            this.infoPanel.SuspendLayout();
            this.playerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treePanel
            // 
            this.treePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePanel.AutoScroll = true;
            this.treePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.treePanel.Location = new System.Drawing.Point(13, 13);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(609, 478);
            this.treePanel.TabIndex = 0;
            this.treePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TreePanelPaint);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.infoPanel.Controls.Add(this.leftTreeButton);
            this.infoPanel.Controls.Add(this.rightTreeButton);
            this.infoPanel.Controls.Add(this.drawTreeButton);
            this.infoPanel.Controls.Add(this.indexTextBox);
            this.infoPanel.Controls.Add(this.iterationsCompletedLabel);
            this.infoPanel.Controls.Add(this.moveMadeValueLabel);
            this.infoPanel.Controls.Add(this.moveMadeLabel);
            this.infoPanel.Controls.Add(this.splitValueLabel);
            this.infoPanel.Controls.Add(this.doubleDownValueLabel);
            this.infoPanel.Controls.Add(this.stickValueLabel);
            this.infoPanel.Controls.Add(this.hitValueLabel);
            this.infoPanel.Controls.Add(this.splitLabel);
            this.infoPanel.Controls.Add(this.doubleDownLabel);
            this.infoPanel.Controls.Add(this.stickLabel);
            this.infoPanel.Controls.Add(this.hitLabel);
            this.infoPanel.Controls.Add(this.indexLabel);
            this.infoPanel.Controls.Add(this.iterationsLabel);
            this.infoPanel.Location = new System.Drawing.Point(628, 97);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(218, 394);
            this.infoPanel.TabIndex = 1;
            // 
            // leftTreeButton
            // 
            this.leftTreeButton.Location = new System.Drawing.Point(38, 141);
            this.leftTreeButton.Name = "leftTreeButton";
            this.leftTreeButton.Size = new System.Drawing.Size(23, 23);
            this.leftTreeButton.TabIndex = 19;
            this.leftTreeButton.Text = "<";
            this.leftTreeButton.UseVisualStyleBackColor = true;
            this.leftTreeButton.Click += new System.EventHandler(this.LeftTreeButtonClick);
            // 
            // rightTreeButton
            // 
            this.rightTreeButton.Location = new System.Drawing.Point(146, 141);
            this.rightTreeButton.Name = "rightTreeButton";
            this.rightTreeButton.Size = new System.Drawing.Size(23, 23);
            this.rightTreeButton.TabIndex = 18;
            this.rightTreeButton.Text = ">";
            this.rightTreeButton.UseVisualStyleBackColor = true;
            this.rightTreeButton.Click += new System.EventHandler(this.RightTreeButtonClick);
            // 
            // drawTreeButton
            // 
            this.drawTreeButton.Location = new System.Drawing.Point(66, 141);
            this.drawTreeButton.Name = "drawTreeButton";
            this.drawTreeButton.Size = new System.Drawing.Size(75, 23);
            this.drawTreeButton.TabIndex = 17;
            this.drawTreeButton.Text = "Draw tree";
            this.drawTreeButton.UseVisualStyleBackColor = true;
            this.drawTreeButton.Click += new System.EventHandler(this.DrawTreeButtonClick);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(95, 105);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(100, 20);
            this.indexTextBox.TabIndex = 16;
            // 
            // iterationsCompletedLabel
            // 
            this.iterationsCompletedLabel.AutoSize = true;
            this.iterationsCompletedLabel.Location = new System.Drawing.Point(106, 11);
            this.iterationsCompletedLabel.Name = "iterationsCompletedLabel";
            this.iterationsCompletedLabel.Size = new System.Drawing.Size(35, 13);
            this.iterationsCompletedLabel.TabIndex = 15;
            this.iterationsCompletedLabel.Text = "label6";
            // 
            // moveMadeValueLabel
            // 
            this.moveMadeValueLabel.AutoSize = true;
            this.moveMadeValueLabel.Location = new System.Drawing.Point(134, 181);
            this.moveMadeValueLabel.Name = "moveMadeValueLabel";
            this.moveMadeValueLabel.Size = new System.Drawing.Size(35, 13);
            this.moveMadeValueLabel.TabIndex = 14;
            this.moveMadeValueLabel.Text = "label5";
            // 
            // moveMadeLabel
            // 
            this.moveMadeLabel.Location = new System.Drawing.Point(16, 181);
            this.moveMadeLabel.Name = "moveMadeLabel";
            this.moveMadeLabel.Size = new System.Drawing.Size(116, 13);
            this.moveMadeLabel.TabIndex = 0;
            this.moveMadeLabel.Text = "Move Made By Tree:";
            // 
            // splitValueLabel
            // 
            this.splitValueLabel.AutoSize = true;
            this.splitValueLabel.Location = new System.Drawing.Point(106, 75);
            this.splitValueLabel.Name = "splitValueLabel";
            this.splitValueLabel.Size = new System.Drawing.Size(35, 13);
            this.splitValueLabel.TabIndex = 10;
            this.splitValueLabel.Text = "label4";
            // 
            // doubleDownValueLabel
            // 
            this.doubleDownValueLabel.AutoSize = true;
            this.doubleDownValueLabel.Location = new System.Drawing.Point(106, 62);
            this.doubleDownValueLabel.Name = "doubleDownValueLabel";
            this.doubleDownValueLabel.Size = new System.Drawing.Size(35, 13);
            this.doubleDownValueLabel.TabIndex = 9;
            this.doubleDownValueLabel.Text = "label3";
            // 
            // stickValueLabel
            // 
            this.stickValueLabel.AutoSize = true;
            this.stickValueLabel.Location = new System.Drawing.Point(106, 49);
            this.stickValueLabel.Name = "stickValueLabel";
            this.stickValueLabel.Size = new System.Drawing.Size(35, 13);
            this.stickValueLabel.TabIndex = 8;
            this.stickValueLabel.Text = "label2";
            // 
            // hitValueLabel
            // 
            this.hitValueLabel.AutoSize = true;
            this.hitValueLabel.Location = new System.Drawing.Point(106, 36);
            this.hitValueLabel.Name = "hitValueLabel";
            this.hitValueLabel.Size = new System.Drawing.Size(35, 13);
            this.hitValueLabel.TabIndex = 7;
            this.hitValueLabel.Text = "label1";
            // 
            // splitLabel
            // 
            this.splitLabel.AutoSize = true;
            this.splitLabel.Location = new System.Drawing.Point(16, 75);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(27, 13);
            this.splitLabel.TabIndex = 6;
            this.splitLabel.Text = "Split";
            // 
            // doubleDownLabel
            // 
            this.doubleDownLabel.AutoSize = true;
            this.doubleDownLabel.Location = new System.Drawing.Point(16, 62);
            this.doubleDownLabel.Name = "doubleDownLabel";
            this.doubleDownLabel.Size = new System.Drawing.Size(72, 13);
            this.doubleDownLabel.TabIndex = 5;
            this.doubleDownLabel.Text = "Double Down";
            // 
            // stickLabel
            // 
            this.stickLabel.AutoSize = true;
            this.stickLabel.Location = new System.Drawing.Point(16, 49);
            this.stickLabel.Name = "stickLabel";
            this.stickLabel.Size = new System.Drawing.Size(31, 13);
            this.stickLabel.TabIndex = 4;
            this.stickLabel.Text = "Stick";
            // 
            // hitLabel
            // 
            this.hitLabel.AutoSize = true;
            this.hitLabel.Location = new System.Drawing.Point(16, 36);
            this.hitLabel.Name = "hitLabel";
            this.hitLabel.Size = new System.Drawing.Size(20, 13);
            this.hitLabel.TabIndex = 3;
            this.hitLabel.Text = "Hit";
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(17, 108);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(72, 13);
            this.indexLabel.TabIndex = 1;
            this.indexLabel.Text = "Index of tree: ";
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(13, 11);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(66, 13);
            this.iterationsLabel.TabIndex = 0;
            this.iterationsLabel.Text = "AI Iterations:";
            // 
            // playerPanel
            // 
            this.playerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playerPanel.Controls.Add(this.moveComboBox);
            this.playerPanel.Controls.Add(this.playerComboBax);
            this.playerPanel.Controls.Add(this.selectedMoveLabel);
            this.playerPanel.Controls.Add(this.selectedPlayerLabel);
            this.playerPanel.Location = new System.Drawing.Point(628, 13);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(218, 78);
            this.playerPanel.TabIndex = 2;
            // 
            // moveComboBox
            // 
            this.moveComboBox.FormattingEnabled = true;
            this.moveComboBox.Location = new System.Drawing.Point(103, 44);
            this.moveComboBox.Name = "moveComboBox";
            this.moveComboBox.Size = new System.Drawing.Size(103, 21);
            this.moveComboBox.TabIndex = 3;
            // 
            // playerComboBax
            // 
            this.playerComboBax.FormattingEnabled = true;
            this.playerComboBax.Location = new System.Drawing.Point(103, 10);
            this.playerComboBax.Name = "playerComboBax";
            this.playerComboBax.Size = new System.Drawing.Size(103, 21);
            this.playerComboBax.TabIndex = 2;
            // 
            // selectedMoveLabel
            // 
            this.selectedMoveLabel.AutoSize = true;
            this.selectedMoveLabel.Location = new System.Drawing.Point(13, 47);
            this.selectedMoveLabel.Name = "selectedMoveLabel";
            this.selectedMoveLabel.Size = new System.Drawing.Size(82, 13);
            this.selectedMoveLabel.TabIndex = 1;
            this.selectedMoveLabel.Text = "Selected Move:";
            // 
            // selectedPlayerLabel
            // 
            this.selectedPlayerLabel.AutoSize = true;
            this.selectedPlayerLabel.Location = new System.Drawing.Point(13, 13);
            this.selectedPlayerLabel.Name = "selectedPlayerLabel";
            this.selectedPlayerLabel.Size = new System.Drawing.Size(84, 13);
            this.selectedPlayerLabel.TabIndex = 0;
            this.selectedPlayerLabel.Text = "Selected Player:";
            // 
            // TreeVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 503);
            this.Controls.Add(this.playerPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.treePanel);
            this.Name = "TreeVisualiser";
            this.Text = "TreeVisualiser";
            this.Load += new System.EventHandler(this.TreeVisualiserLoad);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.playerPanel.ResumeLayout(false);
            this.playerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label hitLabel;
        private System.Windows.Forms.Label stickLabel;
        private System.Windows.Forms.Label splitValueLabel;
        private System.Windows.Forms.Label doubleDownValueLabel;
        private System.Windows.Forms.Label stickValueLabel;
        private System.Windows.Forms.Label hitValueLabel;
        private System.Windows.Forms.Label splitLabel;
        private System.Windows.Forms.Label doubleDownLabel;
        private System.Windows.Forms.Label moveMadeValueLabel;
        private System.Windows.Forms.Label moveMadeLabel;
        private System.Windows.Forms.Label iterationsCompletedLabel;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.Button drawTreeButton;
        private System.Windows.Forms.Button rightTreeButton;
        private System.Windows.Forms.Button leftTreeButton;
        private System.Windows.Forms.Panel playerPanel;
        private System.Windows.Forms.ComboBox moveComboBox;
        private System.Windows.Forms.ComboBox playerComboBax;
        private System.Windows.Forms.Label selectedMoveLabel;
        private System.Windows.Forms.Label selectedPlayerLabel;
    }
}