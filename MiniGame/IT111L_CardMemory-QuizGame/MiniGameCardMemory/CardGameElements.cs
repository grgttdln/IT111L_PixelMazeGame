using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontGameCollection;


namespace MiniGameCardMemory
{
    internal class CardGameElements : CardGameInfo
    {

        public static FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();
        public CardGameLogic CGFLogic = new CardGameLogic();

        private CardGameForm cardGForm;
        public CardGameElements(CardGameForm form)
        {
            cardGForm = form;
        }

        public List<int> cardIntCollection = new List<int>();

        private Label cardMiniTitle = new Label
        {
            Text = "Mini Game Trap: Card Wars",
            Size = new Size(800, 50),
            Font = new Font(fontGame.pfc.Families[1], 28),
            Location = new Point(0, 0),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter,
        };

        public Label CardMiniTitle
        {
            get { return cardMiniTitle; }
            set { cardMiniTitle = null; }
        }


        
        public void LoadPictures()
        {
            
            currGameLevel = CardGameForm.currentPlayerLevel;
            int countRow = 0;
            int oLeftPosition = 0;
            

            switch (currGameLevel)
            {
                case 1:
                    totalCards = 4;
                    oLeftPosition = 190;
                    numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4 };
                    break;
                case 2:
                    totalCards = 5;
                    oLeftPosition = 120;
                    numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
                    break;
                case 3:
                    totalCards = 6;
                    oLeftPosition = 60;
                    numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
                    break;
            }

            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            cardIntCollection = randomList;

            
            int leftPosition = oLeftPosition;
            int topPosition = 120;
            int rows = 0;

            switch (currGameLevel)
            {
                case 1:
                    countRow = 4;
                    break;
                case 2:
                    countRow = 5;
                    break;
                case 3:
                    countRow = 6;
                    break;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                int tempI = i;
                if (tempI >= numbers.Count / 2)
                {
                    switch (currGameLevel)
                    {
                        case 1:
                            switch (tempI)
                            {
                                case 4:
                                    tempI = 0;
                                    break;
                                case 5:
                                    tempI = 1;
                                    break;
                                case 6:
                                    tempI = 2;
                                    break;
                                case 7:
                                    tempI = 3;
                                    break;
                                case 8:
                                    tempI = 4;
                                    break;
                            }
                            break;
                        case 2:
                            switch (tempI)
                            {
                                case 5:
                                    tempI = 0;
                                    break;
                                case 6:
                                    tempI = 1;
                                    break;
                                case 7:
                                    tempI = 2;
                                    break;
                                case 8:
                                    tempI = 3;
                                    break;
                                case 9:
                                    tempI = 4;
                                    break;
                                case 10:
                                    tempI = 5;
                                    break;
                            }
                            break;
                        case 3:
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
                            break;
                    }
                }


                PictureBox currPB = new PictureBox
                {
                    Height = 130,
                    Width = 100,
                    BackColor = Color.White,
                    Image = (Image)MiniGameCardResources.ResourceManager.GetObject("card_back"),
                    Tag = (tempI + 1).ToString(),
                    SizeMode = PictureBoxSizeMode.StretchImage,

                };
                currPB.Click += CGFLogic.CardClicked;
                cardPicturesCollection.Add(currPB);
                cardPicturesCollection[i].Tag = cardIntCollection[i].ToString();

                if (rows < countRow)
                {
                    rows++;
                    currPB.Left = leftPosition;
                    currPB.Top = topPosition;
                    cardGForm.Controls.Add(currPB);
                    leftPosition = leftPosition + 110;
                }
                if (rows == countRow)
                {
                    leftPosition = oLeftPosition;
                    topPosition += 150;
                    rows = 0;
                }
            }

            CGFLogic.NewGameOrderCards();
            
        }


    }
}

