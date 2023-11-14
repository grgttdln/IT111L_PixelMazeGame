using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IT111L_Game
{
    internal class Teleporter
    {
        private Label teleporterEntry;

        private Label teleporterExit;

        public Label createTeleporterEntry(int x, int y)
        {
            teleporterEntry = new Label
            {
                Name = "teleporterentry",
                Tag = "teleporterentry",
                Size = new Size(70, 70),
                Location = new Point(x, y),
                Image = Resources.teleporter_entry
            };

            return teleporterEntry;
        }

        public Label createTeleporterExit(int x, int y)
        {
            teleporterExit = new Label
            {
                Name = "teleporterexit",
                Tag = "teleporterexit",
                Size = new Size(70, 70),
                Location = new Point(x, y),
                Image = Resources.teleporter_exit
            };

            return teleporterExit;
        }

        
    }
}
