﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameCardMemory
{
    internal class CardGameInfo
    {

        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public static List<PictureBox> cardPicturesCollection = new List<PictureBox>();
        public static int totalTime = 15;
        
        public static bool gameOver;

        public List<int> numbers;
        public static int currGameLevel;


        public static Label lblTimer = new Label
        {
            Size = new Size(200, 200),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(0, 50)
        };

        public static Label LblTimer
        {
            get { return lblTimer; }
            set { lblTimer = value; }
        }

    }
}
