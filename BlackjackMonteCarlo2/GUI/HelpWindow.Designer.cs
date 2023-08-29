
namespace BlackjackMonteCarlo2.GUI
{
    partial class HelpWindow
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
            this.treeViewPanel = new System.Windows.Forms.Panel();
            this.directoryTreeView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.helpDisplay = new System.Windows.Forms.WebBrowser();
            this.treeViewPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewPanel
            // 
            this.treeViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewPanel.Controls.Add(this.directoryTreeView);
            this.treeViewPanel.Location = new System.Drawing.Point(12, 12);
            this.treeViewPanel.Name = "treeViewPanel";
            this.treeViewPanel.Size = new System.Drawing.Size(172, 426);
            this.treeViewPanel.TabIndex = 0;
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.directoryTreeView.Location = new System.Drawing.Point(0, 0);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.Size = new System.Drawing.Size(172, 426);
            this.directoryTreeView.TabIndex = 0;
            this.directoryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DirectoryTreeViewAfterSelect);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.helpDisplay);
            this.panel2.Location = new System.Drawing.Point(190, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 426);
            this.panel2.TabIndex = 1;
            // 
            // helpDisplay
            // 
            this.helpDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpDisplay.Location = new System.Drawing.Point(0, 0);
            this.helpDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpDisplay.Name = "helpDisplay";
            this.helpDisplay.Size = new System.Drawing.Size(595, 423);
            this.helpDisplay.TabIndex = 0;
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.treeViewPanel);
            this.Name = "HelpWindow";
            this.Text = "HelpWindow";
            this.Load += new System.EventHandler(this.HelpWindow_Load);
            this.treeViewPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel treeViewPanel;
        private System.Windows.Forms.TreeView directoryTreeView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser helpDisplay;
    }
}