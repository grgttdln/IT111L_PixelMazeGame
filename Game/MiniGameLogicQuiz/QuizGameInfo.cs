using FontGameCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// The QuizGameInfo class manages information related to the Quiz Game.
namespace MiniGameLogicQuiz
{
    internal class QuizGameInfo
    {
        // FontGame instance for font-related properties.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // Flags indicating game status.
        public static bool isGameOver = false;
        public static bool isWin = false;

        // Current player score.
        public static int currScore = -1;

        // Total time for each question.
        public static int totalTime = 31;

        // Array to store question choices.
        public static Button[] qChoice;

        // Arrays to store questions, remaining question pool, and the number of questions to answer.
        public static string[] questions;
        public static int questionPoolLeft;
        public static int noOfQuesToAns;

        // ArrayLists to store choices, questions, answers, and shuffled question indices.
        public static ArrayList choiceAL = new ArrayList();
        public static ArrayList questionsAL = new ArrayList();
        public static ArrayList answersAL = new ArrayList();
        public static ArrayList arrRandAL = new ArrayList();

        // Correct answer for the current question.
        private static string correctAnswer;

        public static string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        // Label for displaying the remaining time.
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

        // Label for displaying the number of questions left to answer.
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
