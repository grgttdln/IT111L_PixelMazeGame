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
        public Player GetPlayer { get { return Level1.player; } }
        public Trap Trap { get; private set; }
        public TrapLogic traplogic { get; private set; }

        
        public Timer()
        {
            Trap = new Trap();
            traplogic = new TrapLogic();
        }


        public void InitializeComponentLevel()
        {
            switch (Program.gInfo.Level)
            {
                case 1:
                    CurrentPanel = NewGame.level_1.Level1_MainPanel;
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
            if (!Program.gInfo.Pause)
            {
                foreach (Control item in NewGame.level_1.Level1_MainPanel.Controls)
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
                foreach (Control item in NewGame.level_1.Level1_MainPanel.Controls)
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



                // check
                foreach (Control item in NewGame.level_1.Level1_MainPanel.Controls)
                {
                    if (item is Label)
                    {
                        if ((string)item.Tag == "trap")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                CurrentPanel.Controls.Remove(item);
                                traplogic.TrapPauseFunction();
                                bool isEscape = traplogic.TrapMiniGameRandomizer();
                                traplogic.GameContinueFunction();
                                GetPlayer.PlayerRight = false;
                                GetPlayer.PlayerLeft = false;
                                GetPlayer.PlayerUp = false;
                                GetPlayer.PlayerDown = false;
                                Console.WriteLine($"{isEscape} program main");
                               
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


                            foreach (Label wallItem in NewGame.level_1.wallsCollection)
                            {
                                if (wallItem == null)
                                {
                                    continue;
                                }

                                if ((string)item.Tag == "enemySide")
                                {
                                    if (item.Bounds.IntersectsWith(wallItem.Bounds))
                                    {
                                        int idx = Array.IndexOf(NewGame.level_1.enemiesCollection, item);
                                        NewGame.level_1.enemiesSpeedCollection[idx] = -NewGame.level_1.enemiesSpeedCollection[idx];
                                    }
                                }

                                if ((string)item.Tag == "enemyUp")
                                {
                                    if (item.Bounds.IntersectsWith(wallItem.Bounds))
                                    {
                                        int idx = Array.IndexOf(NewGame.level_1.enemiesCollection, item);
                                        NewGame.level_1.enemiesSpeedCollection[idx] = -NewGame.level_1.enemiesSpeedCollection[idx];
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
                                    GetPlayer.PlayerGame.Left += 5;
                                }

                                if (GetPlayer.PlayerRight)
                                {
                                    GetPlayer.PlayerGame.Left -= 5;
                                }

                                if (GetPlayer.PlayerUp)
                                {
                                    GetPlayer.PlayerGame.Top += 5;
                                }


                                if (GetPlayer.PlayerDown)
                                {
                                    GetPlayer.PlayerGame.Top -= 5;
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
                        NewGame.level_1.enemiesCollection[i].Left += NewGame.level_1.enemiesSpeedCollection[i];
                    }
                    else
                    {
                        NewGame.level_1.enemiesCollection[i].Top += NewGame.level_1.enemiesSpeedCollection[i];
                    }
                }
            }

            StatsDisplay();
        }
    }
}


