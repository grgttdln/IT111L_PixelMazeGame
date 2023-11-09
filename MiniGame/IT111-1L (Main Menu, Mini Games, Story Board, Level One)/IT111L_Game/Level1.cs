using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Level1
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel Level1_MainPanel { get; set; }
        public Label LvlTitle { get; set; }

        public Level1 () 
        {
            // LEVEL 1 MAIN PANEL
            Level1_MainPanel = new Panel
            {
                Text = "Level1",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            LvlTitle = new Label
            {
                Text = "Sample Text - Level 1",
                Location = new Point(0, 0),
                Size = new Size(200, 200),

            };
        }

        public void LoadLevel1()
        {
            Console.WriteLine("Level 1 Loaded");
            GetPanelMainMenu.Controls.Clear();
            GetPanelMainMenu.Controls.Add(Level1_MainPanel);
            Level1_MainPanel.Controls.Add(LvlTitle);
        }
    }
}
