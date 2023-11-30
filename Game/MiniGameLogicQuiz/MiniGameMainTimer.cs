using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;


// The MiniGameMainTimer class manages the timer functionality for the Quiz Game.
// It inherits from the QuizGameInfo class and contains methods to control the game timer and related actions.
namespace MiniGameLogicQuiz
{
    internal class MiniGameMainTimer : QuizGameInfo
    {
        // System.Windows.Forms.Timer for the game.
        public static System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();

        // SoundPlayer to play sound effects during the game.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Label to display the remaining time.
        public Label time = QuizGameInfo.LblTimer;

        // Label to display the number of questions left to answer.
        public Label questionssLeft = QuizGameInfo.LblRightAnsLeft;

        // Flag to indicate if the game has finished.
        public bool isFinish = false;

        // Property to get and set the game timer.
        public static Timer GetTimer
        {
            get { return miniGameTick; }
            set { miniGameTick = value; }
        }

        // Method to start the game timer.
        public void CGFormTimerStart()
        {
            // Set the interval, enable the timer, and attach the GameActions event handler.
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick -= GameActions;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        // Method to stop the game timer and display the result message.
        public void CGFormTimerStop(string message)
        {
            // Set the game over flag to true.
            isGameOver = true;

            // Check if the game has already finished to avoid duplicate messages.
            if (isFinish)
            {
                // Stop the timer and display the result message.
                miniGameTick.Stop();
                MessageBox.Show(message);
            }

            // Check if the game result is a lose.
            if (!isFinish)
            {
                // Play the lose sound effect and set the finish flag to true.
                soundPlayer.Stream = MiniGameQuizResources.lose;
                soundPlayer.Play();
                isFinish = true;

                // Stop the timer and display the result message.
                miniGameTick.Stop();
                MessageBox.Show(message);
            }

            // Check if the game result is a lose.
            else if (!isFinish && message == "You Lose!")
            {
                // Play the lose sound effect and set the finish and game over flags to true.
                soundPlayer.Stream = MiniGameQuizResources.lose;
                soundPlayer.Play();
                isFinish = true;
                isGameOver = true;

                // Stop the timer and display the result message.
                miniGameTick.Stop();
                MessageBox.Show(message);
            }

            // Close the QuizGameForm.
            QuizGameForm.form.CloseForm();
        }

        // Method to update the game timer and check for game end conditions.
        public void GameFormTimer()
        {
            // Update the game timer.
            totalTime--;

            // Update the labels displaying the remaining time and questions left to answer.
            LblTimer.Text = $"Time Left: {totalTime}";
            LblRightAnsLeft.Text = $"Questions Left to Answer: {currScore}";
        }

        // Event handler for the game timer tick event.
        public void GameActions(object sender, EventArgs e)
        {
            // Check if the game has not finished.
            if (!isFinish)
            {
                // Log the remaining time.
                Console.WriteLine(totalTime);

                // Update the game timer.
                GameFormTimer();

                // Check if the time has run out and the game has not finished.
                if (totalTime == 0 && !isFinish)
                {
                    // Stop the timer and display the result message.
                    CGFormTimerStop("You Lose!");
                }
            }
        }
    }
}

