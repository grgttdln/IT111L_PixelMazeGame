using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGameWindow;
using System.Windows.Forms;

namespace IT111L_Game
{
    // The PixelGameMain class represents the entry point for the pixel-based mini-game
    internal class PixelGameMain : MiniGameWindow.MiniGameForm
    {
        // Constructor for the PixelGameMain class, taking the level as a parameter
        public PixelGameMain(int level) : base(level)
        {

        }

        // Override method for displaying the main pixel game
        public override void MiniGameMainDisplay()
        {
            PixelGameForm pixelMainGame = new PixelGameForm();
            Application.Run(pixelMainGame);
        }
    }
}
