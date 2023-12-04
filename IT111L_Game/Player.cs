using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    // Represents the player in the game.
    internal class Player
    {
        // Boolean flags for player movement directions
        bool right, left, up, down;

        public Player()
        {
            // Initialize movement flags
            right = false;
            left = false;
            up = false;
            down = false;
        }

        // Initialize the player PictureBox
        public PictureBox player = new PictureBox
        {
            Name = "player",
            Tag = "player",
            Size = new Size(34, 50),
            Location = new Point(145, 390),
            Image = Resources.front,
            BackColor = Color.Transparent, 
        };

        // Properties for player movement flags
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

        // PictureBox representing the player character
        public PictureBox PlayerGame
        {
            get { return player; }
            set { player = value; }
        }
    }


    // Handles player movement based on key events.
    class PlayerMovement
    {
        public Player GetPlayer { get { return NewGame.player; } }

        // Handles KeyUp event for player movement
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


        // Handles KeyDown event for player movement
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
