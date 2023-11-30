using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FontGameCollection;

// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The RiddleForm class extends Form and represents the main form for the riddle mini-game.
    internal class RiddleForm : Form
    {
        // Instance of RiddleElements containing visual elements and logic for the riddle mini-game.
        public RiddleElements elements;

        // Instance of RiddleLogic for handling game logic.
        public RiddleLogic rLogic;

        // Static variable to store the current level of the riddle mini-game.
        public static int currentLevel;

        // Static instance of MiniGameTimer for managing the game timer.
        public static MiniGameTimer timer = new MiniGameTimer();

        // Static instance of the RiddleForm itself.
        public static RiddleForm form;

        // Constructor for RiddleForm, taking the current level as a parameter.
        public RiddleForm(int level)
        {
            // Set the current level and initialize the MiniGameTimer's win flag to false.
            currentLevel = level;
            MiniGameTimer.isWin = false;

            // Set form properties.
            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Pixel Quest Mini Game: Riddles";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = RiddleResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Initialize RiddleElements and RiddleLogic instances.
            elements = new RiddleElements(this);
            rLogic = new RiddleLogic(this, elements);

            // Set additional form properties.
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            // Set the static form instance and wire up the FormClosed event.
            form = this;
            this.FormClosed += RiddleForm_FormClosed;

            // Add visual elements to the form.
            AddElements();
        }

        // Method to add visual elements to the form.
        public void AddElements()
        {
            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(elements.QuestionLabel);
            this.Controls.Add(elements.answerTextBox);
            this.Controls.Add(elements.submitButton);
            this.Controls.Add(timer.time);
        }

        // Static instance of RiddleForm, ensuring only one instance is created.
        private static RiddleForm instance;

        // Property to get the static instance of RiddleForm.
        public static RiddleForm Instance
        {
            get
            {
                // If the instance is null, create a new instance with the current level.
                if (instance == null)
                {
                    instance = new RiddleForm(currentLevel);
                }
                return instance;
            }
        }

        // Method to close the form.
        public void CloseForm()
        {
            this.Close();
        }

        // Event handler for the FormClosed event.
        private void RiddleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reset the form properties when the form is closed.
            ResetForm();
        }

        // Method to reset the form properties.
        private void ResetForm()
        {
            TimerInfo.gameTimer = 46;
            MiniGameTimer.isFinish = false;
        }
    }
}
