using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Key
    {
        private Label key;


        public Label createKey(int x, int y)
        {
            key = new Label
            {
                Name = "key",
                Tag = "key",
                Size = new Size(50, 50),
                Location = new Point(x, y),
                Image = Resources.key


            };

            return key;
        }

    }
}
