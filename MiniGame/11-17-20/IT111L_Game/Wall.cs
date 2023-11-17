using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Wall
    {
        private Label wall_horizontal, wall_vertical;

        /*
        public Label CreateWallHorizontal(int x, int y)
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

        public Label CreateWallHorizontalLong(int x, int y)
        {
            wall_horizontal = new Label
            {
                Name = "wallHorizontal",
                Tag = "wall",
                Size = new Size(97, 70),
                Location = new Point(x, y),
                Image = Resources.wall_horizontal_long,
            };
            return wall_horizontal;
        }


        public Label CreateWallVertical(int x, int y)
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

        public Label CreateWallVerticalLong(int x, int y)
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




        */

















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

        public Label CreateWallVerticalRight(int x, int y)
        {
            wall_vertical = new Label
            {
                Name = "wallVertical",
                Tag = "wall",
                Size = new Size(19, 99),
                Location = new Point(x, y),
                Image = Resources.wall_verticalR,
            };
            return wall_vertical;
        }

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

        public Label CreateWallLongVerticalRight(int x, int y)
        {
            wall_vertical = new Label
            {
                Name = "wallVertical",
                Tag = "wall",
                Size = new Size(19, 198),
                Location = new Point(x, y),
                Image = Resources.wall_verticalR,
            };
            return wall_vertical;
        }

    }
}
