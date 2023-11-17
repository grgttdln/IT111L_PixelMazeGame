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
                Tag = "NGS_1",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackgroundImage = Resources.storyboard_1
            };

            NewGameStory_1.Click += btnFunc.NextStoryPageFunc;


            StoryPage_1 = new Label
            {
                Text = "StoryPage_1",
                Tag = "NGS_1",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(1200, 800),
                Image = Resources.storyboard_1
            };

            StoryPage_1.Click += btnFunc.NextStoryPageFunc;
        }

        public void LoadGameStart_1()
        {
            GetPanelMainMenu.BackgroundImage = null;
            GetPanelMainMenu.Controls.Add(NewGameStory_1);
            NewGameStory_1.Controls.Add(StoryPage_1);
        }
    }

    internal class StoryPanelBtnFunc : GameStartBtnFunc
    {
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        
        public void NextStoryPageFunc(object sender, EventArgs e)
        {
            GetPanelMainMenu.Controls.Clear();

            Label panel = sender as Label;

            
            if(panel.Tag == "NGS_1")
            {
                // Load Level Game
                NewGame.level_1 = new Level1();
                NewGame.level_1.LoadLevel1();

            }
        }
    }
}
