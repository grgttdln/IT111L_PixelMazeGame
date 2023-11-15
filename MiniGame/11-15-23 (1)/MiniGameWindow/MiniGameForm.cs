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
        public bool IsWin { get; set; }
        public MiniGameForm(int lvl)
        {
            Level = lvl;
            IsWin = false;
        }

        public virtual void MiniGameMainDisplay()
        {
            
        }
    }
}
