using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class PixelGameLeaderboards
    {
        private FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public PixelGameLeaderboards()
        {

        }

        public string[] ReadLeaderboardsTxt(string filename)
        {
            string[] players = null;
            try
            {
                players = File.ReadAllLines($"./data/{filename}");
            }
            catch
            {
                Console.WriteLine("error");
            }
            return players;
        }

        public void SortLeaderBoards(ref string[] players)
        {
            
            var sortedArray = players.OrderByDescending(s => int.Parse(s.Split('|')[1]))
                                     .ThenBy(s => s.Split('|')[0])
                                     .ToArray();
            
            players = sortedArray;
        }

        public Label PlacePlayerLeader(string name, int x, int y)
        {
            Label player = new Label 
            { 
                Text = name,
                Font = new Font(fontGame.pfc.Families[0], 30),
                Size = new Size(600, 30),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            return player;
        }

        public Label PlaceRank(string rank, int x, int y)
        {
            Label rankLbl = new Label
            {
                Text = rank,
                Font = new Font(fontGame.pfc.Families[0], 30),
                Size = new Size(50, 30),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };
            return rankLbl;
        }

        public Label PlaceScore(string score, int x, int y)
        {
            Label scoreLbl = new Label
            {
                Text = score,
                Font = new Font(fontGame.pfc.Families[0], 30),
                Size = new Size(80, 30),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };
            return scoreLbl;
        }

        public Label PlaceScoreIcon(int x, int y)
        {
            Label scoreIconLbl = new Label
            {
                Size = new Size(40, 34),
                Location = new Point(x, y),
                BackColor = Color.Transparent,
                Image = Resources.coin_header
            };
            return scoreIconLbl;
        }


    }
}
