using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// The MiniGameForm class serves as a base class for mini-game forms within the game window.
namespace MiniGameWindow
{
    // MiniGameForm encapsulates common properties and behavior for mini-games.
    public class MiniGameForm
    {
        // Property to store and access the current level of the mini-game.
        public int Level { get; set; }

        // Property to indicate whether the mini-game has been won.
        public bool IsWin { get; set; }

        // Constructor for MiniGameForm, taking the current level as a parameter.
        public MiniGameForm(int lvl)
        {
            Level = lvl;
            IsWin = false;
        }

        // Virtual method that can be overridden by derived classes to display the main content of the mini-game.
        public virtual void MiniGameMainDisplay()
        {
            // Empty by default, to be overridden by specific mini-game implementations.
        }
    }
}
