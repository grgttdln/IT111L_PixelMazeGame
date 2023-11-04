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
    internal class PixelGameMainMenu : PixelGameMMBtnFunc
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Button StartBtn { get; set; }
        public Button ExitBtn { get; set; }
        public Button LeaderBoardBtn { get; set; }
        public Panel PanelMainMenu { get; set; }

        public PixelGameMainMenu()
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

            StartBtn.Click += StartBtnFunc;

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

            LeaderBoardBtn.Click += LeaderBoardBtnFunc;

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

            ExitBtn.Click += ExitBtnnFunc;

            PanelMainMenu = new Panel
            {
                Text = "PanelMainMenu",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                //BackColor = Color.Black,
            };
        }


        public void AddPanelMMElements()
        {
            PanelMainMenu.Controls.Add(StartBtn);
            PanelMainMenu.Controls.Add(LeaderBoardBtn);
            PanelMainMenu.Controls.Add(ExitBtn);
        }
    }


    internal class PixelGameMMBtnFunc
    {
        public void StartBtnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Start");
            //PixelGameMainMenu.PanelMainMenu.Dispose();
        }

        public void LeaderBoardBtnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Leaderboard");
        }
        
        public void ExitBtnnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
            Application.Exit();
        }

    }

}
