using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// The GameFileHandler namespace encapsulates classes related to handling game files.

namespace GameFileHandler
{
    // The MGReadQuestion class provides methods for reading questions from a text file.
    public class MGReadQuestion
    {
        // Reads a text file containing questions and returns an array of strings representing each question.
        // Parameters:
        //   filename - The path to the text file containing questions.
        // Returns:
        //   An array of strings representing each question in the text file, or null if an exception occurs.
        public string[] ReadTxtFileQuestion(string filename)
        {
            // Initialize the array to store the questions.
            string[] question = null;

            try
            {
                // Attempt to read all lines from the specified text file.
                question = File.ReadAllLines(filename);
            }
            catch (Exception e)
            {
                // If an exception occurs during file reading, set the question array to null.
                question = null;
            }

            // Return the array of questions.
            return question;
        }
    }
}
