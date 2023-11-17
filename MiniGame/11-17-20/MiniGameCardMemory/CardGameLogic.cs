using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Media;

namespace MiniGameCardMemory
{

    internal class CardGameLogic
    {
        MiniGameMainTimer gameTimer = new MiniGameMainTimer();


        private SoundPlayer soundPlayer = new SoundPlayer();


        public string firstCard;
        public string secondCard;
        public PictureBox cardA = new PictureBox();
        public PictureBox cardB = new PictureBox();

        public int counter = 0;

        public void IsWinner(int row)
        {
            if (counter == row)
            {
                foreach (PictureBox x in CardGameInfo.cardPicturesCollection)
                {
                    if (x.Tag != null)
                    {
                        x.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + x.Tag.ToString());
                    }
                }
                soundPlayer.Stream = MiniGameCardResources.win;
                soundPlayer.Play();
                gameTimer.CGFormTimerStop("You Won!");
                return;
            }
        }

        public void CardClicked(object sender, EventArgs e)
        {
            soundPlayer.Stream = MiniGameCardResources.flipcard;
            soundPlayer.Play();

            if (CardGameInfo.gameOver)
            {
                return;
            }

            switch (CardGameForm.currentPlayerLevel)
            {
                case 1:
                    IsWinner(3);
                    break;
                case 2:
                    IsWinner(4);
                    break;
                case 3:
                    IsWinner(5);
                    break;
            }

            CheckCards(cardA, cardB);

            if (firstCard == null || secondCard == null)
            {
                if (firstCard == null)
                {
                    cardA = sender as PictureBox;

                    if (cardA.Tag != null)
                    {
                        cardA.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + cardA.Tag.ToString());
                        firstCard = (string)cardA.Tag;
                    }
                }
                else if (secondCard == null)
                {
                    cardB = sender as PictureBox;

                    if (cardB != cardA && cardB.Tag != null)
                    {
                        cardB.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + cardB.Tag.ToString());
                        secondCard = (string)cardB.Tag;
                    }

                }

            }

        }


        public void FlipCards()
        {
            foreach (PictureBox p in CardGameInfo.cardPicturesCollection.ToList())
            {
                if (p.Tag != null)
                {
                    p.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("card_back");
                }
            }
        }

        public void CheckCards(PictureBox A, PictureBox B)
        {
            try
            {
                if (firstCard != null && secondCard != null)
                {
                    if (firstCard == secondCard)
                    {
                        A.Tag = null;
                        B.Tag = null;
                        counter += 1;
                        CardGameInfo.totalCards -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Mismatched");
                    }

                    firstCard = null;
                    secondCard = null;

                    FlipCards();
                }

            }
            catch (Exception e)
            {

            }
        }


        public void NewGameOrderCards()
        {
            gameTimer.CGFormTimerStart();
        }
    }
}
