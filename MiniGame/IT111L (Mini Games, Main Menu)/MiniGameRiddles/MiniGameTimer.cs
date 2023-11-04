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

        public void RiddleTimerStart()
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += TimerAction;
            timer.Start();
        }

        public void RiddleTimerStop(string msg)
        {
            gameOver = true;
            timer.Stop();
            MessageBox.Show(msg);

            RiddleForm.Instance.CloseForm();
        }

        public void RiddleTimerUpdate()
        {
            gameTimer--;
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
