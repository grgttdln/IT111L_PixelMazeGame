using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameWindow;

// The RPSMain class represents the entry point for the Rock, Paper, Scissors (RPS) mini-game.
namespace MiniGameRPS
{
    // RPSMain inherits from MiniGameWindow.MiniGameForm, providing the main functionality for the mini-game.
    public class RPSMain : MiniGameWindow.MiniGameForm
    {
        // Constructor for RPSMain, taking the current level as a parameter.
        public RPSMain(int level) : base(level)
        {

        }

        // Override of the MiniGameMainDisplay method, responsible for displaying the RPS mini-game.
        public override void MiniGameMainDisplay()
        {
            // Create an instance of RPSForm for the current level.
            RPSForm rpsGame = new RPSForm(Level);

            // Show the RPSForm as a modal dialog.
            rpsGame.ShowDialog();

            // Update the IsWin property based on the static isWin flag in the RPSLogic class.
            IsWin = RPSLogic.isWin;
        }
    }
}

