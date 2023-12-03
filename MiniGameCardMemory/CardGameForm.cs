using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameWindow;
using System.Reflection.Emit;

// The CardGameForm class represents the main form for the Card Memory Game mini-game.
namespace MiniGameCardMemory
{
    // CardGameForm is derived from the Form class.
    internal class CardGameForm : Form
    {
        // Static variable to store the current player's level.
        public static int currentPlayerLevel;

        // Instance of the MiniGameMainTimer class responsible for timing and game-related messages.
        MiniGameMainTimer timer = new MiniGameMainTimer();

        // Instance of the CardGameElements class containing elements specific to the Card Memory Game.
        public CardGameElements elements;

        // Static reference to the current instance of the CardGameForm.
        public static CardGameForm form;

        // Constructor for CardGameForm, taking the current level as a parameter.
        public CardGameForm(int level)
        {
            // Initialize the current player's level.
            currentPlayerLevel = level;

            // Set up the main properties and appearance of the form.
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

            // Set the static reference to this instance.
            form = this;

            // Attach the event handler for when the form is closed.
            this.FormClosed += CardGameForm_FormClosed;

            // Add the form elements related to the Card Memory Game.
            AddFormElements();
        }

        // Method to add form elements, initialize game-related variables, and load pictures for the Card Memory Game.
        public void AddFormElements()
        {
            // Initialize the game state variables.
            CardGameInfo.isWin = false;
            CardGameElements elements = new CardGameElements(this);

            // Add the CardGameElements' components to the form.
            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(timer.cardsMatch);
            this.Controls.Add(timer.time);

            // Load pictures for the Card Memory Game.
            elements.LoadPictures();
        }

        // Static instance property that ensures there is only one instance of CardGameForm at a time.
        private static CardGameForm instance;

        public static CardGameForm Instance
        {
            get
            {
                // If there is no instance, create a new one with the current player's level.
                if (instance == null)
                {
                    instance = new CardGameForm(currentPlayerLevel);
                }
                return instance;
            }
        }

        // Method to close the form and reset relevant game state variables when the form is closed.
        public void CloseForm()
        {
            this.Close();
        }

        // Event handler for when the form is closed, triggering a reset of game state variables.
        private void CardGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetForm();
        }

        // Method to reset game state variables when the form is closed.
        private void ResetForm()
        {
            CardGameInfo.totalTime = 16;
            CardGameInfo.totalCards = 0;
            CardGameInfo.cardPicturesCollection = new List<PictureBox>();
            CardGameInfo.gameOver = false;
        }
    }
}

