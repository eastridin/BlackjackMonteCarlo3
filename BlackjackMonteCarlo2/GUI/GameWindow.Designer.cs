
namespace BlackjackMonteCarlo2.GUI
{
    partial class GameWindow
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
            this.playersPanel = new System.Windows.Forms.Panel();
            this.setupPanel = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.dealerPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playersPanel
            // 
            this.playersPanel.Location = new System.Drawing.Point(72, 223);
            this.playersPanel.Name = "playersPanel";
            this.playersPanel.Size = new System.Drawing.Size(764, 184);
            this.playersPanel.TabIndex = 0;
            // 
            // setupPanel
            // 
            this.setupPanel.Location = new System.Drawing.Point(72, 413);
            this.setupPanel.Name = "setupPanel";
            this.setupPanel.Size = new System.Drawing.Size(703, 40);
            this.setupPanel.TabIndex = 3;
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(72, 413);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(703, 40);
            this.gamePanel.TabIndex = 4;
            // 
            // dealerPanel
            // 
            this.dealerPanel.Location = new System.Drawing.Point(350, 75);
            this.dealerPanel.Name = "dealerPanel";
            this.dealerPanel.Size = new System.Drawing.Size(128, 119);
            this.dealerPanel.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.viewTreesToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItemClick);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.SaveGameToolStripMenuItemClick);
            // 
            // viewTreesToolStripMenuItem
            // 
            this.viewTreesToolStripMenuItem.Name = "viewTreesToolStripMenuItem";
            this.viewTreesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.viewTreesToolStripMenuItem.Text = "View Trees";
            this.viewTreesToolStripMenuItem.Click += new System.EventHandler(this.ViewTreesToolStripMenuItemClick);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.hintToolStripMenuItem.Text = "Hint";
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.HintToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItemClick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 465);
            this.Controls.Add(this.dealerPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.setupPanel);
            this.Controls.Add(this.playersPanel);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBackground);
            this.Resize += new System.EventHandler(this.WindowResized);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel playersPanel;
        private System.Windows.Forms.Panel setupPanel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel dealerPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
    }
}

