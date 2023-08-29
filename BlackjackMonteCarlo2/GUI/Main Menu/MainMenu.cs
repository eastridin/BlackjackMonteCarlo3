using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
        public partial class MainMenu : Form
        {

            Form currentForm;
            Form newGameForm;
            Form simulateForm;

            public MainMenu()
            {
                InitializeComponent();
            }

            private void MainMenuLoad(object sender, EventArgs e)
            {
                this.SuspendLayout();
                this.Text = "Main Menu";

                //Initialize the forms that can be selected using the navigation panel on the left.
                newGameForm = new BlackjackMonteCarlo2.GUI.Main_Menu.BlackjackSetup();
                simulateForm = new Main_Menu.SimulateWindow();

                this.ResumeLayout();
            }

            private void ChangeForm(Form form)
            {
                if(currentForm != null)
                {
                    this.formPanel.Controls.Remove(currentForm);
                }
                currentForm = form; //Resets current form to be the newly selected form
                this.titleLabel.Text = form.Text; //Changes the title to the title of the newly selected form.
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.formPanel.Controls.Add(form);
                form.BringToFront();
                form.Show(); //Shows the newly selected form
            }

            private void NewGameButtonClick(object sender, EventArgs e)
            {
                ChangeForm(newGameForm);
            }

            private void SettingsButtonClick(object sender, EventArgs e)
            {
                SettingsMenu settings = new SettingsMenu(); //Creates a settings form and shows as dialog so that program cannot be used until settings menu has been closed.
                settings.ShowDialog();
            }

            private void LoadGameButtonClick(object sender, EventArgs e)
            {
                OpenFileDialog fileDialog = new OpenFileDialog()
                {
                    Title = "Select a game save",
                    Filter = "Json Files (*.json)|*.json",
                    InitialDirectory = $"{Directory.GetCurrentDirectory()}"
                };
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Game.GameSave gameSave = JsonConvert.DeserializeObject<Game.GameSave>(File.ReadAllText(fileDialog.FileName), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                        GameWindow game = new GameWindow(gameSave); //Deserialize json into a gamesave object, then create a game using that save and start the game.
                        game.Show();
                        game.GameStart(gameSave);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to load game. Please make sure you have selected a valid game save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //If there is an error deserializing the save, return an error.
                    }
                }
            }

            private void SimulateButtonClick(object sender, EventArgs e)
            {
                ChangeForm(simulateForm);
            }
        }
}
