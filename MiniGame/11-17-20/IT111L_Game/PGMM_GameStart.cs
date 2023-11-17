using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class PGMM_GameStart
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel PanelLanding { get; set; }
        public Button BackBtn { get; set; }
        public Button NewGameBtn { get; set; }
        public Label Play { get; set; }


        GameStartBtnFunc btnFunc = new GameStartBtnFunc();

        public PGMM_GameStart()
        {
            PanelLanding = new Panel
            {
                Text = "Panel Landing",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            BackBtn = new Button
            {
                Text = "Back",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(100, 100)
            };

            BackBtn.Click += btnFunc.BackBtnFunc;

            NewGameBtn = new Button
            {
                Text = "New Game",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(200, 200),
                Size = new Size(800, 75),
                BackColor = Color.LightGray,
            };

            NewGameBtn.Click += btnFunc.NewGameFunc;

            Play = new Label
            {
                Text = "Play",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 100),
                Size = new Size(200, 200)
            };
        }

        public void LoadGameStart()
        {
            GetPanelMainMenu.Controls.Add(PanelLanding);
            PanelLanding.Controls.Add(BackBtn);
            PanelLanding.Controls.Add(NewGameBtn);
        }
    }


    internal class GameStartBtnFunc : PixelGameLBtnFunc
    {
        PixelGameMMElements mmElements = new PixelGameMMElements();
        public static NewGame newGame = new NewGame();

        public void NewGameFunc(object sender, EventArgs e)
        {
            Console.WriteLine("New Game");

            GetPanelMainMenu.Controls.Clear();

            // new game load
            newGame.LoadGameStart_1();

        }

    }
}
