﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using MiniGameLogicQuiz;
using WMPLib;

namespace IT111L_Game
{
    internal class Timer
    {
        // Timer for game updates.
        static public System.Windows.Forms.Timer gameMainTimer = new System.Windows.Forms.Timer();


        // Current game panel.
        public Panel CurrentPanel = null;


        // Player object.
        public Player GetPlayer { get { return NewGame.player; } }


        // Background music player.
        private WindowsMediaPlayer player_BG = new WindowsMediaPlayer
        {
            URL = @"./assets/music/maze_bgmusic_short.wav",
        };

        private SoundPlayer soundPlayer = new SoundPlayer();


        // Array of wall labels.
        public Label[] walls = new Label[100];


        // Player starting position.
        int plyrLeft, plyrTop;


        // Array for enemy speeds and labels.
        public int[] enemySpeed = new int[5];
        public Label[] enemy = new Label[5];


        // Trap, TrapLogic, and Teleporter objects.
        public Trap Trap { get; private set; }
        public TrapLogic traplogic { get; private set; }
        public Teleporter Teleporter { get; private set; }


        bool hasKey = false;
        public GameTimeMain CurrentTimer;


        // Initializes Trap, TrapLogic, and Teleporter objects.
        public Timer()
        {
            Trap = new Trap();
            traplogic = new TrapLogic();
            Teleporter = new Teleporter();
        }



        // Initializes the components for the current level.
        public void InitializeComponentLevel()
        {
            
            switch (Program.gInfo.Level)
            {
                case 1:
                    CurrentPanel = NewGame.level_1.Level1_MainPanel;

                    Array.Copy(NewGame.level_1.wallsCollection, walls, NewGame.level_1.wallsCollection.Length);
                    Array.Copy(NewGame.level_1.enemiesSpeedCollection, enemySpeed, NewGame.level_1.enemiesSpeedCollection.Length);
                    Array.Copy(NewGame.level_1.enemiesCollection, enemy, NewGame.level_1.enemiesCollection.Length);

                    plyrLeft = 145;
                    plyrTop = 390;

                    CurrentTimer = Level1.Level_TimeMain;
                    break;
                case 2:
                    CurrentPanel = NewGame.level_2.Level2_MainPanel;

                    Array.Copy(NewGame.level_2.wallsCollection, walls, NewGame.level_2.wallsCollection.Length);
                    Array.Copy(NewGame.level_2.enemiesSpeedCollection, enemySpeed, NewGame.level_2.enemiesSpeedCollection.Length);
                    Array.Copy(NewGame.level_2.enemiesCollection, enemy, NewGame.level_2.enemiesCollection.Length);

                    plyrLeft = 90;
                    plyrTop = 215;

                    CurrentTimer = Level2.Level_TimeMain;
                    break;
                case 3:
                    CurrentPanel = NewGame.level_3.Level3_MainPanel;

                    Array.Copy(NewGame.level_3.wallsCollection, walls, NewGame.level_3.wallsCollection.Length);
                    Array.Copy(NewGame.level_3.enemiesSpeedCollection, enemySpeed, NewGame.level_3.enemiesSpeedCollection.Length);
                    Array.Copy(NewGame.level_3.enemiesCollection, enemy, NewGame.level_3.enemiesCollection.Length);

                    plyrLeft = 55;
                    plyrTop = 215;

                    CurrentTimer = Level3.Level_TimeMain;
                    break;
            }

            TimerComponent();
            player_BG.settings.setMode("loop", true);
        }



        // Initializes the game timer.
        public void TimerComponent()
        {
            gameMainTimer.Interval = 20;
            gameMainTimer.Enabled = true;
            gameMainTimer.Tick += GameTimer_Tick;
            gameMainTimer.Start();
        }


        // Stops the game timer.
        public void StopTimer()
        {
            gameMainTimer.Stop();
            gameMainTimer.Tick -= GameTimer_Tick;
        }


        // Displays player stats.
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



