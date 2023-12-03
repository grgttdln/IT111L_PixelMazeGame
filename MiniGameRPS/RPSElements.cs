using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

// The MiniGameRPS namespace contains classes related to a Rock, Paper, Scissors (RPS) mini-game.

namespace MiniGameRPS
{
    // The RPSElements class defines elements used in the RPS mini-game interface.
    internal class RPSElements
    {
        // FontGame instance for managing fonts in the RPS elements.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // RPSLogic instance for handling the logic of the RPS game.
        public RPSLogic rpsLogic;

        // RPSForm instance representing the main form of the RPS mini-game.
        public RPSForm rpsForm;

        // Constructor for RPSElements, initializing the RPSForm and RPSLogic.
        public RPSElements(RPSForm form)
        {
            rpsForm = form;
            rpsLogic = new RPSLogic(this, form);

            // Attach event handlers for the RPS buttons.
            rockButton.Click += rpsLogic.GetChoice_Click;
            paperButton.Click += rpsLogic.GetChoice_Click;
            scissorButton.Click += rpsLogic.GetChoice_Click;
        }

        // Label displaying the title of the RPS mini-game.
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

        // Property to access the title label.
        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = value; }
        }

        // Label displaying additional text about the RPS mini-game.
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

        // Property to access the additional text label.
        public Label SDText
        {
            get { return sdText; }
            set { sdText = value; }
        }

        // PictureBox displaying the player's selected RPS choice.
        private PictureBox playerRPS = new PictureBox()
        {
            Height = 250,
            Width = 250,
            BackColor = Color.White,
            Image = RPSResources._default,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new Point(115, 100)
        };

        // Property to access the player's RPS PictureBox.
        public PictureBox PlayerRPS
        {
            get { return playerRPS; }
            set { playerRPS = value; }
        }

        // PictureBox displaying the computer's selected RPS choice.
        private PictureBox compRPS = new PictureBox()
        {
            Height = 250,
            Width = 250,
            BackColor = Color.White,
            Image = RPSResources._default,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new Point(425, 100)
        };

        // Property to access the computer's RPS PictureBox.
        public PictureBox CompRPS
        {
            get { return compRPS; }
            set { compRPS = value; }
        }

        // Button for selecting the "ROCK" choice in the RPS game.
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

        // Property to access the "ROCK" button.
        public Button RockButton
        {
            get { return rockButton; }
            set { rockButton = value; }
        }

        // Button for selecting the "PAPER" choice in the RPS game.
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

        // Property to access the "PAPER" button.
        public Button PaperButton
        {
            get { return paperButton; }
            set { paperButton = value; }
        }

        // Button for selecting the "SCISSORS" choice in the RPS game.
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

        // Property to access the "SCISSORS" button.
        public Button ScissorButton
        {
            get { return scissorButton; }
            set { scissorButton = value; }
        }
    }
}
