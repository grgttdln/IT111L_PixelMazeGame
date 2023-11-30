using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.IO;
using System.Collections;
using static System.Windows.Forms.LinkLabel;

namespace IT111L_Game
{
    // Internal class representing the final game stage
    internal class FinalGame
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        public PGMM_Leaderboards loadleaderboards = new PGMM_Leaderboards();

        // Panels representing different stages of the ending
        public Panel Ending_MainPanel { get; set; }
        public Panel Ending_Story { get; set; }
        public Panel Ending_PlayerName { get; set; }


        // TextBox for player name input
        public TextBox PlayerNameTxtBox { get; set; }


        // Constructor for initializing panels and controls
        public FinalGame() 
        {
            Ending_MainPanel = new Panel
            {
                Name = "EndingLevelMainPanel",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            Ending_Story = new Panel
            {
                Size = new Size(1200, 800),
                Location = new Point(0, 0),

                BackgroundImage = Resources.end_storyboard,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            Ending_PlayerName = new Panel
            {
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackgroundImage = Resources.save_hs,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            PlayerNameTxtBox = new TextBox
            {
                Location = new Point(455, 550),
                Size = new Size(300, 50),
                Font = new Font(fontGame.pfc.Families[0], 16),
                BackColor = Color.FromArgb(244, 238, 219), // bg color for old paper
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };

        }


        // Method to load the final game stage
        public void LoadFinal()
        {
            NewGame.level_3.Level3_MainPanel.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();

            GetPanelMainMenu.Controls.Add(Ending_MainPanel);

            Ending_MainPanel.Controls.Add(Ending_Story);

            Ending_Story.Click += StoryBoardClicked;

        }


        // Method to load the player name input and validation
        public void LoadEndingPlayerName()
        {
            Button submitName = new Button
            {
                Text = "Submit",
                Font = new Font(fontGame.pfc.Families[0], 24),
                Location = new Point(420, 600),
                Size = new Size(365, 75),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };

            submitName.Click += PlayerNameValidation;

            Ending_PlayerName.Controls.Add(submitName);
            Ending_PlayerName.Controls.Add(PlayerNameTxtBox);
        }


        // Event handler for clicking on the story panel
        public void StoryBoardClicked(object sender, EventArgs eventArgs)
        {
            if (sender is Panel)
            {
                Panel storyPanel = (Panel)sender;
                NewGame.final_game.Ending_MainPanel.Controls.Clear();

                NewGame.final_game.Ending_MainPanel.Controls.Add(NewGame.final_game.Ending_PlayerName);
                NewGame.final_game.LoadEndingPlayerName();
            }
        }


        // Event handler for player name validation and saving game information
        public void PlayerNameValidation(object sender, EventArgs eventArgs)
        {
            // Flags to track validation errors and existing player
            bool error = false;
            bool playerAlreadyExist = false;
            int playerIdx = -1;

            // Read previous players data
            PixelGameLeaderboards leaderboards = new PixelGameLeaderboards();
            string[] players = leaderboards.ReadLeaderboardsTxt("leaderboards.txt");
            
            List<string> playerList = new List<string>();

            // Populate the player list with existing player names
            if (players != null)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    string[] components = players[i].Split('|');
                    playerList.Add(components[0]);  
                }
            }


            // Player name validation
            try
            {
                string playerName = PlayerNameTxtBox.Text;

                if (playerName.Length <= 1 || playerName.Length > 15)
                {
                    error = true;
                    throw new Exception();
                }

                if (!Regex.IsMatch(playerName, "^[a-zA-Z0-9]+$"))
                {
                    error = true;
                    throw new Exception();
                }

                if (playerList.Contains(playerName))
                {
                    playerAlreadyExist = true;
                    playerIdx = playerList.IndexOf(playerName);
                }
            }
            catch
            {
                error = true;
            }

            // Process based on validation results
            if (!error && !playerAlreadyExist)
            {
                // Write the player's information to the leaderboards
                using (StreamWriter writer = new StreamWriter("./data/leaderboards.txt", true))
                {
                    writer.WriteLine($"{PlayerNameTxtBox.Text}|{Program.gInfo.Score}");
                    
                }

                MessageBox.Show("Your game information has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Ending_MainPanel.Hide();
                loadleaderboards.LoadLeaderboards();

                // Reset game information
                Program.gInfo.Score = 0;
                Program.gInfo.Life = 5;
                Level1.Level_TimeMain = new GameTimeMain(120);
            }
            else if (!error && playerAlreadyExist)
            {
                // Update the player's score if the name already exists
                string[] components = players[playerIdx].Split('|');
                int prevScore = int.Parse(components[1]);

                string newScorePlayer = $"{components[0]}|{components[1]}";
                players[playerIdx] = newScorePlayer;

                // Write the updated leaderboards
                File.WriteAllText("./data/leaderboards.txt", string.Empty);
                File.WriteAllLines("./data/leaderboards.txt", players);
                
                Console.WriteLine("Your game information has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Ending_MainPanel.Hide();
                loadleaderboards.LoadLeaderboards();

                // Reset game information
                Program.gInfo.Score = 0;
                Program.gInfo.Life = 5;
                Level1.Level_TimeMain = new GameTimeMain(120);
            }
            else
            {
                MessageBox.Show("Check your entered information before submitting again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
