using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGameWindow;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class PixelGameMain : MiniGameWindow.MiniGameForm
    {
        public PixelGameMain(int level) : base(level)
        {

        }

        public override void MiniGameMainDisplay()
        {
            PixelGameForm pixelMainGame = new PixelGameForm();
            Application.Run(pixelMainGame);
        }
    }
}
