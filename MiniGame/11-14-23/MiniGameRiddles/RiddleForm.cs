using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FontGameCollection;

namespace MiniGameRiddles
{
    internal class RiddleForm : Form
    {
        public RiddleElements elements;

        public RiddleLogic rLogic;

        public static int currentLevel;
        
        public static MiniGameTimer timer = new MiniGameTimer();

        public static RiddleForm form;

        public RiddleForm(int level)
        {
            currentLevel = level;


            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Pixel Quest Mini Game: Riddles";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = RiddleResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            elements = new RiddleElements(this);
            rLogic = new RiddleLogic(this, elements);

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            form = this;
            this.FormClosed += RiddleForm_FormClosed;

            AddElements();


        }

        public void AddElements()
        {
            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(elements.QuestionLabel);
            this.Controls.Add(elements.answerTextBox);
            this.Controls.Add(elements.submitButton);
            this.Controls.Add(timer.time);
        }

        private static RiddleForm instance;

        public static RiddleForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RiddleForm(currentLevel);
                }
                return instance;
            }
        }


        public void CloseForm()
        {
            this.Close();
        }

        private void RiddleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            TimerInfo.gameTimer = 46;
            MiniGameTimer.isFinish = false;
        }
    }
}
