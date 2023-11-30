using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The TimerInfo class holds information related to the timer in the riddle mini-game.
    internal class TimerInfo
    {
        // FontGame instance for managing fonts in the timer label.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // Initial value for the game timer.
        public static int gameTimer = 46;

        // Flag indicating whether the game is over.
        public static bool gameOver;

        // Flag indicating whether the player has won the game.
        public static bool isWin = false;

        // Label to display the timer in the game interface.
        public static Label timerLabelField = new Label
        {
            Size = new Size(200, 200),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(0, 350),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };

        // Property to access the timer label.
        public static Label timerLabel
        {
            get { return timerLabelField; }
            set { timerLabelField = value; }
        }
    }
}
