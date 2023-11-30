using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;


// The QuizGameMain class represents the main entry point for the Quiz Game within the mini-game framework.
// It inherits from the MiniGameForm class to integrate seamlessly with the overall mini-game structure.
namespace MiniGameLogicQuiz
{
    public class QuizGameMain : MiniGameWindow.MiniGameForm
    {
        // Constructor for QuizGameMain that takes the player's level as a parameter.
        public QuizGameMain(int level) : base(level)
        {

        }

        // Override of the MiniGameMainDisplay method, responsible for displaying the Quiz Game form.
        public override void MiniGameMainDisplay()
        {
            // Create an instance of QuizGameForm with the specified player level.
            QuizGameForm quizGame = new QuizGameForm(Level);

            // Show the Quiz Game form as a dialog, ensuring interaction with the game.
            quizGame.ShowDialog();

            // Update the IsWin property based on the game outcome.
            IsWin = QuizGameInfo.isWin;
        }
    }
}

