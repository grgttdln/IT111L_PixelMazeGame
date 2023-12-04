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
    internal class Level2
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        private SoundPlayer soundPlayer = new SoundPlayer();
        public Panel Level2_MainPanel { get; set; }

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

        public Label[] wallsCollection = new Label[100];


        // Setting Time
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
                BackgroundImage = Resources.maze_bg,
                BackgroundImageLayout = ImageLayout.Stretch
            };
        }

        public void LoadLevel2()
        {
            soundPlayer.Stream = Resources.load_next;
            soundPlayer.Play();

            
            NewGame.level_1.Level1_MainPanel.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();


            GetPanelMainMenu.Controls.Add(Level2_MainPanel);


            Level2_MainPanel.Focus();

            // Game Player
            Level2_MainPanel.Controls.Add(GetPlayer.PlayerGame);
            GetPlayer.PlayerGame.Left = 90;
            GetPlayer.PlayerGame.Top = 215;



            // Game Title
            Level2_MainPanel.Controls.Add(Program.gInfo.LevelTitle_2);



            // Game Status
            Level2_MainPanel.Controls.Add(Program.gInfo.LifeIcon);
            Level2_MainPanel.Controls.Add(Program.gInfo.ScoreIcon);
            Level2_MainPanel.Controls.Add(Program.gInfo.TimeIcon);
            Level2_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);
            Level2_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);



            // Traps Creation and Placement
            Label[] traps = new Label[5];
            Label trap_1 = trap.CreateTrap_1(580, 215);
            Label trap_2 = trap.CreateTrap_2(580, 385);
            Label trap_3 = trap.CreateTrap_3(1045, 380);
            Label trap_4 = trap.CreateTrap_3(1080, 530);
            Label trap_5 = trap.CreateTrap_3(405, 605);

            traps[0] = trap_1;
            traps[1] = trap_2;
            traps[2] = trap_3;
            traps[3] = trap_4;
            traps[4] = trap_5;

            for (int i = 0; i < traps.Length; i++)
            {
                Level2_MainPanel.Controls.Add(traps[i]);

                traps[i].SendToBack();
            }



            // Enemy Creation and Placement
            Label enemy_1 = enemy.CreateEnemy_1(300, 350);
            Label enemy_2 = enemy.CreateEnemy_2(300, 350);
            Label enemy_3 = enemy.CreateEnemy_1(705, 350);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;

            Level2_MainPanel.Controls.Add(enemy_1);

            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 2;

            Level2_MainPanel.Controls.Add(enemy_2);

            enemiesCollection[2] = enemy_3;
            enemiesSpeedCollection[2] = 5;

            Level2_MainPanel.Controls.Add(enemy_3);



            // Key Creation and Placement 
            Label key_1 = key.createKey(920, 590);
            Level2_MainPanel.Controls.Add(key_1);



            // Door Creation and Placement 
            Label door_1 = door.createDoor(1075, 210);
            Level2_MainPanel.Controls.Add(door_1);



            // Wall Creation and Placement
            //BOX
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
            wallsCollection[50] = wall.CreateWallHorizontalUp(10, 280);
            wallsCollection[32] = wall.CreateWallLongHorizontalUp(75, 280);
            wallsCollection[33] = wall.CreateWallLongHorizontalUp(265, 280);
            wallsCollection[34] = wall.CreateWallLongHorizontalUp(445, 280);
            wallsCollection[35] = wall.CreateWallLongHorizontalUp(595, 280);
            wallsCollection[36] = wall.CreateWallLongHorizontalUp(780, 280);
            wallsCollection[37] = wall.CreateWallHorizontalUp(970, 280);

            //H3
            wallsCollection[41] = wall.CreateWallLongHorizontalUp(75, 490);
            wallsCollection[42] = wall.CreateWallLongHorizontalUp(265, 490);
            wallsCollection[43] = wall.CreateWallLongHorizontalUp(445, 490);
            wallsCollection[44] = wall.CreateWallLongHorizontalUp(595, 490);
            wallsCollection[45] = wall.CreateWallLongHorizontalUp(780, 490);
            wallsCollection[46] = wall.CreateWallHorizontalUp(970, 490);

            //V1
            wallsCollection[38] = wall.CreateWallVerticalLeft(975, 300);


            //V3
            wallsCollection[39] = wall.CreateWallVerticalLeft(1050, 565);
            wallsCollection[40] = wall.CreateWallVerticalLeft(1050, 490);

            //V4
            wallsCollection[49] = wall.CreateWallVerticalLeft(75, 410);


            //V5
            wallsCollection[47] = wall.CreateWallVerticalLeft(665, 410);

            //V6
            wallsCollection[48] = wall.CreateWallVerticalLeft(520, 410);

            for (int i = 0; i < 100; i++)
            {
                Level2_MainPanel.Controls.Add(wallsCollection[i]);
            }



            // Teleporter Creation and Placement 
            Label teleporter_entry = teleporter.createTeleporterEntry(573, 430);
            Label teleporter_exit = teleporter.createTeleporterExit(1075, 580);

            Level2_MainPanel.Controls.Add(teleporter_entry);
            Level2_MainPanel.Controls.Add(teleporter_exit);



            // Coins Creation and Placement
            // Horizontal Coins

            gems.AddCoinsToPanel(gems.CoinFbFHoriz(270, 225), Level2_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(755, 225), Level2_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(850, 420), Level2_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(210, 450), Level2_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFHoriz(660, 580), Level2_MainPanel);

            // Vertical Coins
            gems.AddCoinsToPanel(gems.CoinFbFVerti(40, 400), Level2_MainPanel);
            gems.AddCoinsToPanel(gems.CoinFbFVerti(1110, 310), Level2_MainPanel);


            Level2_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level2_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level2Timer.InitializeComponentLevel();

            Level2_MainPanel.Controls.Add(level2_TimeMain.TimeDisplay);
            level2_TimeMain.InitializeComponentLevel();

        }
    }
}
