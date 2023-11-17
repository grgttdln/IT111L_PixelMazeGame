using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class GameInfo
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        private Label scoreDisplay, lifeDisplay, scoreIcon, lifeIcon, timeIcon, levelTitle_1, levelTitle_2, levelTitle_3;
        private int score, life, level, playerSpeed;
        private bool pause;

        public GameInfo()
        {
            level = 1;
            life = 5;
            score = 0;
            pause = false;
            playerSpeed = 5;

            scoreDisplay = new Label
            {
                Text = "Score: ",
                Location = new Point(105, 20),
                Size = new Size(150, 25),
                Font = new Font(fontGame.pfc.Families[0], 25),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };

            lifeDisplay = new Label
            {
                Text = "Life: ",
                Location = new Point(105, 70),
                Size = new Size(150, 25),
                Font = new Font(fontGame.pfc.Families[0], 25),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };

            scoreIcon = new Label
            {
                Image = Resources.coin_header,
                Location = new Point(50, 20),
                Size = new Size(40, 34),
                BackColor = Color.Transparent
            };

            lifeIcon = new Label
            {
                Image = Resources.life_header,
                Location = new Point(50, 70),
                Size = new Size(40, 34),
                BackColor = Color.Transparent
            };

            timeIcon = new Label
            {
                Image = Resources.time_header,
                Location = new Point(950, 20),
                Size = new Size(40, 39),
                BackColor = Color.Transparent
            };

            levelTitle_1 = new Label
            {
                Text = "Dungeon Dive: Beginner's Bliss",
                Location = new Point(270, 30),
                Size = new Size(680, 50),
                Font = new Font(fontGame.pfc.Families[1], 24),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };

            levelTitle_2 = new Label
            {
                Text = "Conquer Subterra:\nLabyrinth Mastery",
                Location = new Point(260, 25),
                Size = new Size(680, 100),
                Font = new Font(fontGame.pfc.Families[1], 22),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };

            levelTitle_3 = new Label
            {
                Text = "Deceptive Depths:\nTriumph Over Dungeon Traps",
                Location = new Point(260, 25),
                Size = new Size(680, 100),
                Font = new Font(fontGame.pfc.Families[1], 22),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        public Label ScoreIcon { get { return scoreIcon; } }
        public Label TimeIcon { get { return timeIcon; } }
        public Label LifeIcon { get { return lifeIcon; } }
        public Label LevelTitle_1 { get { return levelTitle_1; } }
        public Label LevelTitle_2 { get { return levelTitle_2; } }
        public Label LevelTitle_3 { get { return levelTitle_3; } }


        public int PlayerSpeed
        {
            get { return playerSpeed; }
        }

        public bool Pause
        {
            get { return pause; }
            set { pause = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public Label LifeDisplay
        {
            get { return lifeDisplay; }
            set { lifeDisplay = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Label ScoreDisplay
        {
            get { return scoreDisplay; }
            set { scoreDisplay = value; }
        }


    }
}
