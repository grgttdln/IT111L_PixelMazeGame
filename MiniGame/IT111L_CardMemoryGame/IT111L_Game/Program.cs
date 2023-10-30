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

        static public int level = 3;
        static void Main(string[] args)
        {
            MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain(level);
            miniGameCard.CardGameMainDisplay();

            Console.WriteLine("The program is still running");
            Console.ReadLine();
        }
    }
}
