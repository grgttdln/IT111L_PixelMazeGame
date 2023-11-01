using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniGameWindow
{
    public class MiniGameForm
    {
        public int Level { get; set; }
        public MiniGameForm(int lvl)
        {
            Level = lvl;
        }

        public virtual void MiniGameMainDisplay()
        {
            
        }
    }
}
