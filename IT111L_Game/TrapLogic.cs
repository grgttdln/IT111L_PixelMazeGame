using MiniGameCardMemory;
using MiniGameLogicQuiz;
using MiniGameRiddles;
using MiniGameRPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IT111L_Game
{
    // Handles the logic for traps in the game.
    internal class TrapLogic
    {
        public static GameInfo gInfo = new GameInfo();

        private Random random = new Random();

        // Randomly selects a mini-game when triggered by a trap.
        public bool TrapMiniGameRandomizer()
        {
            bool isEscape = false;
            int randomMiniGame = random.Next(0, 4);

     
            Console.WriteLine(randomMiniGame);

            switch (randomMiniGame)
            {
                case 0:
                    // Quiz mini-game
                    QuizGameMain miniGameQuiz = new QuizGameMain(Program.gInfo.Level);
                    miniGameQuiz.MiniGameMainDisplay();
                    isEscape = miniGameQuiz.IsWin;

                    if (isEscape)
                    {
                        Program.gInfo.Score += 5;
                    }
                    else
                    {
                        GameTimeMain.gameTime -= 15;
                    }

                    miniGameQuiz = null;

                    break;
                case 1:
                    // Card mini-game
                    CardGameMain miniGameCard = new CardGameMain(Program.gInfo.Level);
                    miniGameCard.MiniGameMainDisplay();
                    isEscape = miniGameCard.IsWin;

                    if (isEscape)
                    {
                        Program.gInfo.Score += 3;
                    }
                    else
                    {
                        GameTimeMain.gameTime -= 15;
                    }

                    miniGameCard = null;

                    break;
                case 2:
                    // Riddle mini-game
                    RiddleMain miniGameRiddles = new RiddleMain(Program.gInfo.Level);
                    miniGameRiddles.MiniGameMainDisplay();
                    isEscape = miniGameRiddles.IsWin;

                    if (isEscape)
                    {
                        Program.gInfo.Score += 4;
                    }
                    else
                    {
                        GameTimeMain.gameTime -= 15;
                    }

                    miniGameRiddles = null;

                    break;
                case 3:
                    // Rock-Paper-Scissors mini-game
                    RPSMain miniGameRPS = new RPSMain(Program.gInfo.Level);
                    miniGameRPS.MiniGameMainDisplay();
                    isEscape = miniGameRPS.IsWin;

                    if (isEscape)
                    {
                        Program.gInfo.Score += 2;
                    }
                    else
                    {
                        GameTimeMain.gameTime -= 15;
                    }

                    miniGameRPS = null;

                    break;
            }
            return isEscape;
        }

        // Pauses the game when triggered by a trap.
        public void TrapPauseFunction()
        {
            Program.gInfo.Pause = true;
        }

        // Resumes the game after a pause triggered by a trap.
        public void GameContinueFunction()
        {
            Program.gInfo.Pause = false;
        }
    }
}
