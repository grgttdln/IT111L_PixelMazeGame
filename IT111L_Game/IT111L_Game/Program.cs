using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameCardMemory;

namespace IT111L_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain();

            miniGameCard.CardGameMainDisplay();
            //MiniGameCardMemory.CardGameForm cgf = new MiniGameCardMemory.CardGameForm();

            //Application.Run(cgf);

        }
    }
}
