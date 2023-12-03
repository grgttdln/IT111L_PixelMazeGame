using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Media;

// The CardGameLogic class manages the game logic for the Card Memory Game.
namespace MiniGameCardMemory
{
    internal class CardGameLogic
    {
        // Instance of MiniGameMainTimer for handling game timer functionality.
        MiniGameMainTimer gameTimer = new MiniGameMainTimer();

        // Instance of SoundPlayer for playing game sounds.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Variables to store the values of the first and second selected cards.
        public string firstCard;
        public string secondCard;

        // PictureBoxes to represent the first and second selected cards.
        public PictureBox cardA = new PictureBox();
        public PictureBox cardB = new PictureBox();

        // Counter to keep track of matched card pairs.
        public int counter = 0;

        // Method to check if the player has won the game based on the provided row parameter.
        public void IsWinner(int row)
        {
            if (counter == row)
            {
                // Reveal all cards and play win sound when the player wins.
                foreach (PictureBox x in CardGameInfo.cardPicturesCollection)
                {
                    if (x.Tag != null)
                    {
                        x.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + x.Tag.ToString());
                    }
                }
                soundPlayer.Stream = MiniGameCardResources.win;
                soundPlayer.Play();
                // Stop the game timer and display a winning message.
                gameTimer.CGFormTimerStop("You Won!");
                return;
            }
        }

        // Event handler for when a card is clicked.
        public void CardClicked(object sender, EventArgs e)
        {
            // Play flip card sound.
            soundPlayer.Stream = MiniGameCardResources.flipcard;
            soundPlayer.Play();

            // If the game is over, do nothing.
            if (CardGameInfo.gameOver)
            {
                return;
            }

            // Check the number of matched cards based on the current game level.
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

            // Check the selected cards.
            CheckCards(cardA, cardB);

            // If either the first or second card is null, assign the clicked card to it.
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

        // Method to flip all cards back to their default state.
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

        // Method to check the selected cards and determine if they match.
        public void CheckCards(PictureBox A, PictureBox B)
        {
            try
            {
                if (firstCard != null && secondCard != null)
                {
                    if (firstCard == secondCard)
                    {
                        // If the cards match, set their tags to null, increment the counter, and decrement the total number of cards.
                        A.Tag = null;
                        B.Tag = null;
                        counter += 1;
                        CardGameInfo.totalCards -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Mismatched");
                    }

                    // Reset the first and second card values and flip all cards back to their default state.
                    firstCard = null;
                    secondCard = null;
                    FlipCards();
                }
            }
            catch (Exception e)
            {
                // Handle exceptions if any.
            }
        }

        // Method to start a new game and order the cards.
        public void NewGameOrderCards()
        {
            gameTimer.CGFormTimerStart();
        }
    }
}

