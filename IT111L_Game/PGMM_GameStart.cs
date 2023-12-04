using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    // Internal class representing the game start menu functionality
    internal class PGMM_GameStart
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel PanelLanding { get; set; }
        public Button BackBtn { get; set; }
        public Button NewGameBtn { get; set; }
        public Label Play { get; set; }


        GameStartBtnFunc btnFunc = new GameStartBtnFunc();

        // Constructor to initialize game start elements
        public PGMM_GameStart()
        {
            PanelLanding = new Panel
            {
                Text = "Panel Landing",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackgroundImage = Resources.newgame_bg,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            BackBtn = new Button
            {
                Text = "Back",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(100, 100),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };

            BackBtn.Click += btnFunc.BackBtnFunc;
            BackBtn.MouseEnter += btnFunc.Button_MouseEnter;
            BackBtn.MouseLeave += btnFunc.Button_MouseLeave;


            NewGameBtn = new Button
            {
                Text = "ENTER THE DUNGEON!",
                Font = new Font(fontGame.pfc.Families[0], 24),
                Location = new Point(420, 635),
                Size = new Size(365, 75),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };

            NewGameBtn.Click += btnFunc.NewGameFunc;
            NewGameBtn.MouseEnter += btnFunc.Button_MouseEnter;
            NewGameBtn.MouseLeave += btnFunc.Button_MouseLeave;


            Play = new Label
            {
                Text = "Play",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 100),
                Size = new Size(200, 200)
            };
        }

        // Method to load the game start elements onto the main menu
        public void LoadGameStart()
        {
            GetPanelMainMenu.Controls.Add(PanelLanding);
            PanelLanding.Controls.Add(BackBtn);
            PanelLanding.Controls.Add(NewGameBtn);
        }
    }


    // Internal class inheriting from PixelGameLBtnFunc, representing button functions for game start
    internal class GameStartBtnFunc : PixelGameLBtnFunc
    {
        PixelGameMMElements mmElements = new PixelGameMMElements();
        public static NewGame newGame = new NewGame();

        // Method to handle mouse enter event for buttons
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button currBtn = (Button)sender;
                currBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                currBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                currBtn.ForeColor = Color.Red;
            }
        }

        // Method to handle mouse leave event for buttons
        public void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button currBtn = (Button)sender;
                currBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                currBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                currBtn.ForeColor = Color.Black;
            }
        }

        // Method to handle the click event for the new game button
        public void NewGameFunc(object sender, EventArgs e)
        {

            GetPanelMainMenu.Controls.Clear();

            // New game load
            newGame.LoadGameStart_1();

        }

    }
}
