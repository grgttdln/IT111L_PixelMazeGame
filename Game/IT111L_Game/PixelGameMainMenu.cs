using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


namespace IT111L_Game
{
    internal class PixelGameMainMenu
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        
        public Panel PanelMainMenu { get; set; }

        // Constructor for PixelGameMainMenu
        public PixelGameMainMenu()
        {
            PanelMainMenu = new Panel
            {
                Text = "PanelMainMenu",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackgroundImage = Resources.menu_bg
            };
        }


        // Method to add main menu elements
        public void AddPanelMMElements()
        {
            PixelGameMMElements mmElements = new PixelGameMMElements();
            
            PanelMainMenu.Controls.Add(mmElements.StartBtn);
            PanelMainMenu.Controls.Add(mmElements.LeaderBoardBtn);
            PanelMainMenu.Controls.Add(mmElements.ExitBtn);
            PanelMainMenu.Controls.Add(mmElements.MainMenuBg);
        }
    }


    internal class PixelGameMMElements
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        PixelGameMMBtnFunc pgMMBtnLogic = new PixelGameMMBtnFunc();

        // Buttons and label for main menu elements
        public Button StartBtn { get; set; }
        public Button ExitBtn { get; set; }
        public Button LeaderBoardBtn { get; set; }
        public Label MainMenuBg { get; set; }

        // Constructor for PixelGameMMElements
        public PixelGameMMElements()
        {
            StartBtn = new Button
            {
                Text = "PLAY",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 30),
                Location = new Point(420, 480),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = 
                {
                    BorderSize = 0  
                },
            };

            StartBtn.Click += pgMMBtnLogic.StartBtnFunc;
            StartBtn.MouseEnter += pgMMBtnLogic.Button_MouseEnter;
            StartBtn.MouseLeave += pgMMBtnLogic.Button_MouseLeave;

            LeaderBoardBtn = new Button
            {
                Text = "LEADERBOARDS",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 30),
                Location = new Point(420, 570),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                },
            };

            LeaderBoardBtn.Click += pgMMBtnLogic.LeaderBoardBtnFunc;
            LeaderBoardBtn.MouseEnter += pgMMBtnLogic.Button_MouseEnter;
            LeaderBoardBtn.MouseLeave += pgMMBtnLogic.Button_MouseLeave;

            ExitBtn = new Button
            {
                Text = "EXIT",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 30),
                Location = new Point(420, 660),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                },
            };

            ExitBtn.Click += pgMMBtnLogic.ExitBtnnFunc;
            ExitBtn.MouseEnter += pgMMBtnLogic.Button_MouseEnter;
            ExitBtn.MouseLeave += pgMMBtnLogic.Button_MouseLeave;


            MainMenuBg = new Label
            {
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                Image = Resources.menu_bg,
            };
        }
    }


    internal class PixelGameMMBtnFunc
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }


        // Button logic for main menu buttons
        // Handles the event when the mouse leaves the button.
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button currBtn = (Button)sender;
                currBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                currBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                currBtn.ForeColor = Color.Red;
            }
        }

        // Handles the event when the Start button is clicked.
        public void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button currBtn = (Button)sender;
                currBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                currBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                currBtn.ForeColor = Color.White;
            }
        }

        // Handles the event when the Leaderboard button is clicked.
        public void StartBtnFunc(object sender, EventArgs e)
        {
            Program.gInfo.IsBgPlaying = false;

            PGMM_GameStart gameStart = new PGMM_GameStart();

            GetPanelMainMenu.Controls.Clear();
            
            gameStart.LoadGameStart();

        }

        // Handles the event when the Exit button is clicked.
        public void LeaderBoardBtnFunc(object sender, EventArgs e)
        {
            PGMM_Leaderboards leaderboards = new PGMM_Leaderboards();

            GetPanelMainMenu.Controls.Clear();
            
            leaderboards.LoadLeaderboards();
        }

        // Handles the event when the Exit button is clicked.
        public void ExitBtnnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
            Application.Exit();
        }

    }

}
