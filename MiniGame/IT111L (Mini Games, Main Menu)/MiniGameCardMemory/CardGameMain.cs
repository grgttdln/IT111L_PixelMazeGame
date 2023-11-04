using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Emit;
using MiniGameWindow;

namespace MiniGameCardMemory
{

    public class CardGameMain : MiniGameWindow.MiniGameForm
    {
        public CardGameMain(int level) : base(level)
        {
            
        }

        public override void MiniGameMainDisplay()
        {
            CardGameForm cardGame = new CardGameForm(Level);
            Application.Run(cardGame);
            IsWin = CardGameInfo.isWin;
        }
    }
}
