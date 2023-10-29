using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameCardMemory
{
    internal class CardGameInfo
    {

        public static int totalTime = 31;
        public static bool gameOver = false;
        public static List<PictureBox> cardPicturesCollection = new List<PictureBox>();

        public List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };


        public static Label lblTimer = new Label
        {
            Size = new Size(200, 200),
            //Font = new Font(fontCollection.pfc.Families[1], 25),
            Font = new Font("Arial", 25),
            Location = new Point(0, 50)
        };

        public static Label LblTimer
        {
            get { return lblTimer; }
            set { lblTimer = value; }
        }
    }
}
