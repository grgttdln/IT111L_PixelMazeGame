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

        private Label scoreDisplay, lifeDisplay;
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
                Location = new Point(50, 20),
                Size = new Size(200, 25),
                Font = new Font(fontGame.pfc.Families[0], 25),
            };

            lifeDisplay = new Label
            {
                Text = "Life: ",
                Location = new Point(50, 70),
                Size = new Size(200, 25),
                Font = new Font(fontGame.pfc.Families[0], 25),
            };
        }

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
