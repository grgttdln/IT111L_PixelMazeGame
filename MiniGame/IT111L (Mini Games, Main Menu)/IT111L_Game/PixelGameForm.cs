using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace IT111L_Game
{
    internal class PixelGameForm : Form
    {

        public static PixelGameMainMenu gMainMenu = new PixelGameMainMenu();
        public static PGMM_GameStart pgmmGameStart = new PGMM_GameStart();

        public PixelGameForm()
        {
            this.Name = "PixelGameForm";
            this.Size = new Size(1200, 800);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MaximizeBox = false;

            AddFormElements();
        }


        public void AddFormElements()
        {
            this.Controls.Add(gMainMenu.PanelMainMenu);
            gMainMenu.AddPanelMMElements();
        }

    }
}
