using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace IT111L_Game
{
    // Internal class representing a Coin with methods for creating and arranging coin labels
    internal class Coin
    {
        // Method to create a single coin label at the specified coordinates (x, y)
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

        // Method to create an array of five coin labels arranged horizontally from the specified coordinates (x, y)
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

        // Method to create an array of five coin labels arranged vertically from the specified coordinates (x, y)
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

        // Method to create an array of three coin labels arranged horizontally from the specified coordinates (x, y)
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

        // Method to create an array of three coin labels arranged vertically from the specified coordinates (x, y)
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

        // Method to add an array of coin labels to a Panel
        public void AddCoinsToPanel(Label[] coins, Panel panel)
        {
            foreach (Label c in coins)
            {
                panel.Controls.Add(c);
            }
        }
    }
}
