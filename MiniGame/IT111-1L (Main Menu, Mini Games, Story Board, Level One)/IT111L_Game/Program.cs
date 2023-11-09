﻿using System;
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

namespace IT111L_Game
{
    internal class Program
    {
        static public int level = 1;
        
        private Random random = new Random();
        
        public bool MiniGameRandomizer()
        {
            bool isEscape = false;
            int randomMiniGame = random.Next(0, 4);

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

                case 2:
                    MiniGameRiddles.RiddleMain miniGameRiddles = new MiniGameRiddles.RiddleMain(level);
                    miniGameRiddles.MiniGameMainDisplay();
                    isEscape = miniGameRiddles.IsWin;
                    break;
                
                case 3:
                    MiniGameRPS.RPSMain miniGameRPS = new MiniGameRPS.RPSMain(level);
                    miniGameRPS.MiniGameMainDisplay();
                    isEscape = miniGameRPS.IsWin;
                    break;

            }

            return isEscape;
        }
        
        
        static void Main(string[] args)
        {
            
            //Uncomment to run the Main Menu Window
            PixelGameMain game = new PixelGameMain(level);
            game.MiniGameMainDisplay();
            

            
            //Uncomment to run the Randomizer

            //Program program = new Program();
            //bool isEscape = program.MiniGameRandomizer();

            //Console.WriteLine($"{isEscape} program main");
            

            /*
            //Uncomment to run the Logic Quiz only
            MiniGameLogicQuiz.QuizGameMain miniGameQuiz = new MiniGameLogicQuiz.QuizGameMain(level);
            miniGameQuiz.MiniGameMainDisplay();
            */

            /*
            //Uncomment to run the Card Game only
            MiniGameCardMemory.CardGameMain miniGameCard = new MiniGameCardMemory.CardGameMain(level);
            miniGameCard.MiniGameMainDisplay();
            */


            /*
            //Uncomment to run the Riddles only
            MiniGameRiddles.RiddleMain miniGameRiddles = new MiniGameRiddles.RiddleMain(level);
            miniGameRiddles.MiniGameMainDisplay();
            */

            /*
            //Uncomment to run the RPS only
            MiniGameRPS.RPSMain miniGameRPS = new MiniGameRPS.RPSMain(level);
            miniGameRPS.MiniGameMainDisplay();
            */



            Console.WriteLine("The program is still running");
            Console.ReadLine();
        }
    }
}
