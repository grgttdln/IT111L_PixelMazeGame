using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    internal class CardGameFormLogic
    {
        MiniGameMainTimer gameTimer = new MiniGameMainTimer();

        public string firstCard;
        public string secondCard;
        public PictureBox cardA = new PictureBox();
        public PictureBox cardB = new PictureBox();

        public int counter = 0;

        public string dic = @"pics\";

        public void CardClicked(object sender, EventArgs e)
        {

            if (counter == 5)
            {
                foreach (PictureBox x in CardGameInfo.cardPicturesCollection)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                    }
                } 
                gameTimer.CGFormTimerStop("Winner Chicken Dinner");
                return;
            }

            CheckCards(cardA, cardB);

            if (firstCard == null || secondCard == null)
            {
                if (firstCard == null)
                {   
                    cardA = sender as PictureBox;
                    if (cardA.Tag != null && cardA.Image == null)
                    {
                        cardA.Image = Image.FromFile(dic + (string)cardA.Tag + ".png");
                        firstCard = (string)cardA.Tag;
                    }
                }
                else if (secondCard == null)
                {
                    cardB = sender as PictureBox;
                    if (cardB.Tag != null && cardB.Image == null)
                    {
                        cardB.Image = Image.FromFile(dic + (string)cardB.Tag + ".png");
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
                    p.Image = null;
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