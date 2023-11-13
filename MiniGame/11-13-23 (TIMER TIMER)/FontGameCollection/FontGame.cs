using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace FontGameCollection
{
    public class FontGame
    {
        public PrivateFontCollection pfc = new PrivateFontCollection();

        public FontGame()
        {

            string executableDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fontFilePath_0 = Path.Combine(executableDirectory, "assets/fonts", "Kenney_Pixel.ttf");
            string fontFilePath_1 = Path.Combine(executableDirectory, "assets/fonts", "Kenney_Pixel_Square.ttf");

            pfc.AddFontFile(fontFilePath_1);
            pfc.AddFontFile(fontFilePath_0); 
        }
    }
}
