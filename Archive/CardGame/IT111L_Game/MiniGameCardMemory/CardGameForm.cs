using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MiniGameCardMemory
{
    internal class CardGameForm : Form
    {
        CardGameInfo info = new CardGameInfo();
        MiniGameMainTimer timer = new MiniGameMainTimer();
        public CardGameElements elements;

        public CardGameForm()
        {
            this.Size = new Size(800, 500);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest Mini Game: Card Memory Game";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

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
