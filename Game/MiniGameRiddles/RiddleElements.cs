using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontGameCollection;


// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The RiddleElements class represents the visual elements and logic for the riddle mini-game.
    internal class RiddleElements
    {
        // Static instance of FontGame for managing fonts in the game.
        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        // Instance of RiddleLogic for handling game logic.
        public RiddleLogic RLogic;

        // Instance of RiddleForm associated with these game elements.
        public RiddleForm RForm;

        // Constructor for RiddleElements, taking a RiddleForm as a parameter.
        public RiddleElements(RiddleForm form)
        {
            // Initialize the RForm and RLogic instances, and wire up the submitButton click event.
            RForm = form;
            RLogic = new RiddleLogic(form, this);
            submitButton.Click += RLogic.submitButton_Click;
            RLogic.gameStart();
        }

        // Label displaying the title of the riddle mini-game.
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

        // Property to get and set the cardMiniTitle label.
        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = null; } // It seems like setting it to null may be unintentional; consider reviewing.
        }

        // Label displaying the riddle question.
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

        // Property to get and set the questionLabelField label.
        public Label QuestionLabel
        {
            get { return questionLabelField; }
            set { questionLabelField = value; }
        }

        // TextBox for entering the answer to the riddle.
        private TextBox answerTextBoxField = new TextBox
        {
            Location = new Point(245, 340),
            Size = new Size(300, 50),
            Font = new Font(fontGame.pfc.Families[0], 16),
            BackColor = Color.FromArgb(244, 238, 219), // bg color for old paper
            ForeColor = Color.Black,
            BorderStyle = BorderStyle.FixedSingle
        };

        // Property to get and set the answerTextBoxField TextBox.
        public TextBox answerTextBox
        {
            get { return answerTextBoxField; }
            set { answerTextBoxField = value; }
        }

        // Button for submitting the answer to the riddle.
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

        // Property to get and set the submitButtonField button.
        public Button submitButton
        {
            get { return submitButtonField; }
            set { submitButtonField = value; }
        }
    }
}
