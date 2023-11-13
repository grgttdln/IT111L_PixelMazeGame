using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Level2
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel Level2_MainPanel { get; set; }


        //public static Player player = new Player();
        public Player GetPlayer { get { return NewGame.player; } }



        Timer level2Timer = new Timer();
        PlayerMovement movement = new PlayerMovement();
        Coin gems = new Coin();
        Enemy enemy = new Enemy();
        Wall wall = new Wall();
        Trap trap = new Trap();
        Key key = new Key();
        Door door = new Door();

        public Label[] enemiesCollection = new Label[5];
        public int[] enemiesSpeedCollection = new int[5];

        public Label[] wallsCollection = new Label[20];


        // setting time
        public static GameTimeMain level2_TimeMain = new GameTimeMain(180);

        public Level2()
        {
            // LEVEL 2 MAIN PANEL
            Level2_MainPanel = new Panel
            {
                Name = "Level2Panel",
                Text = "Level2",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            
        }

        public void LoadLevel2()
        {
            Console.WriteLine("Level 2 Loaded");
            
            NewGame.level_1.Level1_MainPanel.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();


            GetPanelMainMenu.Controls.Add(Level2_MainPanel);

            Level2_MainPanel.Focus();

            Level2_MainPanel.Controls.Add(GetPlayer.PlayerGame);


            // stats
            Level2_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);

            Level2_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);


            Label trap_1 = trap.CreateTrap_1(500, 500);
            Label trap_2 = trap.CreateTrap_2(500, 600);
            Label trap_3 = trap.CreateTrap_3(500, 400);

            Level2_MainPanel.Controls.Add(trap_1);
            Level2_MainPanel.Controls.Add(trap_2);
            Level2_MainPanel.Controls.Add(trap_3);


            Label enemy_1 = enemy.CreateEnemy_1(300, 350);
            Label enemy_2 = enemy.CreateEnemy_2(680, 350);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;

            Level2_MainPanel.Controls.Add(enemy_1);

            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 2;

            Level2_MainPanel.Controls.Add(enemy_2);

            Label[] coin_H1 = gems.CoinFbFHoriz(100, 100);
            foreach (Label c in coin_H1)
            {
                Level2_MainPanel.Controls.Add(c);
            }

            Label[] coin_V1 = gems.CoinFbFVerti(100, 130);
            foreach (Label c in coin_V1)
            {
                Level2_MainPanel.Controls.Add(c);
            }



            Level2_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level2_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level2Timer.InitializeComponentLevel();

            Level2_MainPanel.Controls.Add(level2_TimeMain.TimeDisplay);
            level2_TimeMain.InitializeComponentLevel();


        }


    }
}
