
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    internal class FontGame
    {
        public PrivateFontCollection pfc = new PrivateFontCollection();

        public FontGame()
        {
            pfc.AddFontFile(@"C:\Users\Georgette\Desktop\IT111L_GAMEPROJ\CardGame\assets\fonts\Kenney_Pixel.ttf");
            pfc.AddFontFile(@"C:\Users\Georgette\Desktop\IT111L_GAMEPROJ\CardGame\assets\fonts\Kenney_Future_Narrow.ttf"); // 0
        }

    }
}
