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
    internal class PGMM_Leaderboards
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        PixelGameLBtnFunc gbtnLogic = new PixelGameLBtnFunc();

        public Label Leaderboards { get; set; }
        public Button BackBtn { get; set; }
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }

        public PGMM_Leaderboards()
        {
            Leaderboards = new Label
            {
                Text = "Leaderboards",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 100),
                Size = new Size(200, 200)
            };

            BackBtn = new Button
            {
                Text = "Back",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(100, 100)
            };

            BackBtn.Click += gbtnLogic.BackBtnFunc;
        }

        public void LoadLeaderboards()
        {
            GetPanelMainMenu.Controls.Add(Leaderboards);
            GetPanelMainMenu.Controls.Add(BackBtn);
        }



    }
    internal class PixelGameLBtnFunc
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }

        PixelGameMMElements mmElements = new PixelGameMMElements();

        public void BackBtnFunc(object sender, EventArgs e)
        {
            GetPanelMainMenu.Controls.Clear();

            GetPanelMainMenu.Controls.Add(mmElements.StartBtn);
            GetPanelMainMenu.Controls.Add(mmElements.LeaderBoardBtn);
            GetPanelMainMenu.Controls.Add(mmElements.ExitBtn);

        }


    }
}
