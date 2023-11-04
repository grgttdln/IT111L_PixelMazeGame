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
        
        private Random random = new Random();

        public bool MiniGameRandomizer()
        {
            bool isEscape = false;
            int randomMiniGame = random.Next(0, 2);

            Console.WriteLine(randomMiniGame);

            switch (randomMiniGame)
            {
                case 0:
                    MiniGameLogicQuiz.QuizGameMain miniGameQuiz = new MiniGameLogicQuiz.QuizGameMain(level);
                    miniGameQuiz.MiniGameMainDisplay();
                    isEscape = miniGameQuiz.IsWin;
                    break;
                case 1:
                    MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain(level);
                    miniGameCard.MiniGameMainDisplay();
                    isEscape = miniGameCard.IsWin;
                    break;
            }

            return isEscape;
        }

        
        static void Main(string[] args)
        {

            PixelGameMain game = new PixelGameMain(level);
            game.MiniGameMainDisplay();



            /*
            Program program = new Program();
            bool isEscape = program.MiniGameRandomizer();

            Console.WriteLine($"{isEscape} program main");
            */

            /*
            MiniGameLogicQuiz.QuizGameMain miniGameQuiz = new MiniGameLogicQuiz.QuizGameMain(level);
            miniGameQuiz.MiniGameMainDisplay();
            */

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
