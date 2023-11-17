using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameFileHandler
{
    public class MGReadQuestion
    {

        // returns an array (string)
        public string[] ReadTxtFileQuestion(string filename)
        {
            string[] question = null;
            try
            {
                question = File.ReadAllLines(filename);
            }
            catch (Exception e)
            {
                question = null;
            }
            return question;
        }


    }
}
