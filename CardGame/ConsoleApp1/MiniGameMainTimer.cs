using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class MiniGameMainTimer : CardGameInfo
    {
        public System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();

        public Label time = LblTimer;

        public void CGFormTimerStart()
        {
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        public void CGFormTimerStop(string message)
        {
            gameOver = true;
            miniGameTick.Stop();
            MessageBox.Show(message);
        }


        public void GameFormTimer()
        {
            totalTime--;
            LblTimer.Text = $"Time Left: {totalTime}";
        }

        public bool isWinner;

     
        public void GameActions(object sender, EventArgs e)
        {
            GameFormTimer();

            if (totalTime < 0)
            {
                CGFormTimerStop("Loser"); 

                foreach (PictureBox x in cardPicturesCollection)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                    }
                }
            }            
        }
    }
}
