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
        public static int totalTime = 16;
        public static int totalCards = 0;
        
        public static bool gameOver;
        public static bool isWin = false;

        public List<int> numbers;
        public static int currGameLevel;


        private static Label lblTimer = new Label
        {
            Size = new Size(150, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(85, 50), 
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblTimer
        {
            get { return lblTimer; }
            set { lblTimer = value; }
        }

        private static Label lblMatchedCards = new Label
        {
            Size = new Size(250, 50),
            Font = new Font(fontGame.pfc.Families[0], 25),
            Location = new Point(475, 50),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.White,
            BackColor = Color.Transparent,
        };

        public static Label LblMatchedCards
        {
            get { return lblMatchedCards; }
            set { lblMatchedCards = value; }
        }

    }
}
