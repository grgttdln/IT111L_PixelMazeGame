using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Emit;


namespace MiniGameCardMemory
{
    public class CardGameMain
    {
        public static int level;
        public CardGameMain(int lvl) 
        { 
            level = lvl;
        }
        
        public void CardGameMainDisplay()
        {
            CardGameForm cardGame = new CardGameForm(level);
            Application.Run(cardGame);
        }
    }
}
