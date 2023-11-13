using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace IT111L_Game
{
    internal class Timer
    {
        static public System.Windows.Forms.Timer gameMainTimer = new System.Windows.Forms.Timer();
        public Panel CurrentPanel = null;
        public Player GetPlayer { get { return NewGame.player; } }

        public Label[] walls = new Label[20];
        public int[] enemySpeed = new int[5];
        public Label[] enemy = new Label[5];

        public Trap Trap { get; private set; }
        public TrapLogic traplogic { get; private set; }

        bool hasKey = false;


        public Timer()
        {
            Trap = new Trap();
            traplogic = new TrapLogic();
        }


        public GameTimeMain CurrentTimer;


        public void InitializeComponentLevel()
        {


            
            switch (Program.gInfo.Level)
            {
                case 1:
                    CurrentPanel = NewGame.level_1.Level1_MainPanel;

                    CurrentTimer = Level1.level1_TimeMain;

                    Array.Copy(NewGame.level_1.wallsCollection, walls, NewGame.level_1.wallsCollection.Length);
                    Array.Copy(NewGame.level_1.enemiesSpeedCollection, enemySpeed, NewGame.level_1.enemiesSpeedCollection.Length);
                    Array.Copy(NewGame.level_1.enemiesCollection, enemy, NewGame.level_1.enemiesCollection.Length);

                    break;
                case 2:
                    CurrentPanel = NewGame.level_2.Level2_MainPanel;
                    Array.Copy(NewGame.level_2.wallsCollection, walls, NewGame.level_2.wallsCollection.Length);
                    Array.Copy(NewGame.level_2.enemiesSpeedCollection, enemySpeed, NewGame.level_2.enemiesSpeedCollection.Length);
                    Array.Copy(NewGame.level_2.enemiesCollection, enemy, NewGame.level_2.enemiesCollection.Length);
                    break;

            }
            TimerComponent();
        }

        public void TimerComponent()
        {
            gameMainTimer.Interval = 20;
            gameMainTimer.Enabled = true;
            gameMainTimer.Tick += GameTimer_Tick;
            gameMainTimer.Start();
        }


        public void StatsDisplay()
        {
            Program.gInfo.ScoreDisplay.Text = $"Score: {Program.gInfo.Score}";
            Program.gInfo.LifeDisplay.Text = $"Life: {Program.gInfo.Life}";
        }


        public void PlayerGameWindowBounds()
        {
            // right window
            if (GetPlayer.PlayerRight && GetPlayer.PlayerGame.Left < 1135)
            {
                GetPlayer.PlayerGame.Left += 5;
                GetPlayer.PlayerGame.Image = Resources.right;
            }

            // left window
            if (GetPlayer.PlayerLeft && GetPlayer.PlayerGame.Left > 0)
            {
                GetPlayer.PlayerGame.Left -= 5;
                GetPlayer.PlayerGame.Image = Resources.left;
            }

            // top window
            if (GetPlayer.PlayerUp && GetPlayer.PlayerGame.Top > 65)
            {
                GetPlayer.PlayerGame.Top -= 5;
                GetPlayer.PlayerGame.Image = Resources.back;
            }

            // down window
            if (GetPlayer.PlayerDown && GetPlayer.PlayerGame.Top < 710)
            {
                GetPlayer.PlayerGame.Top += 5;
                GetPlayer.player.Image = Resources.front;
            }
        }


        public void GameTimer_Tick(object sender, EventArgs e)
        {
            StatsDisplay();


            if (!Program.gInfo.Pause)
            {
                foreach (Control item in CurrentPanel.Controls)
                {
                    if (item.Tag == "pause")
                    {
                        continue;
                    }
                    item.Enabled = true;
                }
            }
            else
            {
                foreach (Control item in CurrentPanel.Controls)
                {
                    if (item.Tag == "pause")
                    {
                        continue;
                    }
                    item.Enabled = false; 
                }
            }


            if (!Program.gInfo.Pause)
            {
                // right window
                if (GetPlayer.PlayerRight && GetPlayer.PlayerGame.Left < 1135)
                {
                    GetPlayer.PlayerGame.Left += Program.gInfo.PlayerSpeed;
                    GetPlayer.PlayerGame.Image = Resources.right;
                }

                // left window
                if (GetPlayer.PlayerLeft && GetPlayer.PlayerGame.Left > 0)
                {
                    GetPlayer.PlayerGame.Left -= Program.gInfo.PlayerSpeed;
                    GetPlayer.PlayerGame.Image = Resources.left;
                }

                // top window
                if (GetPlayer.PlayerUp && GetPlayer.PlayerGame.Top > 65)
                {
                    GetPlayer.PlayerGame.Top -= Program.gInfo.PlayerSpeed;
                    GetPlayer.PlayerGame.Image = Resources.back;
                }

                // down window
                if (GetPlayer.PlayerDown && GetPlayer.PlayerGame.Top < 710)
                {
                    GetPlayer.PlayerGame.Top += Program.gInfo.PlayerSpeed;
                    GetPlayer.player.Image = Resources.front;
                }



                // check
                foreach (Control item in CurrentPanel.Controls)
                {
                    if (item is Label)
                    {
                        if ((string)item.Tag == "key")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                CurrentPanel.Controls.Remove(item);
                                hasKey = true;
                            }
                        }

                        if ((string)item.Tag == "door")
                        {
                            

                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds) && hasKey == true)
                            {

                                if (Program.gInfo.Level == 1)
                                {
                                    CurrentPanel.Controls.Remove(item);
                                    CurrentPanel.Hide();
                                    Program.gInfo.Level = 2;
                                    Console.WriteLine(Program.gInfo.Level.ToString());

                                    NewGame.level_2 = new Level2();
                                    NewGame.level_2.LoadLevel2();

                                }
                                else if (Program.gInfo.Level == 2)
                                {
                                    CurrentPanel.Controls.Remove(item);
                                    CurrentPanel.Hide();
                                    Program.gInfo.Level = 3;
                                    Console.WriteLine(Program.gInfo.Level.ToString());
                                }

                            }
                        }

                        if ((string)item.Tag == "trap")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                // game time pause
                                GameTimeMain.gameMainTimer.Enabled = false;

                                CurrentPanel.Controls.Remove(item);
                                traplogic.TrapPauseFunction();
                                bool isEscape = traplogic.TrapMiniGameRandomizer();
                                traplogic.GameContinueFunction();
                                GetPlayer.PlayerRight = false;
                                GetPlayer.PlayerLeft = false;
                                GetPlayer.PlayerUp = false;
                                GetPlayer.PlayerDown = false;
                                Console.WriteLine($"{isEscape} program main");

                                // game time resume
                                GameTimeMain.gameMainTimer.Enabled = true;
                            }
                        }

                        // coin score
                        if ((string)item.Tag == "coin")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds) && item.Visible == true)
                            {
                                Program.gInfo.Score += 1;
                                //item.Visible = false;
                                CurrentPanel.Controls.Remove(item);
                            }
                        }
                        // enemy
                        if ((string)item.Name == "enemy")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                Program.gInfo.Life -= 1;
                                GetPlayer.PlayerGame.Left -= 35;
                            }


                            foreach (Label wallItem in walls)
                            {
                                if (wallItem == null)
                                {
                                    continue;
                                }

                                if ((string)item.Tag == "enemySide")
                                {
                                    if (item.Bounds.IntersectsWith(wallItem.Bounds))
                                    {
                                        int idx = Array.IndexOf(enemy, item);
                                        enemySpeed[idx] = -enemySpeed[idx];
                                    }
                                }

                                if ((string)item.Tag == "enemyUp")
                                {
                                    if (item.Bounds.IntersectsWith(wallItem.Bounds))
                                    {
                                        int idx = Array.IndexOf(enemy, item);
                                        enemySpeed[idx] = -enemySpeed[idx];
                                    }
                                }
                            }
                        }


                        if ((string)item.Tag == "wall")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                if (GetPlayer.PlayerLeft)
                                {
                                    GetPlayer.PlayerGame.Left += Program.gInfo.PlayerSpeed;
                                }

                                if (GetPlayer.PlayerRight)
                                {
                                    GetPlayer.PlayerGame.Left -= Program.gInfo.PlayerSpeed;
                                }

                                if (GetPlayer.PlayerUp)
                                {
                                    GetPlayer.PlayerGame.Top += Program.gInfo.PlayerSpeed;
                                }


                                if (GetPlayer.PlayerDown)
                                {
                                    GetPlayer.PlayerGame.Top -= Program.gInfo.PlayerSpeed;
                                }
                            }
                        }

                    }

                }


                // enemy movement
                // enemies

                for (int i = 0; i < 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        enemy[i].Left += enemySpeed[i];
                    }
                    else
                    {
                        enemy[i].Top += enemySpeed[i];
                    }
                }

            }
        }
    }
}


