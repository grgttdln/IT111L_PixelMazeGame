using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontGameCollection;
using System.CodeDom;
using MiniGameWindow;

// The QuizGameElements class manages the visual elements for the Quiz Game.
// It includes methods to set up the game panel, display quiz questions, and create choice buttons.
namespace MiniGameLogicQuiz
{
    internal class QuizGameElements
    {
        // FontGame instance for text styling.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // Reference to the QuizGameForm.
        private QuizGameForm quizGForm;

        // Instance of QuizGameLogic to control game logic.
        public QuizGameLogic QLogic;

        // Constructor for QuizGameElements, initializes the QuizGameForm and QuizGameLogic.
        public QuizGameElements(QuizGameForm form)
        {
            quizGForm = form;
            QLogic = new QuizGameLogic();
            QLogic.gameStart();
        }

        // Empty constructor for flexibility.
        public QuizGameElements()
        {
        }

        // Panel to contain the game elements.
        private static Panel panelForm = new Panel
        {
            Location = new System.Drawing.Point(0, 12),
            Name = "PanelForm",
            Size = new System.Drawing.Size(800, 450),
            BackgroundImage = MiniGameQuizResources.minigame_bg,
            BackgroundImageLayout = ImageLayout.Stretch,
            TabIndex = 0,
        };

        public static Panel PanelForm
        {
            get { return panelForm; }
            set { panelForm = value; }
        }

        // Label displaying the quiz sign.
        private static Label signQuiz = new Label
        {
            Location = new System.Drawing.Point(90, 95),
            Size = new System.Drawing.Size(600, 250),
            BackgroundImage = MiniGameQuizResources.quiz_board,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            TabIndex = 0,
        };

        public static Label SignQuiz
        {
            get { return signQuiz; }
            set { signQuiz = value; }
        }

        // Label displaying the mini title of the quiz game.
        private Label quizMiniTitle = new Label
        {
            Text = "Mini Game Trap: Quiz Blitz",
            Size = new Size(800, 50),
            Font = new Font(fontGame.pfc.Families[1], 28),
            Location = new Point(0, 0),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter,
        };

        public Label QuizMiniTitle
        {
            get { return quizMiniTitle; }
            set { quizMiniTitle = value; }
        }

        // Label displaying the current quiz question.
        private static Label quizQuestion = new Label
        {
            Text = "Question 1",
            Size = new Size(280, 100),
            Font = new Font(fontGame.pfc.Families[0], 21),
            Location = new Point(250, 120),
            ForeColor = Color.White,
            BackgroundImage = MiniGameQuizResources.quiz_board_bg,
            BackgroundImageLayout = ImageLayout.Stretch,
            TextAlign = ContentAlignment.MiddleCenter,
        };

        public static Label QuizQuestion
        {
            get { return quizQuestion; }
            set { quizQuestion = value; }
        }

        // Button representing a choice in the quiz.
        private Button choiceBtnQuiz = new Button
        {
            Text = "Choice 1",
            Size = new Size(150, 80),
            Font = new Font(fontGame.pfc.Families[0], 16),
            Location = new Point(150, 200),
            ForeColor = Color.Black,
            TextAlign = ContentAlignment.MiddleCenter,
        };

        public Button ChoiceBtnQuiz
        {
            get { return choiceBtnQuiz; }
            set { choiceBtnQuiz = value; }
        }

        // Method to add a choice button to the panel.
        public static Button AddChoiceBtnQuiz(string choice)
        {
            Button choiceButton = new Button
            {
                Text = choice,
                Tag = choice,
                Size = new Size(170, 70),
                Font = new Font(fontGame.pfc.Families[0], 20),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
            };

            return choiceButton;
        }

        // Method to display quiz question and choices on the panel.
        public void DisplayQuestion(Object obj)
        {
            if (obj is Button[] buttonArray)
            {
                int x = 30, y = 360;
                int i = 0;

                foreach (Button button in buttonArray)
                {
                    button.Location = new Point(x, y);
                    button.BackgroundImage = (Bitmap)MiniGameQuizResources.btn_2;
                    button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                    button.FlatAppearance.BorderSize = 0;

                    button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    button.FlatAppearance.MouseDownBackColor = Color.Transparent;

                    PanelForm.Controls.Add(button);
                    x += 180;
                    i++;
                }
            }
        }
    }
}
