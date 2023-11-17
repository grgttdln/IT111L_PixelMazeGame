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
using MiniGameRiddles;
using MiniGameRPS;
using FontGameCollection;

namespace IT111L_Game
{
    internal class Program
    {
        //static public int level = 1;

        public static GameInfo gInfo = new GameInfo();



        static void Main(string[] args)
        {

            //Uncomment to run the Main Menu Window

            PixelGameMain game = new PixelGameMain(gInfo.Level);
            game.MiniGameMainDisplay();



            //Uncomment to run the Randomizer

            //Program program = new Program();
            //bool isEscape = program.MiniGameRandomizer();

            //Console.WriteLine($"{isEscape} program main");


            /*
            //Uncomment to run the Logic Quiz only
            MiniGameLogicQuiz.QuizGameMain miniGameQuiz = new MiniGameLogicQuiz.QuizGameMain(gInfo.Level);
            miniGameQuiz.MiniGameMainDisplay();
            */

            /*
            //Uncomment to run the Card Game only
            MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain(gInfo.Level);
            miniGameCard.MiniGameMainDisplay();
            */

            /*
            //Uncomment to run the Riddles only
            MiniGameRiddles.RiddleMain miniGameRiddles = new MiniGameRiddles.RiddleMain(gInfo.Level);
            miniGameRiddles.MiniGameMainDisplay();
            */

            /*
            //Uncomment to run the RPS only
            MiniGameRPS.RPSMain miniGameRPS = new MiniGameRPS.RPSMain(gInfo.Level);
            miniGameRPS.MiniGameMainDisplay();
            */



            Console.WriteLine("The program is still running");
            Console.ReadLine();
        }
    }
}
