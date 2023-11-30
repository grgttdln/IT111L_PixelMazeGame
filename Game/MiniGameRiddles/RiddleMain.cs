using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;

// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The RiddleMain class extends MiniGameForm and serves as the entry point for the riddle mini-game.
    public class RiddleMain : MiniGameWindow.MiniGameForm
    {
        // Constructor for RiddleMain, taking the level as a parameter and calling the base constructor.
        public RiddleMain(int level) : base(level)
        {
            // No additional logic in the constructor.
        }

        // Override of the MiniGameMainDisplay method from the base class.
        public override void MiniGameMainDisplay()
        {
            // Create an instance of the RiddleForm for the current level.
            RiddleForm riddleGame = new RiddleForm(Level);

            // Display the RiddleForm as a modal dialog.
            riddleGame.ShowDialog();

            // Update the IsWin property based on the result of the riddle mini-game.
            IsWin = TimerInfo.isWin;
        }
    }
}
