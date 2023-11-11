using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameWindow;

namespace MiniGameLogicQuiz
{
    internal class QuizGameForm : Form
    {
        public QuizGameElements elements;
        public QuizGameLogic gameLogic = new QuizGameLogic();
        MiniGameMainTimer timer = new MiniGameMainTimer();

        

        

        public static int currentPlayerLevel;
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

            gameLogic.LoadQuiz();
            timer.CGFormTimerStart();
            gameLogic.ShuffleQuestionPick();
            AddFormElements();
        }

        public void AddFormElements()
        {
            QuizGameElements elements = new QuizGameElements(this);

            // form
            this.Controls.Add(elements.QuizMiniTitle);
            this.Controls.Add(QuizGameElements.PanelForm);

            // pannel
            QuizGameElements.PanelForm.Controls.Add(QuizGameElements.QuizQuestion);
            QuizGameElements.PanelForm.Controls.Add(timer.time);
            QuizGameElements.PanelForm.Controls.Add(QuizGameElements.QuizQuestion);
            QuizGameElements.QuizQuestion.BringToFront();
        }

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

        public void CloseForm()
        {
            Application.ExitThread();
        }
    }
}
