﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IT111L_Game
{
    // Internal class representing an Enemy with methods for creating two types of enemy labels
    internal class Enemy
    {
        private Label enemy_1, enemy_2;
        
        // Method to create an enemy label of type 1 at the specified coordinates(x, y)
        public Label CreateEnemy_1(int x, int y)
        {
            enemy_1 = new Label
            {
                Name = "enemy",
                Size = new Size(50, 64),
                Location = new Point(x, y),
                Tag = "enemySide",
                Image = Resources.enemy_1,
                BackColor = Color.Transparent,
            };
            return enemy_1;
        }

        // Method to create an enemy label of type 2 at the specified coordinates (x, y)
        public Label CreateEnemy_2(int x, int y)
        {
            enemy_2 = new Label
            {
                Name = "enemy",
                Size = new Size(50, 72),
                Location = new Point(x, y),
                Tag = "enemyUp",
                Image = Resources.enemy_2,
                BackColor = Color.Transparent,
            };
            return enemy_2;
        }
    }
}
