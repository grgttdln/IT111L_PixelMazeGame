using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Level1
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel Level1_MainPanel { get; set; }
        //public Label LvlTitle { get; set; }


        private Button pauseBtn;


        public Level1 () 
        {
            // LEVEL 1 MAIN PANEL
            Level1_MainPanel = new Panel
            {
                Name = "Level1Panel",
                Text = "Level1",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            /*
            LvlTitle = new Label
            {
                Text = "Sample Text - Level 1",
                Location = new Point(0, 0),
                Size = new Size(200, 20),

            };
            */

            /*
            pauseBtn = new Button
            {
                Tag = "pause",
                Text = "pause",
                Size = new Size(100, 100),
                Location = new Point(0, 300),
            };

            pauseBtn.Click += Level1BtnPauseFunction;

            */
        }


        //public static Player player = new Player();

        public Player GetPlayer { get { return NewGame.player; } }


        Timer level1Timer = new Timer();
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

        public Label[] wallsCollection = new Label[100];


        // setting time
        //public static GameTimeMain level1_TimeMain = new GameTimeMain(120);



        public static GameTimeMain level1_TimeMain = new GameTimeMain(120);

        public static GameTimeMain Level_TimeMain
        {
            get { return level1_TimeMain; }
            set { level1_TimeMain = value; }
        }



        //public bool isCollided = false;





        public void LoadLevel1()
        {
            Console.WriteLine("Level 1 Loaded");
            GetPanelMainMenu.Controls.Clear();




            GetPanelMainMenu.Controls.Add(Level1_MainPanel);

            // btn pause
            //Level1_MainPanel.Controls.Add(pauseBtn);

            Level1_MainPanel.Focus();




            Level1_MainPanel.Controls.Add(GetPlayer.PlayerGame);




            // stats
            Level1_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);

            Level1_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);



            // trap - done
            Label trap_1 = trap.CreateTrap_1(270, 280);
            Label trap_2 = trap.CreateTrap_2(805, 360);
            Label trap_3 = trap.CreateTrap_3(800, 210);
            Label trap_4 = trap.CreateTrap_3(920, 590);
            Label trap_5 = trap.CreateTrap_3(405, 605);

            Level1_MainPanel.Controls.Add(trap_1);
            Level1_MainPanel.Controls.Add(trap_2);
            Level1_MainPanel.Controls.Add(trap_3);
            Level1_MainPanel.Controls.Add(trap_4);
            Level1_MainPanel.Controls.Add(trap_5);



            // key - done
            Label key_1 = key.createKey(585, 555);
            Level1_MainPanel.Controls.Add(key_1);



            // door - done
            Label door_1 = door.createDoor(1065, 215);
            Level1_MainPanel.Controls.Add(door_1);



            //teleporter - done
            Label teleporter_entry = teleporter.createTeleporterEntry(65, 555);
            Label teleporter_exit = teleporter.createTeleporterExit(680, 350);

            Level1_MainPanel.Controls.Add(teleporter_entry);
            Level1_MainPanel.Controls.Add(teleporter_exit);




            // enemy
            Label enemy_1 = enemy.CreateEnemy_1(945, 445);
            Label enemy_2 = enemy.CreateEnemy_2(685, 510);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;

            Level1_MainPanel.Controls.Add(enemy_1);

            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 2;

            Level1_MainPanel.Controls.Add(enemy_2);
            



            // wall
            // 0-1
            wallsCollection[6] = wall.CreateWallVerticalLeft(10, 135);
            wallsCollection[0] = wall.CreateWallLongVerticalLeft(10, 230);
            wallsCollection[1] = wall.CreateWallLongVerticalLeft(10, 427);
            wallsCollection[2] = wall.CreateWallVerticalLeft(10, 625);

            // 3-5
            wallsCollection[8] = wall.CreateWallVerticalLeft(1150, 135);
            wallsCollection[3] = wall.CreateWallLongVerticalLeft(1150, 230);
            wallsCollection[4] = wall.CreateWallLongVerticalLeft(1150, 427);
            wallsCollection[5] = wall.CreateWallVerticalLeft(1150, 625);

            // 6-8
            wallsCollection[7] = wall.CreateWallHorizontalUp(10, 135); // left up
            wallsCollection[9] = wall.CreateWallHorizontalUp(1055, 135); // right up
            wallsCollection[10] = wall.CreateWallHorizontalUp(10, 655); // left down
            wallsCollection[11] = wall.CreateWallHorizontalUp(1055, 655);


            // up horizontal wall
            wallsCollection[12] = wall.CreateWallLongHorizontalUp(100, 135);
            wallsCollection[13] = wall.CreateWallLongHorizontalUp(190, 135);
            wallsCollection[14] = wall.CreateWallLongHorizontalUp(280, 135);
            wallsCollection[15] = wall.CreateWallLongHorizontalUp(370, 135);
            wallsCollection[16] = wall.CreateWallLongHorizontalUp(460, 135);

            wallsCollection[17] = wall.CreateWallLongHorizontalUp(550, 135);
            wallsCollection[18] = wall.CreateWallLongHorizontalUp(640, 135);
            wallsCollection[19] = wall.CreateWallLongHorizontalUp(730, 135);

            wallsCollection[20] = wall.CreateWallLongHorizontalUp(820, 135);
            wallsCollection[21] = wall.CreateWallLongHorizontalUp(910, 135);


            // down horizontal wall

            wallsCollection[22] = wall.CreateWallLongHorizontalUp(100, 655);
            wallsCollection[23] = wall.CreateWallLongHorizontalUp(190, 655);
            wallsCollection[24] = wall.CreateWallLongHorizontalUp(280, 655);
            wallsCollection[25] = wall.CreateWallLongHorizontalUp(370, 655);
            wallsCollection[26] = wall.CreateWallLongHorizontalUp(460, 655);

            wallsCollection[27] = wall.CreateWallLongHorizontalUp(550, 655);
            wallsCollection[28] = wall.CreateWallLongHorizontalUp(640, 655);
            wallsCollection[29] = wall.CreateWallLongHorizontalUp(730, 655);

            wallsCollection[30] = wall.CreateWallLongHorizontalUp(820, 655);
            wallsCollection[31] = wall.CreateWallLongHorizontalUp(910, 655);



            // wall bodyyy 

            // A
            // #1
                        // FRONT
            wallsCollection[32] = wall.CreateWallLongVerticalLeft(350, 135);
            wallsCollection[33] = wall.CreateWallLongVerticalLeft(350, 225);
            wallsCollection[34] = wall.CreateWallLongVerticalLeft(350, 315);

            wallsCollection[35] = wall.CreateWallLongVerticalLeft(200, 315);
            wallsCollection[37] = wall.CreateWallLongHorizontalUp(10, 443);
            wallsCollection[36] = wall.CreateWallHorizontalUp(110, 315);



            // B
            // #2H
            wallsCollection[38] = wall.CreateWallLongHorizontalUp(465, 270);
            wallsCollection[39] = wall.CreateWallLongHorizontalUp(645, 270);
            // #2T
            wallsCollection[40] = wall.CreateWallVerticalLeft(640, 340);


            wallsCollection[41] = wall.CreateWallLongHorizontalUp(565, 440);


            wallsCollection[42] = wall.CreateWallLongVerticalLeft(565, 495);
            wallsCollection[44] = wall.CreateWallLongHorizontalUp(745, 440);

            wallsCollection[43] = wall.CreateWallVerticalLeft(925, 440);
            wallsCollection[45] = wall.CreateWallVerticalLeft(925, 465);


            /*
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

            */


            int counter = 0;
            for (int i = 0; i < 46; i++)
            {
                Level1_MainPanel.Controls.Add(wallsCollection[i]);
                if (counter == 32)
                {
                    wallsCollection[i].BringToFront();
                }
                counter++;
            }



            // coin
            Label[] coin_H1 = gems.CoinFbFHoriz(60, 240);
            foreach (Label c in coin_H1)
            {
                Level1_MainPanel.Controls.Add(c);
            }

            Label[] coin_H2 = gems.CoinFbFHoriz(185, 550);
            foreach (Label c in coin_H2)
            {
                Level1_MainPanel.Controls.Add(c);
            }


            Label[] coin_V1 = gems.CoinFbFVerti(60, 280);  
            foreach (Label c in coin_V1)
            {
                Level1_MainPanel.Controls.Add(c);
            }

            Label[] coin_V2 = gems.CoinFbFVerti(265, 350);
            foreach (Label c in coin_V2)
            {
                Level1_MainPanel.Controls.Add(c);
            }



            Level1_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level1_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level1Timer.InitializeComponentLevel();



            Level1_MainPanel.Controls.Add(level1_TimeMain.TimeDisplay);
            level1_TimeMain.InitializeComponentLevel();

        }
    }
}
