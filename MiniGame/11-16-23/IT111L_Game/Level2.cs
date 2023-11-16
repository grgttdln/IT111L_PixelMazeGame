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
        Teleporter teleporter = new Teleporter();
        public Label[] enemiesCollection = new Label[5];
        public int[] enemiesSpeedCollection = new int[5];

        public Label[] wallsCollection = new Label[20];


        // setting time
        //public static GameTimeMain level2_TimeMain = new GameTimeMain(180);



        public static GameTimeMain level2_TimeMain = new GameTimeMain(180);

        public static GameTimeMain Level_TimeMain
        {
            get { return level2_TimeMain; }
            set { level2_TimeMain = value; }
        }




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
            GetPlayer.PlayerGame.Left = 0;
            GetPlayer.PlayerGame.Top = 20;


            // stats
            Level2_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);

            Level2_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);


            Label trap_1 = trap.CreateTrap_1(1000, 500);
            Label trap_2 = trap.CreateTrap_2(1000, 600);
            Label trap_3 = trap.CreateTrap_3(1000, 400);

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

            Label key_1 = key.createKey(600, 300);

            Level2_MainPanel.Controls.Add(key_1);

            Label door_1 = door.createDoor(600, 700);

            Level2_MainPanel.Controls.Add(door_1);

            // wall

            wallsCollection[0] = wall.CreateWallVerticalLeft(250, 250);
            wallsCollection[1] = wall.CreateWallVerticalLeft(250, 250 + 97);

            wallsCollection[2] = wall.CreateWallVerticalRight(444, 250);
            wallsCollection[3] = wall.CreateWallVerticalRight(444, 250 + 97);

            wallsCollection[4] = wall.CreateWallHorizontalUp(250, 250);
            wallsCollection[5] = wall.CreateWallHorizontalUp(250 + 97, 250);


            wallsCollection[6] = wall.CreateWallHorizontalUp(650, 250);


            wallsCollection[7] = wall.CreateWallVerticalRight(830, 250);
            wallsCollection[8] = wall.CreateWallVerticalRight(830, 250 + 97);

            wallsCollection[9] = wall.CreateWallVerticalRight(830, 250 + 97 + 97);
            wallsCollection[10] = wall.CreateWallVerticalRight(830, 250 + 97 + 97 + 97);

            wallsCollection[11] = wall.CreateWallHorizontalUp(650 + 97, 250);

            wallsCollection[12] = wall.CreateWallHorizontalUp(650, 570);
            wallsCollection[13] = wall.CreateWallHorizontalUp(650 + 97, 570);





            for (int i = 0; i < 14; i++)
            {
                Level2_MainPanel.Controls.Add(wallsCollection[i]);
            }


            //teleporter
            Label teleporter_entry = teleporter.createTeleporterEntry(200, 500);
            Label teleporter_exit = teleporter.createTeleporterExit(1050, 700);

            Level2_MainPanel.Controls.Add(teleporter_entry);

            Level2_MainPanel.Controls.Add(teleporter_exit);




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
