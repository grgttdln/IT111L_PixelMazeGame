using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;

// The MiniGameMainTimer class manages the timer functionality for the Card Memory Game.
// It inherits from the CardGameInfo class and contains methods to control the game timer and related actions.
namespace MiniGameCardMemory
{
    internal class MiniGameMainTimer : CardGameInfo
    {
        // SoundPlayer to play sound effects during the game.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // System.Windows.Forms.Timer for the game.
        public System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();

        // Label to display the remaining time.
        public Label time = LblTimer;

        // Label to display the number of cards left to match.
        public Label cardsMatch = LblMatchedCards;

        // Flag to indicate if the game has finished.
        public bool isFinish = false;

        // Method to start the game timer.
        public void CGFormTimerStart()
        {
            // Set the interval and enable the timer.
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        // Method to stop the game timer and display the result message.
        public void CGFormTimerStop(string message)
        {
            // Set the game over flag to true.
            gameOver = true;

            // Check if the game has already finished to avoid duplicate messages.
            if (!isFinish)
            {
                // Set the isFinish flag to true.
                isFinish = true;

                // Check if the game result is a win.
                if (message == "You Won!")
                {
                    // Update the IsWin property and stop the timer.
                    CardGameInfo.isWin = true;
                    LblMatchedCards.Text = $"Cards Left to Match: 0";
                    miniGameTick.Stop();
                }

                // Stop the timer and display the result message.
                miniGameTick.Stop();
                MessageBox.Show(message);

                // Close the CardGameForm.
                CardGameForm.form.CloseForm();
            }

            // Check if the game result is a lose.
            else if (!isFinish && message == "You Lose!")
            {
                // Stop the timer and display the result message.
                miniGameTick.Stop();
                MessageBox.Show(message);

                // Close the CardGameForm.
                CardGameForm.form.CloseForm();
            }
        }

        public void GameFormTimer()
        {
            totalTime--;
            LblTimer.Text = $"Time Left: {totalTime}";
        }

        // Method to update the game timer and check for game end conditions.
        public void GameActions(object sender, EventArgs e)
        {
            // Update the game timer.
            GameFormTimer();

            // Update the label displaying the number of cards left to match.
            LblMatchedCards.Text = $"Cards Left to Match: {totalCards}";

            // Check if the time has run out.
            if (totalTime == 0)
            {
                // Flip all cards to reveal their faces.
                foreach (PictureBox x in cardPicturesCollection)
                {
                    if (x.Tag != null)
                    {
                        x.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + x.Tag.ToString());
                    }
                }

                // Play the lose sound effect and stop the timer.
                soundPlayer.Stream = MiniGameCardResources.lose;
                soundPlayer.Play();
                CGFormTimerStop("You Lose!");
            }
        }
    }
}
