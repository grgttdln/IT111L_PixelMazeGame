using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// The CardGameInfo class holds information and UI elements related to the state of the Card Memory Game.
namespace MiniGameCardMemory
{
    internal class CardGameInfo
    {
        // Instance of the FontGameCollection class for managing fonts in the game.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // Collection to store the PictureBoxes representing cards in the game.
        public static List<PictureBox> cardPicturesCollection = new List<PictureBox>();

        // Total time allowed for the game.
        public static int totalTime = 16;

        // Total number of cards in the game.
        public static int totalCards = 0;

        // Flag indicating whether the game is over.
        public static bool gameOver;

        // Flag indicating whether the player has won the game.
        public static bool isWin = false;

        // List of numbers used for generating card pairs.
        public List<int> numbers;

        // Current game level.
        public static int currGameLevel;

        // Label displaying the remaining time in the game.
        private static Label lblTimer = new Label
        {
            Size = new Size(150, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(85, 50),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblTimer
        {
            get { return lblTimer; }
            set { lblTimer = value; }
        }

        // Label displaying the number of matched cards in the game.
        private static Label lblMatchedCards = new Label
        {
            Size = new Size(250, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(475, 50),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblMatchedCards
        {
            get { return lblMatchedCards; }
            set { lblMatchedCards = value; }
        }
    }
}

