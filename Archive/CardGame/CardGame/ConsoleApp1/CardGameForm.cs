using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace ConsoleApp1
{
    internal class CardGameForm : Form
    {
        MiniGameMainTimer timer = new MiniGameMainTimer();
        CardGameInfo info = new CardGameInfo();
        public CardGameElements elements;

        public CardGameForm() 
        {
            this.Size = new Size(800, 500);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest Mini Game: Card Memory Game";

            AddFormElements();
        }

        public void AddFormElements()
        {
            CardGameElements elements = new CardGameElements(this);

            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(timer.time);

            elements.LoadPictures();            
        }
    }
}
