using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;

namespace MiniGameRiddles
{
    public class RiddleMain : MiniGameWindow.MiniGameForm
    {
        public RiddleMain(int level) : base(level)
        {

        }

        public override void MiniGameMainDisplay()
        {
            RiddleForm riddleGame = new RiddleForm(Level);
            riddleGame.ShowDialog();
            IsWin = TimerInfo.isWin;
        }


    }
}
