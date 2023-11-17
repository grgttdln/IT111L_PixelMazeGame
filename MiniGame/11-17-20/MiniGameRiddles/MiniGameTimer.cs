using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Media;

namespace MiniGameRiddles
{
    internal class MiniGameTimer : TimerInfo
    {
        private SoundPlayer soundPlayer = new SoundPlayer();

        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Label time = timerLabel;

        public static Timer GetTimer
        {
            get { return MiniGameTimer.timer; }
            set { MiniGameTimer.timer = value; }    
        }


        public static bool isFinish = false;

        public void RiddleTimerStart()
        {
            if (!isFinish)
            {
                //gameTimer = gameTimerInitialValue;
                timer.Interval = 1000;
                timer.Enabled = true; // Ensure timer.Enabled is set to true
                timer.Tick -= TimerAction;
                timer.Tick += TimerAction;
                 // Call RiddleTimerUpdate() outside the event handler to ensure consistent decrement
                timer.Start();

            }
        }

        public void RiddleTimerStop(string msg)
        {
            gameOver = true;
            if (isFinish)
            {
                timer.Stop();
                MessageBox.Show(msg);
            }
            else if (!isFinish)
            {
                isFinish = true;
            
                timer.Stop();
                MessageBox.Show(msg);

            }
            else if (!isFinish && msg == "You Failed the Challenge!")
            {
                isFinish = true;
                gameOver = true;
                timer.Stop();
                MessageBox.Show(msg);
            }

            RiddleForm.form.Close();
        }

        public void RiddleTimerUpdate()
        {
            gameTimer--;
            timerLabel.Text = $"Time Left: {gameTimer}";
        }

        public void TimerAction(object sender, EventArgs e)
        {
            if (!isFinish)
            {
                RiddleTimerUpdate();

                if (gameTimer == 0 && !isFinish)
                {
                    soundPlayer.Stream = RiddleResources.lose;
                    soundPlayer.Play();
                    RiddleTimerStop("You Failed the Challenge!");
                }
            }
        }
    }
}
