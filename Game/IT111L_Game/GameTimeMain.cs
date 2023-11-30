using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontGameCollection;

namespace IT111L_Game
{
    // Internal class representing the main game timer and time display
    internal class GameTimeMain
    {
        static public System.Windows.Forms.Timer gameMainTimer = new System.Windows.Forms.Timer();
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        static public int gameTime = 0;
        int minutes, seconds;


        // Constructor to initialize the total game time
        public GameTimeMain(int time)
        {
            gameTime = time;
        }


        // Label to display the remaining time
        private Label timeDisplay = new Label
        {
            Text = "",
            Location = new Point(1000, 20),
            Size = new Size(200, 25),
            Font = new Font(fontGame.pfc.Families[0], 25),
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };


        // Property to get and set the time display label
        public Label TimeDisplay
        {
            get { return timeDisplay; }
            set { timeDisplay = value; }
        }


        // Method to initialize the timer component and start the countdown
        public void InitializeComponentLevel()
        {
            gameMainTimer.Interval = 1000;
            gameMainTimer.Enabled = true;
            gameMainTimer.Tick += GameTimer_Tick;
            gameMainTimer.Start();
        }


        // Event handler for the game timer tick
        public void GameTimer_Tick(object sender, EventArgs e)
        {
            // Calculate minutes and seconds from the remaining game time
            minutes = gameTime / 60;
            seconds = gameTime % 60;

            gameTime--;
            timeDisplay.Text = $"Time : {minutes:D2}:{seconds:D2}";
            //Console.WriteLine(gameTime);
        }


        // Method to stop the game timer
        public void StopTimer()
        {
            gameMainTimer.Stop();
            gameMainTimer.Tick -= GameTimer_Tick;
            TimeDisplay.Text = $"Time : 00:00";  
        }
    }
}
