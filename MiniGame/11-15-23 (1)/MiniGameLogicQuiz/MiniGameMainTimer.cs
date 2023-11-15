using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MiniGameLogicQuiz
{
    internal class MiniGameMainTimer : QuizGameInfo
    {
        public System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();
        
        public Label time = QuizGameInfo.LblTimer;
        public Label questionssLeft = QuizGameInfo.LblRightAnsLeft;

        public bool isFinish = false;

        public void CGFormTimerStart()
        {
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        public void CGFormTimerStop(string message)
        {
            QuizGameInfo.isGameOver = true;
           
            if (!isFinish)
            {
                isFinish = true;
                if (QuizGameInfo.isGameOver)
                {
                    miniGameTick.Stop();

                    MessageBox.Show(message);

                    QuizGameForm.form.CloseForm();
                }
            }
            //// else if -> if
            else if (!isFinish && message == "You Lose!")
            {
                miniGameTick.Stop();

                MessageBox.Show(message);

                QuizGameForm.form.CloseForm();
            }

            miniGameTick.Stop();
        }

        public void GameFormTimer()
        {
            totalTime--;
            LblTimer.Text = $"Time Left: {totalTime}";
            LblRightAnsLeft.Text = $"Questions Left to Answer: {currScore}";
        }

        public void GameActions(object sender, EventArgs e)
        {
            GameFormTimer();

            if (QuizGameInfo.isGameOver == true)
            {
                QuizGameInfo.isWin = true;
                questionssLeft.Text = $"Questions Left to Answer: 0";
                miniGameTick.Stop();
            }


            if (totalTime == 0)
            {
                miniGameTick.Stop();
                CGFormTimerStop("You Lose!");
                QuizGameForm.form.CloseForm();
            }
        }
    }
}
