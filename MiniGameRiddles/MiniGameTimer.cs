using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Media;

// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The MiniGameTimer class extends TimerInfo and represents the timer functionality for the riddle mini-game.
    internal class MiniGameTimer : TimerInfo
    {
        // SoundPlayer instance for playing sound effects.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Static instance of System.Windows.Forms.Timer for managing the game timer.
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        // Label displaying the remaining time in the riddle mini-game.
        public Label time = timerLabel;

        // Property to get and set the static timer instance.
        public static Timer GetTimer
        {
            get { return MiniGameTimer.timer; }
            set { MiniGameTimer.timer = value; }
        }

        // Flag indicating whether the riddle mini-game has finished.
        public static bool isFinish = false;

        // Method to start the riddle timer.
        public void RiddleTimerStart()
        {
            // Check if the game has not finished.
            if (!isFinish)
            {
                // Configure timer properties.
                timer.Interval = 1000;
                timer.Enabled = true; // Ensure timer.Enabled is set to true
                timer.Tick -= TimerAction;
                timer.Tick += TimerAction;
                // Call RiddleTimerUpdate() outside the event handler to ensure consistent decrement
                timer.Start();
            }
        }

        // Method to stop the riddle timer and display a message.
        public void RiddleTimerStop(string msg)
        {
            // Set the game over flag to true.
            gameOver = true;

            // Check if the game has finished.
            if (isFinish)
            {
                timer.Stop();
                MessageBox.Show(msg);
            }
            // Check if the game has not finished.
            else if (!isFinish)
            {
                isFinish = true;
                timer.Stop();
                MessageBox.Show(msg);
            }
            // Check if the game has not finished and the message indicates failure.
            else if (!isFinish && msg == "You Failed the Challenge!")
            {
                isFinish = true;
                gameOver = true;
                timer.Stop();
                MessageBox.Show(msg);
            }

            // Close the associated RiddleForm.
            RiddleForm.form.Close();
        }

        // Method to update the riddle timer's display.
        public void RiddleTimerUpdate()
        {
            // Decrement the game timer.
            gameTimer--;

            // Update the timer label text.
            timerLabel.Text = $"Time Left: {gameTimer}";
        }

        // Event handler for the timer's Tick event.
        public void TimerAction(object sender, EventArgs e)
        {
            // Check if the game has not finished.
            if (!isFinish)
            {
                // Update the riddle timer.
                RiddleTimerUpdate();

                // Check if the time has run out and the game has not finished.
                if (gameTimer == 0 && !isFinish)
                {
                    // Play a losing sound effect.
                    soundPlayer.Stream = RiddleResources.lose;
                    soundPlayer.Play();

                    // Stop the timer and display a failure message.
                    RiddleTimerStop("You Failed the Challenge!");
                }
            }
        }
    }
}
