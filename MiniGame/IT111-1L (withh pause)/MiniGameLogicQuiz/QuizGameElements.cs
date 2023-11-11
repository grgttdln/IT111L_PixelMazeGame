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

namespace MiniGameLogicQuiz
{
    internal class QuizGameElements
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        private QuizGameForm quizGForm;
        public QuizGameElements(QuizGameForm form)
        {
            quizGForm = form;
        }

        public QuizGameElements()
        {

        }


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
