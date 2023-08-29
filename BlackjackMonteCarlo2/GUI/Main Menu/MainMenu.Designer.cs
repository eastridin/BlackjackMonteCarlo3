
namespace BlackjackMonteCarlo2.GUI
{
    partial class MainMenu
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
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.simulateButton = new System.Windows.Forms.Button();
            this.loadGameButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.navigationPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.navigationPanel.Controls.Add(this.simulateButton);
            this.navigationPanel.Controls.Add(this.loadGameButton);
            this.navigationPanel.Controls.Add(this.settingsButton);
            this.navigationPanel.Controls.Add(this.newGameButton);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(175, 531);
            this.navigationPanel.TabIndex = 1;
            // 
            // simulateButton
            // 
            this.simulateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.simulateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.simulateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simulateButton.FlatAppearance.BorderSize = 0;
            this.simulateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateButton.ForeColor = System.Drawing.Color.White;
            this.simulateButton.Location = new System.Drawing.Point(0, 191);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(175, 66);
            this.simulateButton.TabIndex = 3;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.UseVisualStyleBackColor = false;
            this.simulateButton.Click += new System.EventHandler(this.SimulateButtonClick);
            // 
            // loadGameButton
            // 
            this.loadGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.loadGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadGameButton.FlatAppearance.BorderSize = 0;
            this.loadGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGameButton.ForeColor = System.Drawing.Color.White;
            this.loadGameButton.Location = new System.Drawing.Point(0, 119);
            this.loadGameButton.Name = "loadGameButton";
            this.loadGameButton.Size = new System.Drawing.Size(175, 66);
            this.loadGameButton.TabIndex = 2;
            this.loadGameButton.Text = "Load Game";
            this.loadGameButton.UseVisualStyleBackColor = false;
            this.loadGameButton.Click += new System.EventHandler(this.LoadGameButtonClick);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(0, 263);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(175, 66);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newGameButton.FlatAppearance.BorderSize = 0;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.ForeColor = System.Drawing.Color.White;
            this.newGameButton.Location = new System.Drawing.Point(0, 47);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(175, 66);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.NewGameButtonClick);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.Green;
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(175, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(774, 47);
            this.titlePanel.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(774, 47);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Select an Option";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formPanel
            // 
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(175, 47);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(774, 484);
            this.formPanel.TabIndex = 3;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(949, 531);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.navigationPanel);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuLoad);
            this.navigationPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Button loadGameButton;
    }
}