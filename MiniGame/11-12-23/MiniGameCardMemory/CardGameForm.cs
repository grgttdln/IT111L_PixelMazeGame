using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameWindow;
using System.Reflection.Emit;

namespace MiniGameCardMemory
{
    internal class CardGameForm : Form
    {
        public static int currentPlayerLevel;

        MiniGameMainTimer timer = new MiniGameMainTimer();
        public CardGameElements elements;

        public static CardGameForm form;

        public CardGameForm(int level)
        {
            currentPlayerLevel = level;

            this.Name = "MiniGameCardGame";
            this.Size = new Size(800, 500);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest Mini Game: Card Memory Game";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = MiniGameCardResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            form = this;
            this.FormClosed += CardGameForm_FormClosed;


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
            this.Close();
        }

        private void CardGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {

            CardGameInfo.totalTime = 16;
            CardGameInfo.totalCards = 0;
            CardGameInfo.cardPicturesCollection = new List<PictureBox>();
            CardGameInfo.gameOver = false;
            CardGameInfo.isWin = false;

        }

    }
}
