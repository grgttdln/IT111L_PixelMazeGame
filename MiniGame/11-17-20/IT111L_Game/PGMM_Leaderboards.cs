using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace IT111L_Game
{
    internal class PGMM_Leaderboards
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        PixelGameLBtnFunc gbtnLogic = new PixelGameLBtnFunc();

        public Panel Leaderboards { get; set; }
        public Panel Board { get; set; }
        public Panel Board_BG { get; set; }
        public Button BackBtn { get; set; }
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }

        public Label LeaderboardsTitle { get; }
        public Label RankTitle { get; }
        public Label AdventurerTitle { get; }
        public Label ScoreTitle { get; }

        public PGMM_Leaderboards()
        {
            Leaderboards = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 800),
                BackColor = Color.FromArgb(34, 41, 47),
            };

            BackBtn = new Button
            {
                Text = "BACK",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(100, 100),
                ForeColor = Color.White,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };

            BackBtn.Click += gbtnLogic.BackBtnFunc;
            BackBtn.MouseEnter += gbtnLogic.Button_MouseEnter;
            BackBtn.MouseLeave += gbtnLogic.Button_MouseLeave;

            Board = new Panel
            {
                Location = new Point(120, 215),
                Size = new Size(975, 470),
                BackColor = Color.Transparent,
                AutoScroll = true,
                VerticalScroll = { Visible = false },
                HorizontalScroll = { Visible = false }
            };

            Board_BG = new Panel
            {
                Location = new Point(90, 190),
                Size = new Size(1020, 520),
                BackColor = Color.Green,
                BackgroundImage = Resources.board,
                BackgroundImageLayout = ImageLayout.Stretch,
            };

            LeaderboardsTitle = new Label
            {
                Text = "LEADERBOARDS",
                Font = new Font(fontGame.pfc.Families[1], 30),
                Location = new Point(400, 75),
                Size = new Size(500, 100),
                ForeColor = Color.White,
            };

            RankTitle = new Label
            {
                Text = "RANK",
                Font = new Font(fontGame.pfc.Families[0], 25),
                Location = new Point(150, 150),
                Size = new Size(80, 30),
                BackColor= Color.Transparent,
                ForeColor = Color.White,
            };

            AdventurerTitle = new Label
            {
                Text = "ADVENTURER",
                Font = new Font(fontGame.pfc.Families[0], 25),
                Location = new Point(500, 150),
                Size = new Size(150, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };

            ScoreTitle = new Label
            {
                Text = "SCORE",
                Font = new Font(fontGame.pfc.Families[0], 25),
                Location = new Point(950, 150),
                Size = new Size(100, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };
        }

        public void LoadLeaderboards()
        {
            PixelGameLeaderboards leaderboards = new PixelGameLeaderboards();

            GetPanelMainMenu.Controls.Add(Leaderboards);

            Leaderboards.Controls.Add(Board);
            Leaderboards.Controls.Add(Board_BG);
            Leaderboards.Controls.Add(BackBtn);

            Leaderboards.Controls.Add(RankTitle);
            Leaderboards.Controls.Add(AdventurerTitle);
            Leaderboards.Controls.Add(ScoreTitle);
            Leaderboards.Controls.Add(LeaderboardsTitle);

            string[] players = leaderboards.ReadLeaderboardsTxt("leaderboards.txt");
            leaderboards.SortLeaderBoards(ref players);


            for (int i = 0; i < players.Length; i++)
            {
                string[] components = players[i].Split('|');
                Console.WriteLine(components[1]);
                Label lblPlayer = leaderboards.PlacePlayerLeader(components[0].ToUpper(), 150, 50 + (i * 50));
                Label lblRank = leaderboards.PlaceRank((i+1).ToString(), 50, 50 + (i * 50));
                Label lblScore = leaderboards.PlaceScore(components[1].ToString(), 850, 50 + (i * 50));
                Label lblScoreIcon = leaderboards.PlaceScoreIcon(790, 50 + (i * 50));

                Board.Controls.Add(lblPlayer);
                Board.Controls.Add(lblRank);
                Board.Controls.Add(lblScore);
                Board.Controls.Add(lblScoreIcon);
            }

            Board.VerticalScroll.Visible = false;
            Board.HorizontalScroll.Visible = false;
        }



    }
    internal class PixelGameLBtnFunc : PixelGameMMBtnFunc
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }

        PixelGameMMElements mmElements = new PixelGameMMElements();

        public void BackBtnFunc(object sender, EventArgs e)
        {
            GetPanelMainMenu.Controls.Clear();

            GetPanelMainMenu.Controls.Add(mmElements.StartBtn);
            GetPanelMainMenu.Controls.Add(mmElements.LeaderBoardBtn);
            GetPanelMainMenu.Controls.Add(mmElements.ExitBtn);
            GetPanelMainMenu.Controls.Add(mmElements.MainMenuBg);
        }
    }


}
