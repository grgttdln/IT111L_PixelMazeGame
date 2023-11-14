using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;

namespace MiniGameRPS
{
    public class RPSMain : MiniGameWindow.MiniGameForm
    {
        public RPSMain (int level) : base(level)
        {

        }

        public override void MiniGameMainDisplay()
        {
            RPSForm rpsGame = new RPSForm(Level);
            rpsGame.ShowDialog();
            IsWin = RPSLogic.isWin;
        }


    }
}
