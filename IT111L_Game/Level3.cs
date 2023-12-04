using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace IT111L_Game
{
    internal class Level3
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        private SoundPlayer soundPlayer = new SoundPlayer();
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

        public Label[] wallsCollection = new Label[100];


        // setting time
        public static GameTimeMain level3_TimeMain = new GameTimeMain(240);

        public static GameTimeMain Level_TimeMain
        {
            get { return level3_TimeMain; }
            set { level3_TimeMain = value; }
        }


        public Level3()
        {
            Level3_MainPanel = new Panel
            {
                // LEVEL 3 MAIN PANEL
                Name = "Level3Panel",
                Text = "Level3",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackgroundImage = Resources.maze_bg,
                BackgroundImageLayout = ImageLayout.Stretch
            };
        }

        public void LoadLevel3()
        {
            soundPlayer.Stream = Resources.load_next;
            soundPlayer.Play();


            //NewGame.level_2.Level2_MainPanel.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();


            GetPanelMainMenu.Controls.Add(Level3_MainPanel);

            Level3_MainPanel.Focus();

            // Game Player
            Level3_MainPanel.Controls.Add(GetPlayer.PlayerGame);
            GetPlayer.PlayerGame.Left = 55;
            GetPlayer.PlayerGame.Top = 215;


            // Game Title
            Level3_MainPanel.Controls.Add(Program.gInfo.LevelTitle_3);


            // Game Status
            Level3_MainPanel.Controls.Add(Program.gInfo.LifeIcon);
            Level3_MainPanel.Controls.Add(Program.gInfo.ScoreIcon);
            Level3_MainPanel.Controls.Add(Program.gInfo.TimeIcon);
            Level3_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);
            Level3_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);


            // Key Creation and Placement 
            Label key_1 = key.createKey(770, 525);
            Level3_MainPanel.Controls.Add(key_1);


            // Door Creation and Placement 
            Label door_1 = door.createDoor(1080, 215);
            Level3_MainPanel.Controls.Add(door_1);


            // Coins Creation and Placement
            // Horizontal Coins
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(195, 480), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(150, 615), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(370, 615), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(585, 255), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(760, 390), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(915, 580), Level3_MainPanel);

            // Vertical Coins
            gems.AddCoinsToPanel(gems.CoinFbFVerti(255, 290), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(450, 385), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(515, 290), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(70, 470), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(110, 470), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(635, 445), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(965, 420), Level3_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(1040, 420), Level3_MainPanel);


            // Traps Creation and Placement
            Label[] traps = new Label[5];

            Label trap_1 = trap.CreateTrap_1(237, 320);
            Label trap_2 = trap.CreateTrap_2(505, 380);
            Label trap_3 = trap.CreateTrap_3(835, 600);
            Label trap_4 = trap.CreateTrap_3(835, 540);
            Label trap_5 = trap.CreateTrap_3(770, 530);

            traps[0] = trap_1;
            traps[1] = trap_2;
            traps[2] = trap_3;
            traps[3] = trap_4;
            traps[4] = trap_5;

            for (int i = 0; i < traps.Length; i++)
            {
                Level3_MainPanel.Controls.Add(traps[i]);

                traps[i].SendToBack();
            }



            // Enemy Creation and Placement
            Label enemy_1 = enemy.CreateEnemy_1(620, 460);
            Label enemy_2 = enemy.CreateEnemy_2(810, 220);
            Label enemy_3 = enemy.CreateEnemy_1(1040, 460);
            Label enemy_4 = enemy.CreateEnemy_2(920, 255);
            Label enemy_5 = enemy.CreateEnemy_1(935, 315);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;
            Level3_MainPanel.Controls.Add(enemy_1);

            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 3;
            Level3_MainPanel.Controls.Add(enemy_2);

            enemiesCollection[2] = enemy_3;
            enemiesSpeedCollection[2] = 7;
            Level3_MainPanel.Controls.Add(enemy_3);

            enemiesCollection[3] = enemy_4;
            enemiesSpeedCollection[3] = 4;
            Level3_MainPanel.Controls.Add(enemy_4);

            enemiesCollection[4] = enemy_5;
            enemiesSpeedCollection[4] = 6;
            Level3_MainPanel.Controls.Add(enemy_5);


            // Teleporter Creation and Placement 
            Label teleporter_entry = teleporter.createTeleporterEntry(135, 385);
            Label teleporter_exit = teleporter.createTeleporterExit(660, 585);

            Level3_MainPanel.Controls.Add(teleporter_entry);
            Level3_MainPanel.Controls.Add(teleporter_exit);



            // Wall Creation and Placement
            // Box
            wallsCollection[6] = wall.CreateWallVerticalLeft(10, 135);
            wallsCollection[0] = wall.CreateWallLongVerticalLeft(10, 230);
            wallsCollection[1] = wall.CreateWallLongVerticalLeft(10, 427);
            wallsCollection[2] = wall.CreateWallVerticalLeft(10, 625);

            wallsCollection[8] = wall.CreateWallVerticalLeft(1150, 135);
            wallsCollection[3] = wall.CreateWallLongVerticalLeft(1150, 230);
            wallsCollection[4] = wall.CreateWallLongVerticalLeft(1150, 427);
            wallsCollection[5] = wall.CreateWallVerticalLeft(1150, 625);

            wallsCollection[7] = wall.CreateWallHorizontalUp(10, 135); // left up
            wallsCollection[9] = wall.CreateWallHorizontalUp(1055, 135); // right up
            wallsCollection[10] = wall.CreateWallHorizontalUp(10, 655); // left down
            wallsCollection[11] = wall.CreateWallHorizontalUp(1055, 655);


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

            //H1
            wallsCollection[32] = wall.CreateWallLongHorizontalUp(28, 305);

            //H2
            wallsCollection[33] = wall.CreateWallLongHorizontalUp(300, 305);

            //H3
            wallsCollection[36] = wall.CreateWallLongHorizontalUp(560, 305);

            //H4
            wallsCollection[39] = wall.CreateWallLongHorizontalUp(345, 530);
            wallsCollection[40] = wall.CreateWallLongHorizontalUp(155, 530);

            //H5
            wallsCollection[42] = wall.CreateWallHorizontalUp(740, 455);

            //V1
            wallsCollection[34] = wall.CreateWallVerticalLeft(204, 355);

            //V3
            wallsCollection[35] = wall.CreateWallVerticalLeft(410, 360);

            //V4
            wallsCollection[37] = wall.CreateWallVerticalLeft(560, 360);

            //V5
            wallsCollection[38] = wall.CreateWallVerticalLeft(540, 455);

            //V6
            wallsCollection[41] = wall.CreateWallLongVerticalLeft(740, 527);

            int counter = 0;
            for (int i = 0; i < 42; i++)
            {
                Level3_MainPanel.Controls.Add(wallsCollection[i]);
                if (counter == 30 || counter == 31 || counter == 20 || counter == 21)
                {
                    wallsCollection[i].BringToFront();
                }
                counter++;
            }



            Level3_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level3_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level3Timer.InitializeComponentLevel();

            Level3_MainPanel.Controls.Add(level3_TimeMain.TimeDisplay);
            level3_TimeMain.InitializeComponentLevel();
        }
    }
}
