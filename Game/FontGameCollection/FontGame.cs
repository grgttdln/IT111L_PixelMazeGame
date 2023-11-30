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
        // PrivateFontCollection instance to manage custom fonts.
        public PrivateFontCollection pfc = new PrivateFontCollection();

        // Constructor for the FontGame class.
        public FontGame()
        {
            // Get the directory where the executable is located.
            string executableDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Define the file paths for two custom fonts in the "assets/fonts" directory.
            string fontFilePath_0 = Path.Combine(executableDirectory, "assets/fonts", "Kenney_Pixel.ttf");
            string fontFilePath_1 = Path.Combine(executableDirectory, "assets/fonts", "Kenney_Pixel_Square.ttf");

            // Add the first custom font file to the PrivateFontCollection.
            pfc.AddFontFile(fontFilePath_1);

            // Add the second custom font file to the PrivateFontCollection.
            pfc.AddFontFile(fontFilePath_0);
        }
    }
}