        // Event handler for the game timer tick.
        public void GameTimer_Tick(object sender, EventArgs e)
        {
            StatsDisplay();

            // gameover game mechanics
            if (Program.gInfo.Life <= 0 || GameTimeMain.gameTime == -1)
            {
                CurrentTimer.StopTimer();
                StopTimer();

                player_BG.controls.stop();

                soundPlayer.Stream = Resources.gameover;
                soundPlayer.Play();

                MessageBox.Show("Game Over");

                GetPlayer.PlayerRight = false;
                GetPlayer.PlayerLeft = false;
                GetPlayer.PlayerUp = false;
                GetPlayer.PlayerDown = false;

                if (Program.gInfo.Score < 35)
                {
                    Program.gInfo.Score = 0;
                    Program.gInfo.Life = 5;

                    Program.gInfo.Level = 1;

                    CurrentPanel.Hide();

                    NewGame.level_1 = new Level1();
                    NewGame.level_1.LoadLevel1();

                    Level1.Level_TimeMain = new GameTimeMain(120);

                    GetPlayer.PlayerGame.Location = new Point(145, 390);
                    
                }
                else if (Program.gInfo.Score >= 35)
                {
                    Program.gInfo.Score -= 35;
                    Program.gInfo.Life = 5;


                    switch (Program.gInfo.Level)
                    {
                        case 1:
                            CurrentPanel.Hide();
                            NewGame.level_1 = new Level1();
                            NewGame.level_1.LoadLevel1();
                            Level1.Level_TimeMain = new GameTimeMain(120);

                            GetPlayer.PlayerGame.Location = new Point(145, 390);
                            break;
                        case 2:
                            CurrentPanel.Hide();
                            NewGame.level_2 = new Level2();
                            NewGame.level_2.LoadLevel2();
                            Level1.Level_TimeMain = new GameTimeMain(180);

                            GetPlayer.PlayerGame.Location = new Point(90, 215);
                            break;
                        case 3:
                            CurrentPanel.Hide();
                            NewGame.level_3 = new Level3();
                            NewGame.level_3.LoadLevel3();
                            Level1.Level_TimeMain = new GameTimeMain(240);

                            GetPlayer.PlayerGame.Location = new Point(55, 215);
                            break;
                    }
                }
            }


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
                //Console.WriteLine($"Player Left: {GetPlayer.PlayerGame.Left}\tPlayer Top: {GetPlayer.PlayerGame.Top}");

                PlayerGameWindowBounds();

                // check for each element in the game
                foreach (Control item in CurrentPanel.Controls)
                {
                    if (item is Label)
                    {
                        // teleport
                        if ((string)item.Tag == "teleporterentry")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                soundPlayer.Stream = Resources.teleport;
                                soundPlayer.Play();
                                item.Enabled = false;

                                if (Program.gInfo.Level == 1)
                                {
                                    GetPlayer.PlayerGame.Location = new System.Drawing.Point(680, 350);
                                }
                                else if (Program.gInfo.Level == 2)
                                {
                                    GetPlayer.PlayerGame.Location = new System.Drawing.Point(1075, 580);
                                }
                                else if (Program.gInfo.Level == 3)
                                {
                                    GetPlayer.PlayerGame.Location = new System.Drawing.Point(660, 585);
                                }


                            }
                        }

                        // key
                        if ((string)item.Tag == "key")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                soundPlayer.Stream = Resources.key_pickup;
                                soundPlayer.Play();
                                CurrentPanel.Controls.Remove(item);
                                hasKey = true;
                            }
                        }

                        // door
                        if ((string)item.Tag == "door")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds) && hasKey == true)
                            {
                                soundPlayer.Stream = Resources.next_level;
                                soundPlayer.Play();
                                if (Program.gInfo.Level == 1)
                                {
                                    CurrentPanel.Controls.Remove(item);
                                    CurrentPanel.Hide();
                                    Program.gInfo.Level = 2;
                                    
                                    CurrentTimer.StopTimer();

                                    player_BG.controls.stop();

                                    StopTimer();
                                    NewGame.level_2 = new Level2();
                                    NewGame.level_2.LoadLevel2();

                                }
                                else if (Program.gInfo.Level == 2)
                                {
                                    CurrentPanel.Controls.Remove(item);
                                    CurrentPanel.Hide();
                                    Program.gInfo.Level = 3;
                                    
                                    CurrentTimer.StopTimer();

                                    player_BG.controls.stop();

                                    StopTimer();
                                    NewGame.level_3 = new Level3();
                                    NewGame.level_3.LoadLevel3();

                                }
                                else if (Program.gInfo.Level == 3)
                                {
                                    CurrentPanel.Controls.Remove(item);
                                    CurrentPanel.Hide();
                                    CurrentTimer.StopTimer();

                                    player_BG.controls.stop();

                                    StopTimer();
                                    NewGame.final_game = new FinalGame();
                                    NewGame.final_game.LoadFinal();
                                    
                                }
                            }
                        }

                        // trap
                        if ((string)item.Tag == "trap")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds))
                            {
                                soundPlayer.Stream = Resources.trap_activate;
                                soundPlayer.Play();
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

                                //Console.WriteLine($"{isEscape} program main");

                                // game time resume
                                GameTimeMain.gameMainTimer.Enabled = true;
                            }
                        }

                        // coin 
                        if ((string)item.Tag == "coin")
                        {
                            if (GetPlayer.PlayerGame.Bounds.IntersectsWith(item.Bounds) && item.Visible == true)
                            {
                                soundPlayer.Stream = Resources.coin_pickup;
                                soundPlayer.Play();
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
                                soundPlayer.Stream = Resources.player_damage;
                                soundPlayer.Play();
                                Program.gInfo.Life -= 1;

                                GetPlayer.PlayerGame.Left = plyrLeft;
                                GetPlayer.PlayerGame.Top = plyrTop;

                                //GetPlayer.PlayerGame.Left -= 35;
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

                        // wall
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
                for (int i = 0; i <= 4; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (enemy[i] != null)
                        {
                            enemy[i].Left += enemySpeed[i];
                        }
                    }
                    else
                    {
                        if (enemy[i] != null)
                        {
                            enemy[i].Top += enemySpeed[i];
                        }
                    }
                }

            }
        }
    }
}


