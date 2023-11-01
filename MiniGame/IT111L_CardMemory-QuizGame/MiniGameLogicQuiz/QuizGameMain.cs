using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;


namespace MiniGameLogicQuiz
{
    public class QuizGameMain : MiniGameWindow.MiniGameForm
    {
        public QuizGameMain(int level) : base(level)
        {

        }

        public override void MiniGameMainDisplay()
        {
            QuizGameForm quizGame = new QuizGameForm(Level);
            Application.Run(quizGame);
        }

    }
}
