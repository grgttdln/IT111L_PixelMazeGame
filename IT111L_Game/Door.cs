using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    // Internal class representing a Door with a method for creating a door label
    internal class Door
    {
        // Method to create a door label at the specified coordinates (x, y)
        private Label door;
        public Label createDoor(int x, int y)
        {
            door = new Label
            {
                Name = "door",
                Tag = "door",
                Size = new Size(70, 70),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                Image = Resources.door
            };

            return door;
        }
    }
}
