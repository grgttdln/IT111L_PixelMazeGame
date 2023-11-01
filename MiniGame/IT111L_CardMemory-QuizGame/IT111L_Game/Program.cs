using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MiniGameCardMemory;
using MiniGameLogicQuiz;
using MiniGameWindow;

namespace IT111L_Game
{
    internal class Program
    {

        static public int level = 1;
        static void Main(string[] args)
        {
            MiniGameLogicQuiz.QuizGameMain miniGameQuiz = new MiniGameLogicQuiz.QuizGameMain(level);
            miniGameQuiz.MiniGameMainDisplay();
           

            /*
            // Mini Game Card
            MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain(level);
            miniGameCard.MiniGameMainDisplay();
            */

            Console.WriteLine("The program is still running");
            Console.ReadLine();
        }
    }
}
