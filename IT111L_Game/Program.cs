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
        public static GameInfo gInfo = new GameInfo();

        static void Main(string[] args)
        {
            PixelGameMain game = new PixelGameMain(gInfo.Level);
            game.MiniGameMainDisplay();

            Console.ReadLine();
        }
    }
}
