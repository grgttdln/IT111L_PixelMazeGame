using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MiniGameCardMemory
{
    public class CardGameMain
    {
        public void CardGameMainDisplay()
        {
            CardGameForm cardGame = new CardGameForm();
            Application.Run(cardGame);
        }
    }
}
