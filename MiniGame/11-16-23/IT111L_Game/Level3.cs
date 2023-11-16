using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IT111L_Game
{
    internal class Level3
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel Level3_MainPanel { get; set; }


        public Player GetPlayer { get { return NewGame.player; } }


        Timer level3Timer = new Timer();
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
        //public static GameTimeMain level3_TimeMain = new GameTimeMain(240);




        public static GameTimeMain level3_TimeMain = new GameTimeMain(240);

        public static GameTimeMain Level_TimeMain
        {
            get { return level3_TimeMain; }
            set { level3_TimeMain = value; }
        }




        public Level3()
        {
            // LEVEL 2 MAIN PANEL
            Level3_MainPanel = new Panel
            {
                Name = "Level3Panel",
                Text = "Level3",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };


        }

        public void LoadLevel3()
        {
            Console.WriteLine("Level 3 Loaded");

            NewGame.level_2.Level2_MainPanel.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();


            GetPanelMainMenu.Controls.Add(Level3_MainPanel);

            Level3_MainPanel.Focus();

            Level3_MainPanel.Controls.Add(GetPlayer.PlayerGame);


            // stats
            Level3_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);

            Level3_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);



            Label trap_1 = trap.CreateTrap_1(1000, 500);
            Label trap_2 = trap.CreateTrap_2(1000, 600);
            Label trap_3 = trap.CreateTrap_3(1000, 400);

            Level3_MainPanel.Controls.Add(trap_1);
            Level3_MainPanel.Controls.Add(trap_2);
            Level3_MainPanel.Controls.Add(trap_3);


            Label enemy_1 = enemy.CreateEnemy_1(300, 350);
            Label enemy_2 = enemy.CreateEnemy_2(680, 350);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;

            Level3_MainPanel.Controls.Add(enemy_1);


            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 2;

            Label key_1 = key.createKey(600, 300);

            Level3_MainPanel.Controls.Add(key_1);

            Label door_1 = door.createDoor(600, 700);

            Level3_MainPanel.Controls.Add(door_1);



            Level3_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level3_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level3Timer.InitializeComponentLevel();

            Level3_MainPanel.Controls.Add(level3_TimeMain.TimeDisplay);
            level3_TimeMain.InitializeComponentLevel();
        }
    }
}
