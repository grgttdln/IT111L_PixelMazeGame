using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// The MiniGameRPS namespace contains classes related to a Rock, Paper, Scissors (RPS) mini-game.

namespace MiniGameRPS
{
    // The RPSForm class represents the main form of the Rock, Paper, Scissors (RPS) mini-game.
    internal class RPSForm : Form
    {
        // RPSElements instance for managing elements used in the RPS form.
        public RPSElements elements;

        // RPSLogic instance for handling the logic of the RPS game.
        public RPSLogic rpsLogic;

        // Static variable to store the current level of the RPS game.
        public static int currentLevel;

        // Constructor for RPSForm, initializing the current level and creating RPSElements.
        public RPSForm(int level)
        {
            currentLevel = level;

            elements = new RPSElements(this);

            // Set properties of the form.
            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Pixel Quest Mini Game: Rock Paper Scissors";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            // Set background image of the form.
            this.BackgroundImage = RPSResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Add elements to the form.
            AddElements();
        }

        // Method to add elements (labels, buttons, etc.) to the form.
        public void AddElements()
        {
            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(elements.SDText);
            this.Controls.Add(elements.RockButton);
            this.Controls.Add(elements.PaperButton);
            this.Controls.Add(elements.ScissorButton);
            this.Controls.Add(elements.PlayerRPS);
            this.Controls.Add(elements.CompRPS);
        }

        // Method to close the form.
        public void CloseForm()
        {
            this.Close();
        }
    }
}