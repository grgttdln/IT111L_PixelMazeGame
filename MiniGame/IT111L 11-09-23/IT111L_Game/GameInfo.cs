using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT111L_Game
{
    internal class GameInfo
    {
                
        private int level = 1;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private int score = 0;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }


    }
}
