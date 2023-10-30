using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    internal class CardGameElements : CardGameInfo
    {
        public static FontGame fontCollection = new FontGame();
        public CardGameFormLogic CGFLogic = new CardGameFormLogic();


        private CardGameForm cardGForm;
        public CardGameElements(CardGameForm form)
        {
            cardGForm = form;
        }


        private Label cardMiniTitle = new Label
        {
            Text = "Mini Game Trap: Card Wars",
            Size = new Size(800, 50),
            Font = new Font(fontCollection.pfc.Families[0], 28),
            Location = new Point(0, 0)
        };

        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = null; }
        }


        public List<int> cardIntCollection = new List<int>();

        public void LoadPictures()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            cardIntCollection = randomList;

            int leftPosition = 250;
            int topPosition = 100;
            int rows = 0;

            for (int i = 0; i < 12; i++)
            {
                int tempI = i;
                if (tempI >= 6)
                {
                    switch (tempI)
                    {
                        case 6:
                            tempI = 0;
                            break;
                        case 7:
                            tempI = 1;
                            break;
                        case 8:
                            tempI = 2;
                            break;
                        case 9:
                            tempI = 3;
                            break;
                        case 10:
                            tempI = 4;
                            break;
                        case 11:
                            tempI = 5;
                            break;
                    }
                }


                PictureBox currPB = new PictureBox
                {
                    Height = 80,
                    Width = 50,
                    BackColor = Color.White,
                    Tag = (tempI + 1).ToString(),
                    SizeMode = PictureBoxSizeMode.StretchImage,

                 };
                currPB.Click += CGFLogic.CardClicked;
                cardPicturesCollection.Add(currPB);
                cardPicturesCollection[i].Tag = cardIntCollection[i].ToString();


                if (rows < 6)
                {
                    rows++;
                    currPB.Left = leftPosition;
                    currPB.Top = topPosition;
                    cardGForm.Controls.Add(currPB);
                    leftPosition = leftPosition + 60;
                }
                if (rows == 6)
                {
                    leftPosition = 250;
                    topPosition += 90;
                    rows = 0;
                }
            }

            CGFLogic.NewGameOrderCards();

        }
    }
}
