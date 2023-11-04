using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameRPS
{
    internal class RPSForm : Form
    {

        public RPSElements elements;

        public RPSLogic rpsLogic;

        public static int currentLevel;

        public RPSForm(int level)
        {
            currentLevel = level;

            elements = new RPSElements(this);

            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Pixel Quest Mini Game: Rock Paper Scissors";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            this.BackgroundImage = RPSResources.minigame_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            AddElements();
        }

        public void AddElements()
        {
            this.Controls.Add(elements.CardMiniTitle);
            this.Controls.Add(elements.SDText);
            this.Controls.Add(elements.RockButton);
            this.Controls.Add(elements.PaperButton);
            this.Controls.Add(elements.ScissorButton);
            this.Controls.Add(elements.PlayerRPS);
            this.Controls.Add(elements.CompRPS);

        }

        public void CloseForm()
        {
            Application.ExitThread();
        }


    }
}
