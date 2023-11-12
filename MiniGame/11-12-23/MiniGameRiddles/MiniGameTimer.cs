using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MiniGameRiddles
{
    internal class MiniGameTimer : TimerInfo
    {
        public System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Label time = timerLabel;

        public static bool isFinish = false;

        public void RiddleTimerStart()
        {
            if (!isFinish)
            {
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Tick += TimerAction;
                timer.Start();

            }
        }

        public void RiddleTimerStop(string msg)
        {
            gameOver = true;
            if (!isFinish)
            {
                isFinish = true;
                timer.Stop();
                MessageBox.Show(msg);

            }
            
            if (!isFinish && msg == "You Failed the Challenge!")
            {
                isFinish = true;
                gameOver = true;
                timer.Stop();
                MessageBox.Show(msg);
            }

            
            RiddleForm.form.Close();
            //RiddleForm.Instance.CloseForm();
        }

        public void RiddleTimerUpdate()
        {
            gameTimer = gameTimer - 1;
            timerLabel.Text = $"Time Left: {gameTimer}";
        }

        public void TimerAction(object sender, EventArgs e)
        {
            RiddleTimerUpdate();

            if (gameTimer == 0)
            {
                RiddleTimerStop("You Failed the Challenge!");
            }
        }



    }
}
