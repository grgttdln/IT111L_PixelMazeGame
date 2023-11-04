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

        public PixelGameMainMenu()
        {
            PanelMainMenu = new Panel
            {
                Text = "PanelMainMenu",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };
        }


        public void AddPanelMMElements()
        {
            PixelGameMMElements mmElements = new PixelGameMMElements();

            PanelMainMenu.Controls.Add(mmElements.StartBtn);
            PanelMainMenu.Controls.Add(mmElements.LeaderBoardBtn);
            PanelMainMenu.Controls.Add(mmElements.ExitBtn);
        }
    }


    internal class PixelGameMMElements
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        PixelGameMMBtnFunc pgMMBtnLogic = new PixelGameMMBtnFunc();

        public Button StartBtn { get; set; }
        public Button ExitBtn { get; set; }
        public Button LeaderBoardBtn { get; set; }

        public PixelGameMMElements()
        {
            StartBtn = new Button
            {
                Text = "Play",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(420, 270),
                ForeColor = Color.Black,
                BackColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
            };

            StartBtn.Click += pgMMBtnLogic.StartBtnFunc;

            LeaderBoardBtn = new Button
            {
                Text = "Leaderboards",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(420, 360),
                ForeColor = Color.Black,
                BackColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,

            };

            LeaderBoardBtn.Click += pgMMBtnLogic.LeaderBoardBtnFunc;

            ExitBtn = new Button
            {
                Text = "Exit",
                Size = new Size(300, 75),
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(420, 450),
                ForeColor = Color.Black,
                BackColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
            };

            ExitBtn.Click += pgMMBtnLogic.ExitBtnnFunc;
        }
    }


    internal class PixelGameMMBtnFunc
    {
        public void StartBtnFunc(object sender, EventArgs e)
        {
            PGMM_GameStart gameStart = new PGMM_GameStart();

            PixelGameForm.gMainMenu.PanelMainMenu.Controls.Clear();
            gameStart.LoadGameStart();

        }

        public void LeaderBoardBtnFunc(object sender, EventArgs e)
        {
            PGMM_Leaderboards leaderboards = new PGMM_Leaderboards();

            PixelGameForm.gMainMenu.PanelMainMenu.Controls.Clear();
            leaderboards.LoadLeaderboards();
        }

        public void ExitBtnnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
            Application.Exit();
        }

    }

}
