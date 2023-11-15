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
    internal class TrapLogic
    {
        public static GameInfo gInfo = new GameInfo();

        private Random random = new Random();


        public bool TrapMiniGameRandomizer()
        {
            bool isEscape = false;
            int randomMiniGame = random.Next(0, 4);

     
            Console.WriteLine(randomMiniGame);

            switch (randomMiniGame)
            {
                case 0:
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

        public void TrapPauseFunction()
        {
            //level1Timer.PauseGameTimer();
            //Timer.gameMainTimer.Stop();
            NewGame.level_1.Level1_MainPanel.Focus();
            Program.gInfo.Pause = true;

        }

        public void GameContinueFunction()
        {
            //level1Timer.ContPauseGameTimer();
            //Timer.gameMainTimer.Start();
            NewGame.level_1.Level1_MainPanel.Focus();
            Program.gInfo.Pause = false;

        }
    }
}
