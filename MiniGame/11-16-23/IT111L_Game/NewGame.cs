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
    internal class NewGame
    {

        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel NewGameStory_1 { get; set; }
        public Panel NewGameStory_2 { get; set; }
        public Panel NewGameStory_3 { get; set; }
        public Label StoryPage_1 { get; set; }
        public Label StoryPage_2 { get; set; }
        public Label StoryPage_3 { get; set; }

        StoryPanelBtnFunc btnFunc = new StoryPanelBtnFunc();


        public static Level1 level_1;
        public static Level2 level_2;
        public static Level3 level_3;

        public static Player player = new Player();



        public NewGame()
        {
            NewGameStory_1 = new Panel
            {
                Text = "NewGameStory1",
                //Tag = "NGS_1",
                Tag = "NGS_3",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackColor = Color.Green,
            };

            NewGameStory_1.Click += btnFunc.NextStoryPageFunc;

            NewGameStory_2 = new Panel
            {
                Text = "NewGameStory2",
                Tag = "NGS_2",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackColor = Color.Pink,
            };

            NewGameStory_2.Click += btnFunc.NextStoryPageFunc;


            NewGameStory_3 = new Panel
            {
                Text = "NewGameStory3",
                Tag = "NGS_3",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackColor = Color.Orange,
            };

            NewGameStory_3.Click += btnFunc.NextStoryPageFunc;



            StoryPage_1 = new Label
            {
                Text = "StoryPage_1",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 300),
                Size = new Size(200, 200)
                //BackColor = Color.Pink,
            };

            StoryPage_2 = new Label
            {
                Text = "StoryPage_2",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 150),
                Size = new Size(200, 200)
                //BackColor = Color.Pink,
            };

            StoryPage_3 = new Label
            {
                Text = "StoryPage_3",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 70),
                Size = new Size(200, 200)
                //BackColor = Color.Pink,
            };

        }

        public void LoadGameStart_1()
        {
            GetPanelMainMenu.BackgroundImage = null;
            GetPanelMainMenu.Controls.Add(NewGameStory_1);
            NewGameStory_1.Controls.Add(StoryPage_1);
        }

        /*
        public void LoadGameStart_2()
        {
            GetPanelMainMenu.Controls.Clear();
            GetPanelMainMenu.Controls.Add(NewGameStory_2);
            NewGameStory_2.Controls.Add(StoryPage_2);
        }

        public void LoadGameStart_3()
        {
            GetPanelMainMenu.Controls.Clear();
            GetPanelMainMenu.Controls.Add(NewGameStory_3);
            NewGameStory_3.Controls.Add(StoryPage_3);
        }
        */
    }

    internal class StoryPanelBtnFunc : GameStartBtnFunc
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        
        
        public void NextStoryPageFunc(object sender, EventArgs e)
        {
            GetPanelMainMenu.Controls.Clear();

            Panel panel = sender as Panel;

            if (panel.Tag == "NGS_1")
            {
                //newGame.LoadGameStart_2();
            }
            if (panel.Tag == "NGS_2")
            {
                //newGame.LoadGameStart_3();
            }
            if(panel.Tag == "NGS_3")
            {
                // LOAD LEVEL GAME
                NewGame.level_1 = new Level1();
                NewGame.level_1.LoadLevel1();
            }
        }


    }
}
