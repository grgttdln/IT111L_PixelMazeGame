using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameWindow;
using System.Collections;

// The QuizGameForm class represents the main form for the Quiz Game.
// It manages the game elements, logic, and the appearance of the form.
namespace MiniGameLogicQuiz
{
    internal class QuizGameForm : Form
    {
        // Instance of QuizGameElements to manage visual elements.
        public QuizGameElements elements;

        // Instance of QuizGameLogic to control game logic.
        public QuizGameLogic gameLogic = new QuizGameLogic();

        // Timer for managing game time.
        public static MiniGameMainTimer timer = new MiniGameMainTimer();

        // Static instance of the QuizGameForm.
        public static QuizGameForm form;

        // Current player level for the game.
        public static int currentPlayerLevel;

        // Constructor for QuizGameForm, initializes form properties and adds elements.
        public QuizGameForm(int level)
        {
            currentPlayerLevel = level;

            this.Name = "MiniGameCardGame";
            this.Size = new Size(800, 500);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest Mini Game: Quiz Game";
            this.BackgroundImage = (Image)MiniGameQuizResources.minigame_bg;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            form = this;
            this.FormClosed += QuizGameForm_FormClosed;

            AddFormElements();
        }

        // Method to add visual elements to the form.
        public void AddFormElements()
        {
            QuizGameInfo.isWin = false;
            QuizGameElements elements = new QuizGameElements(this);

            // Add elements to the form.
            this.Controls.Add(elements.QuizMiniTitle);
            this.Controls.Add(QuizGameElements.PanelForm);

            // Add elements to the panel.
            QuizGameElements.PanelForm.Controls.Add(QuizGameElements.QuizQuestion);
            QuizGameElements.PanelForm.Controls.Add(timer.time);
            QuizGameElements.PanelForm.Controls.Add(QuizGameElements.QuizQuestion);
            QuizGameElements.QuizQuestion.BringToFront();
        }

        // Static instance of QuizGameForm for flexibility.
        private static QuizGameForm instance;

        public static QuizGameForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuizGameForm(currentPlayerLevel);
                }
                return instance;
            }
        }

        // Method to close the form and reset game-related variables.
        public void CloseForm()
        {
            this.Close();
        }

        // Event handler for when the form is closed.
        private void QuizGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetForm();
        }

        // Method to reset game-related variables.
        private void ResetForm()
        {
            QuizGameInfo.totalTime = 31;
            QuizGameInfo.isGameOver = false;
            timer.isFinish = false;
            QuizGameInfo.currScore = -1;
            QuizGameInfo.questionPoolLeft = 1;
            QuizGameInfo.noOfQuesToAns = -1;

            QuizGameInfo.choiceAL.Clear();
            QuizGameInfo.questionsAL.Clear();
            QuizGameInfo.answersAL.Clear();
            QuizGameInfo.arrRandAL.Clear();
        }
    }
}
