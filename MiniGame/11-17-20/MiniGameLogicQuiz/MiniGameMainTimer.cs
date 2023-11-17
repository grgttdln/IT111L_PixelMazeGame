using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;


namespace MiniGameLogicQuiz
{
    internal class MiniGameMainTimer : QuizGameInfo
    {
        public static System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();

        private SoundPlayer soundPlayer = new SoundPlayer();
        public Label time = QuizGameInfo.LblTimer;
        public Label questionssLeft = QuizGameInfo.LblRightAnsLeft;

        public bool isFinish = false;

        public static Timer GetTimer
        {
            get { return miniGameTick; }
            set { miniGameTick = value; }
        }

        public void CGFormTimerStart()
        {
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick -= GameActions;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        public void CGFormTimerStop(string message)
        {
            isGameOver = true;

            if (isFinish)
            {
                miniGameTick.Stop();
                MessageBox.Show(message);
            }


            if (!isFinish)
            {
                soundPlayer.Stream = MiniGameQuizResources.lose;
                soundPlayer.Play();
                isFinish = true;
                miniGameTick.Stop();
                MessageBox.Show(message);

                    
                
            }
            //// else if -> if
            else if (!isFinish && message == "You Lose!")
            {
                soundPlayer.Stream = MiniGameQuizResources.lose;
                soundPlayer.Play();
                isFinish = true;
                isGameOver = true;
                miniGameTick.Stop();
                MessageBox.Show(message);
                
            }

            QuizGameForm.form.CloseForm();
        }

        public void GameFormTimer()
        {
            totalTime--;
            LblTimer.Text = $"Time Left: {totalTime}";
            LblRightAnsLeft.Text = $"Questions Left to Answer: {currScore}";
        }

        public void GameActions(object sender, EventArgs e)
        {
            if (!isFinish)
            {
                Console.WriteLine(totalTime);
                GameFormTimer();

                if (totalTime == 0 && !isFinish)
                {
                    
                    CGFormTimerStop("You Lose!");
                }
            }
        }
    }
}
