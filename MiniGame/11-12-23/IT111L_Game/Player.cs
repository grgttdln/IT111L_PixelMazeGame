using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Player
    {
        bool right, left, up, down;

        public Player()
        {
            right = false;
            left = false;
            up = false;
            down = false;
        }

        public PictureBox player = new PictureBox
        {
            Name = "player",
            Tag = "player",
            Size = new Size(34, 50),
            Location = new Point(200, 200),
            Image = Resources.front,
            BackColor = Color.Transparent, 
        };

        public bool PlayerRight
        {
            get { return right; }
            set { right = value; }
        }

        public bool PlayerLeft
        {
            get { return left; }
            set { left = value; }
        }

        public bool PlayerUp
        {
            get { return up; }
            set { up = value; }
        }

        public bool PlayerDown
        {
            get { return down; }
            set { down = value; }
        }

        public PictureBox PlayerGame
        {
            get { return player; }
            set { player = value; }
        }
    }

    class PlayerMovement
    {
        public Player GetPlayer { get { return Level1.player; } }

        public void Player_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                GetPlayer.PlayerRight = false;
                GetPlayer.PlayerGame.Image = Resources.front;
            }

            if (e.KeyCode == Keys.Left)
            {
                GetPlayer.PlayerLeft = false;
                GetPlayer.PlayerGame.Image = Resources.front;
            }

            if (e.KeyCode == Keys.Up)
            {
                GetPlayer.PlayerUp = false;
                GetPlayer.PlayerGame.Image = Resources.front;
            }

            if (e.KeyCode == Keys.Down)
            {
                GetPlayer.PlayerDown = false;
                GetPlayer.PlayerGame.Image = Resources.front;
            }
        }


        public void Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                GetPlayer.PlayerRight = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                GetPlayer.PlayerLeft = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                GetPlayer.PlayerUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                GetPlayer.PlayerDown = true;
            }
        }



    }
}
