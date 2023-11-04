using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameWindow;

namespace MiniGameCardMemory
{
    internal class CardGameForm : Form
    {

        public static int currentPlayerLevel;

        MiniGameMainTimer timer = new MiniGameMainTimer();
        public CardGameElements elements;

        public CardGameForm(int level)
        {
            currentPlayerLevel = level;

            this.Name = "MiniGameCardGame";
            this.Size = new Size(800, 500);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest Mini Game: Card Memory Game";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = MiniGameResources.minigame_bg;
            //this.BackgroundImage = MiniGameCardResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            AddFormElements();
        }

        public void AddFormElements()
        {
            CardGameElements elements = new CardGameElements(this);

            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(timer.cardsMatch);
            this.Controls.Add(timer.time);

            elements.LoadPictures();
        }


        private static CardGameForm instance;
        public static CardGameForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardGameForm(currentPlayerLevel);
                }
                return instance;
            }
        }

        public void CloseForm()
        {
            Application.ExitThread();
        }

    }
}
