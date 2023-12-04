using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    // Represents a trap in the game.
    internal class Trap
    {
        private Label trap_1, trap_2, trap_3;

        public TrapLogic TrapLogic { get; private set; }


        // Creates a trap label (trap_1) at the specified location.
        public Label CreateTrap_1(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_1 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50), 
                Location = new Point(x, y), 
                Image = Resources.trap, 
            };

            TrapLogic = new TrapLogic();

            return trap_1;     
        }


        // Creates a trap label (trap_2) at the specified location.
        public Label CreateTrap_2(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_2 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50),
                Location = new Point(x, y), 
                Image = Resources.trap, 

            };

            TrapLogic = new TrapLogic();

            return trap_2;

        }

        // Creates a trap label (trap_3) at the specified location.
        public Label CreateTrap_3(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_3 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50),
                Location = new Point(x, y), 
                Image = Resources.trap,
            };

            TrapLogic = new TrapLogic();

            return trap_3;

        }
    }
}
