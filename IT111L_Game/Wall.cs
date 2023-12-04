using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    // Handles the creation of wall elements in the game.
    internal class Wall
    {
        private Label wall_horizontal, wall_vertical;

        // Creates a horizontal wall segment facing upward.
        public Label CreateWallHorizontalUp(int x, int y)
        {
            wall_horizontal = new Label
            {
                Name = "wallHorizontal",
                Tag = "wall",
                Size = new Size(97, 70),
                Location = new Point(x, y),
                Image = Resources.wall_horizontal,
            };
            return wall_horizontal;
        }

        // Creates a vertical wall segment facing left.
        public Label CreateWallVerticalLeft(int x, int y)
        {
            wall_vertical = new Label
            {
                Name = "wallVertical",
                Tag = "wall",
                Size = new Size(19, 99),
                Location = new Point(x, y),
                Image = Resources.wall_vertical,
            };
            return wall_vertical;
        }

        // Creates a long horizontal wall segment facing upward.
        public Label CreateWallLongHorizontalUp(int x, int y)
        {
            wall_horizontal = new Label
            {
                Name = "wallHorizontal",
                Tag = "wall",
                Size = new Size(194, 70),
                Location = new Point(x, y),
                Image = Resources.wall_horizontal_long,
            };
            return wall_horizontal;
        }

        // Creates a long vertical wall segment facing left.
        public Label CreateWallLongVerticalLeft(int x, int y)
        {
            wall_vertical = new Label
            {
                Name = "wallVertical",
                Tag = "wall",
                Size = new Size(19, 198),
                Location = new Point(x, y),
                Image = Resources.wall_vertical_long,
            };
            return wall_vertical;
        }
    }
}
