using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MiniGameRPS
{
    internal class RPSElements
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        public RPSLogic rpsLogic;
        public RPSForm rpsForm;

        public RPSElements(RPSForm form)
        {
            rpsForm = form;
            rpsLogic = new RPSLogic(this, form);
            rockButton.Click += rpsLogic.GetChoice_Click;
            paperButton.Click += rpsLogic.GetChoice_Click;
            scissorButton.Click += rpsLogic.GetChoice_Click;


        }

        private Label cardMiniTitle = new Label
        {
            Text = "Mini Game Trap: RPS Royale",
            Size = new Size(800, 50),
            Font = new Font(fontGame.pfc.Families[1], 28),
            Location = new Point(-6, 5),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter
        };

        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = value; }

        }

        private Label sdText = new Label()
        {
            Text = "Swift choices, instant win – defeat your opponent in a single move!",
            Size = new Size(800, 50),
            Font = new Font(fontGame.pfc.Families[0], 16),
            Location = new Point(-6, 50),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter
        };

        public Label SDText
        {
            get { return sdText; }
            set { sdText = value; }

        }


        private PictureBox playerRPS = new PictureBox()
        {
            Height = 250,
            Width = 250,
            BackColor = Color.White,
            Image = RPSResources._default,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new Point(115, 100)
        };


        public PictureBox PlayerRPS
        {
            get { return playerRPS; }
            set { playerRPS = value; }
        }

        private PictureBox compRPS = new PictureBox()
        {
            Height = 250,
            Width = 250,
            BackColor = Color.White,
            Image = RPSResources._default,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new Point(425, 100)
        };

        public PictureBox CompRPS
        {
            get { return compRPS; }
            set { compRPS = value; }
        }


        private Button rockButton = new Button()
        {
            Text = "ROCK",
            Font = new Font(fontGame.pfc.Families[0], 18),
            ForeColor = Color.Black,
            BackgroundImage = RPSResources.rockButton,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            Location = new Point((490 - 120) / 2, 360),
            Size = new Size(140, 80),
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255), MouseOverBackColor = Color.Transparent, MouseDownBackColor = Color.Transparent },
        };

        public Button RockButton
        {
            get { return rockButton; }
            set { rockButton = value; }
        }


        private Button paperButton = new Button()
        {
            Text = "PAPER",
            Font = new Font(fontGame.pfc.Families[0], 18),
            ForeColor = Color.Black,
            BackgroundImage = RPSResources.paperButton,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            Location = new Point((770 - 120) / 2, 360),
            Size = new Size(140, 80),
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255), MouseOverBackColor = Color.Transparent, MouseDownBackColor = Color.Transparent },
        };

        public Button PaperButton
        {
            get { return paperButton; }
            set { paperButton = value; }
        }

        private Button scissorButton = new Button()
        {
            Text = "SCISSORS",
            Font = new Font(fontGame.pfc.Families[0], 18),
            ForeColor = Color.Black,
            BackgroundImage = RPSResources.scissorsButton,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            Location = new Point((1050 - 120) / 2, 360),
            Size = new Size(140, 80),
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255), MouseOverBackColor = Color.Transparent, MouseDownBackColor = Color.Transparent },
        };

        public Button ScissorButton
        {
            get { return scissorButton; }
            set { scissorButton = value; }
        }
    }
}
