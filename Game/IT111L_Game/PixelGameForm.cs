using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;


namespace IT111L_Game
{
    internal class PixelGameForm : Form
    {

        public static PixelGameMainMenu gMainMenu = new PixelGameMainMenu();
        public static PGMM_GameStart pgmmGameStart = new PGMM_GameStart();
        private SoundPlayer soundPlayer = new SoundPlayer();

        public PixelGameForm()
        {
            this.Name = "PixelGameForm";
            this.Size = new Size(1200, 800);
            this.DoubleBuffered = true;
            this.Text = "Pixel Quest";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Resources.game_icon;

            this.MaximizeBox = false;


            

            AddFormElements();
        }


        public void PlayMenuBg()
        {
            Program.gInfo.IsBgPlaying = true;
            soundPlayer.Stream = Resources.menu_bgmusic;
            soundPlayer.Play();
        }

        public void AddFormElements()
        {
            if (!Program.gInfo.IsBgPlaying)
            {
                PlayMenuBg();
            }

            this.Controls.Add(gMainMenu.PanelMainMenu);
            gMainMenu.AddPanelMMElements();
        }

    }
}
