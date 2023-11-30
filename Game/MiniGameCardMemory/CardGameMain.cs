using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Emit;
using MiniGameWindow;

// The CardGameMain class represents the main entry point for the Card Memory Game.
namespace MiniGameCardMemory
{
    public class CardGameMain : MiniGameWindow.MiniGameForm
    {
        // Constructor that takes the game level as a parameter.
        public CardGameMain(int level) : base(level)
        {

        }

        // Implementation of the abstract method for displaying the main content of the mini-game.
        public override void MiniGameMainDisplay()
        {
            // Create an instance of the CardGameForm.
            CardGameForm cardGame = new CardGameForm(Level);

            // Display the CardGameForm as a dialog.
            cardGame.ShowDialog();

            // Set the IsWin property based on the game outcome.
            IsWin = CardGameInfo.isWin;
        }
    }
}