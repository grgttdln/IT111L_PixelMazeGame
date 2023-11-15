using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace IT111L_Game
{
    internal class Coin
    {
        //public static Level1 level1 = new Level1();
        //public static Panel GetLevel1Panel { get { return level1.Level1_MainPanel; } }

        public Label CoinCreation(int x, int y)
        {
            Label coin = new Label
            {
                Name = "coin",
                Size = new Size(20, 20),
                Location = new Point(x, y),
                Tag = "coin",
                Image = Resources.coin,
                BackColor = Color.Transparent,
            };

            return coin;
        }


        public Label[] CoinFbFHoriz(int x, int y)
        {
            Label[] coin = new Label[5];

            for (int i = 0; i < 5; i++)
            {
                coin[i] = CoinCreation(x, y);
                x += 30;
            }

            return coin;
        }


        public Label[] CoinFbFVerti(int x, int y)
        {
            Label[] coin = new Label[5];

            for (int i = 0; i < 5; i++)
            {
                coin[i] = CoinCreation(x, y);
                y += 30;
            }

            return coin;
        }




        public Label[] CoinTbTHoriz(int x, int y)
        {
            Label[] coin = new Label[3];

            for (int i = 0; i < 3; i++)
            {
                coin[i] = CoinCreation(x, y);
                x += 30;
            }

            return coin;
        }


        public Label[] CoinTbTVerti(int x, int y)
        {
            Label[] coin = new Label[3];

            for (int i = 0; i < 3; i++)
            {
                coin[i] = CoinCreation(x, y);
                y += 30;
            }

            return coin;
        }

        public void AddCoinsToPanel(Label[] coins, Panel panel)
        {
            foreach (Label c in coins)
            {
                panel.Controls.Add(c);
            }
        }


    }
}
