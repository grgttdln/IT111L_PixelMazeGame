using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

// The MiniGameRiddles namespace contains classes related to a riddle mini-game.

namespace MiniGameRiddles
{
    // The RiddleLogic class handles the logic for the riddle mini-game, including loading riddles, displaying, and checking answers.
    internal class RiddleLogic
    {
        // ArrayList to store indices of displayed riddles to avoid repetition.
        public ArrayList randList = new ArrayList();

        // Array to store loaded riddles from a text file.
        public Riddle[] riddles;

        // Index of the current riddle being displayed.
        public int currentRiddleIndex = -1;

        // Randomly generated index for riddle selection.
        public int randomRiddleIndex;

        // Correct answer for the current riddle.
        public string correctAnswer;

        // Instances of RiddleElements and RiddleForm associated with this logic.
        public RiddleElements riddleElements;
        public RiddleForm riddleForm;

        // SoundPlayer for playing sound effects.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Constructor for RiddleLogic, taking RiddleForm and RiddleElements instances as parameters.
        public RiddleLogic(RiddleForm riddleForm, RiddleElements riddleElements)
        {
            this.riddleForm = riddleForm;
            this.riddleElements = riddleElements;

            // Load riddles from a text file.
            riddles = LoadRiddles("data/riddles.txt");
        }

        // Class to represent a riddle with a question and answer.
        public class Riddle
        {
            public string Question { get; set; }
            public string Answer { get; set; }

            public Riddle(string question, string answer)
            {
                Question = question;
                Answer = answer;
            }
        }

        // Method to load riddles from a text file.
        public Riddle[] LoadRiddles(string filePath)
        {
            Riddle[] riddleArray = null;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int count = File.ReadLines(filePath).Count(); // Counting the number of riddles in the text file.
                    riddleArray = new Riddle[count]; // Initialize the riddleArray.

                    int index = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine(); // Read the next line.
                        string[] parts = line.Split('|'); // Split the line into two parts using the '|' character as the delimiter.
                        if (parts.Length == 2)
                        {
                            // Create a new Riddle object with the question (parts[0]) and answer (parts[1]).
                            Riddle riddle = new Riddle(parts[0], parts[1]);
                            // Store the Riddle object in the riddleArray at the current index.
                            riddleArray[index] = riddle;
                            index++;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // Display an error message if there is an issue loading riddles.
                MessageBox.Show("Error loading riddles: " + error.Message);
                Environment.Exit(1);
            }

            return riddleArray;
        }

        // Method for randomly generating riddle indices.
        public static int randomShuffle(Riddle[] questions, ArrayList randList)
        {
            Random random = new Random();

            int randNum;
            do
            {
                randNum = random.Next(10);
            } while (randList.Contains(randNum));

            return randNum;
        }

        // Method to display the next riddle.
        public void DisplayNextRiddle()
        {
            if (currentRiddleIndex < riddles.Length)
            {
                currentRiddleIndex++;

                // Randomly select a riddle index.
                int ranIndex = randomShuffle(riddles, randList);

                // Add the random riddle index to the list.
                randList.Add(ranIndex);

                // Store the random riddle index in a global variable.
                randomRiddleIndex = ranIndex;

                if (RiddleForm.currentLevel == 2 && currentRiddleIndex == 2)
                {
                    // Play a winning sound effect and display a success message for level 2 completion.
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");

                    MiniGameTimer.GetTimer.Stop();
                    RiddleForm.form.Close();
                }
                else if (RiddleForm.currentLevel == 3 && currentRiddleIndex == 3)
                {
                    // Play a winning sound effect and display a success message for level 3 completion.
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");

                    MiniGameTimer.GetTimer.Stop();
                    RiddleForm.form.Close();
                }
                else
                {
                    // Display the next riddle.
                    var selectedRiddle = riddles[randomRiddleIndex];
                    riddleElements.QuestionLabel.Text = selectedRiddle.Question;
                    riddleElements.answerTextBox.Text = "";
                    correctAnswer = selectedRiddle.Answer;
                }
            }
        }

        // Method to check the user's answer.
        public void CheckAnswer()
        {
            string userAnswer = riddleElements.answerTextBox.Text.Trim().ToLower();

            if (userAnswer == correctAnswer)
            {
                if (RiddleForm.currentLevel == 1)
                {
                    // Play a winning sound effect and display a success message for level 1 completion.
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");

                    MiniGameTimer.GetTimer.Stop();

                    riddleForm.CloseForm();
                }
                else if (RiddleForm.currentLevel >= 2)
                {
                    // Play a correct answer sound effect and display the next riddle for level 2 and above.
                    soundPlayer.Stream = RiddleResources.right_1;
                    soundPlayer.Play();
                    DisplayNextRiddle();
                }
            }
            else
            {
                // Play an incorrect answer sound effect and display a message for an incorrect answer.
                soundPlayer.Stream = RiddleResources.wrong_2;
                soundPlayer.Play();
                MessageBox.Show("Incorrect! Try again.");
            }
        }

        // Event handler for the submit button click.
        public void submitButton_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        // Method to start the riddle mini-game.
        public void gameStart()
        {
            DisplayNextRiddle();
            RiddleForm.timer.RiddleTimerStart();
        }
    }
}
