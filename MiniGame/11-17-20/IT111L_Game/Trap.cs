using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Trap
    {
        private Label trap_1, trap_2, trap_3;

        public TrapLogic TrapLogic { get; private set; }

        public Label CreateTrap_1(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_1 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50), // Set the size as per your requirement
                Location = new Point(x, y), // Set the location as per your requirement
                Image = Resources.trap, // Set the trap image
                
                //SizeMode = PictureBoxSizeMode.StretchImage

            };

            // Create an instance of TrapLogic
            TrapLogic = new TrapLogic();

            return trap_1;
            
        }

        public Label CreateTrap_2(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_2 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50), // Set the size as per your requirement
                Location = new Point(x, y), // Set the location as per your requirement
                Image = Resources.trap, // Set the trap image
                //SizeMode = PictureBoxSizeMode.StretchImage

            };

            // Create an instance of TrapLogic
            TrapLogic = new TrapLogic();

            return trap_2;

        }

        public Label CreateTrap_3(int x, int y)
        {
            // Initialize the PictureBox for the trap
            trap_3 = new Label
            {
                Name = "trap",
                Tag = "trap",
                Size = new Size(50, 50), // Set the size as per your requirement
                Location = new Point(x, y), // Set the location as per your requirement
                Image = Resources.trap, // Set the trap image
                //SizeMode = PictureBoxSizeMode.StretchImage

            };

            // Create an instance of TrapLogic
            TrapLogic = new TrapLogic();

            return trap_3;

        }


    }
}
