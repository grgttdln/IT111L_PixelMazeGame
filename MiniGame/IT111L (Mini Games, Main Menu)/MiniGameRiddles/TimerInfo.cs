using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MiniGameRiddles
{
    internal class TimerInfo
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public static int gameTimer = 46;

        public static bool gameOver;

        public static bool isWin = false;

        public static Label timerLabelField = new Label
        {
            Size = new Size(200, 200),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(0, 350),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };

        public static Label timerLabel
        {
            get { return timerLabelField; }
            set { timerLabelField = value; }
        }

    }
}
