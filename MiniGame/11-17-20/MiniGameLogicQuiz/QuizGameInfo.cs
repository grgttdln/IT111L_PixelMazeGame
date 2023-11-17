using FontGameCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameLogicQuiz
{
    internal class QuizGameInfo
    {

        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public static bool isGameOver = false;
        public static bool isWin = false;
        public static int currScore = -1;

        public static int totalTime = 31;
        public static Button[] qChoice;

        public static string[] questions;
        public static int questionPoolLeft;

        public static int noOfQuesToAns;

        public static ArrayList choiceAL = new ArrayList();
        public static ArrayList questionsAL = new ArrayList();
        public static ArrayList answersAL = new ArrayList();
        public static ArrayList arrRandAL = new ArrayList();


        private static string correctAnswer;

        public static string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public static Label lblTimer = new Label
        {
            Size = new Size(150, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(85, 50),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblTimer
        {
            get { return lblTimer; }
            set { lblTimer = value; }
        }

        private static Label lblRightAnsLeft = new Label
        {
            Size = new Size(320, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(420, 50),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblRightAnsLeft
        {
            get { return lblRightAnsLeft; }
            set { lblRightAnsLeft = value; }
        }

    }
}
