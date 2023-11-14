using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontGameCollection;


namespace MiniGameRiddles
{
    internal class RiddleElements
    {
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public RiddleLogic RLogic;

        public RiddleForm RForm;

        public RiddleElements(RiddleForm form)
        {

            RForm = form;
            RLogic = new RiddleLogic(form, this);
            submitButton.Click += RLogic.submitButton_Click;
            RLogic.gameStart();
        }

        private Label cardMiniTitle = new Label
        {
            Text = "Mini Game Trap: Riddles",
            Size = new Size(800, 50),
            Font = new Font(fontGame.pfc.Families[1], 28),
            Location = new Point(-6, 5),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter,
        };

        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = null; }
        }


        private Label questionLabelField = new Label
        {
            Text = "RIDDLES",
            Size = new Size(600, 270),
            ForeColor = Color.Black,
            Font = new Font(fontGame.pfc.Families[0], 20),
            BackgroundImage = RiddleResources.question_bg,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            Location = new Point(95, 60),
            TextAlign = ContentAlignment.MiddleCenter,
            Padding = new Padding(55),
            AutoSize = false
        };

        public Label QuestionLabel
        {
            get { return questionLabelField; }
            set { questionLabelField = value; }
        }

        private TextBox answerTextBoxField = new TextBox
        {
            Location = new Point(245, 340),
            Size = new Size(300, 50),
            Font = new Font(fontGame.pfc.Families[0], 16),
            BackColor = Color.FromArgb(244, 238, 219), // bg color for old paper
            ForeColor = Color.Black,
            BorderStyle = BorderStyle.FixedSingle
        };

        public TextBox answerTextBox
        {
            get { return answerTextBoxField; }
            set { answerTextBoxField = value; }
        }

        private Button submitButtonField = new Button
        {
            Text = "SUBMIT",
            Font = new Font(fontGame.pfc.Families[1], 13),
            BackgroundImage = RiddleResources.submit_bg,
            BackgroundImageLayout = ImageLayout.Stretch,
            BackColor = Color.Transparent,
            Location = new Point((770 - 120) / 2, 380),
            Size = new Size(140, 80),
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255), MouseOverBackColor = Color.Transparent, MouseDownBackColor = Color.Transparent },
            TabStop = false
        };


        public Button submitButton
        {
            get { return submitButtonField; }
            set { submitButtonField = value; }
        }


    }
}
