using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MiniGameRiddles
{
    internal class RiddleLogic
    {
        public ArrayList randList = new ArrayList();
        public Riddle[] riddles;
        public int currentRiddleIndex = -1; //index of the current riddle being displayed
        public int randomRiddleIndex; //randomly generated index (for random riddle generation)

        public string correctAnswer;
        public RiddleElements riddleElements;
        public RiddleForm riddleForm;

        private SoundPlayer soundPlayer = new SoundPlayer();

        public RiddleLogic(RiddleForm riddleForm, RiddleElements riddleElements)
        {
            this.riddleForm = riddleForm;
            this.riddleElements = riddleElements;

            riddles = LoadRiddles("data/riddles.txt");

        }


        //class to represent riddle
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

        //method to load riddles from a text file
        public Riddle[] LoadRiddles(string filePath)
        {
            Riddle[] riddleArray = null;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int count = File.ReadLines(filePath).Count(); //counting the number of riddles in the text file
                    riddleArray = new Riddle[count]; //initialize the riddleArray

                    int index = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine(); //read the next line 
                        string[] parts = line.Split('|'); //split the line into two parts using the '|' character as the delimiter
                        if (parts.Length == 2)
                        {
                            Riddle riddle = new Riddle(parts[0], parts[1]); //create a new Riddle object with the question (parts[0]) and answer (parts[1])
                            riddleArray[index] = riddle; //store the Riddle object in the riddleArray at the current index
                            index++;
                        }
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error loading riddles: " + error.Message);
                Environment.Exit(1);
            }

            return riddleArray;
        }


        //method for random generation of riddles
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


        //method to display the next riddle
        public void DisplayNextRiddle()
        {

            if (currentRiddleIndex < riddles.Length)
            {
                currentRiddleIndex++;

                // Randomly select a riddle index
                int ranIndex = randomShuffle(riddles, randList);

                // Add the random riddle index to the list
                randList.Add(ranIndex);

                // Store the random riddle index in a global variable
                randomRiddleIndex = ranIndex;



                if (RiddleForm.currentLevel == 2 && currentRiddleIndex == 2)
                {
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    //if currentLevel is 2 and displayed 2 riddles, show a success message and close the form
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");

                    MiniGameTimer.GetTimer.Stop();
                    RiddleForm.form.Close();
                }
                else if (RiddleForm.currentLevel == 3 && currentRiddleIndex == 3)
                {
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    //if currentLevel is 3 and displayed 3 riddles, show a message and close the form
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");
                    
                    MiniGameTimer.GetTimer.Stop();
                    RiddleForm.form.Close();
                }
                else
                {
                    //display the next riddle
                    var selectedRiddle = riddles[randomRiddleIndex];
                    riddleElements.QuestionLabel.Text = selectedRiddle.Question;
                    riddleElements.answerTextBox.Text = "";
                    correctAnswer = selectedRiddle.Answer;
                }
            }
        }

        //method to check the user's answer
        public void CheckAnswer()
        {
            string userAnswer = riddleElements.answerTextBox.Text.Trim().ToLower();


            if (userAnswer == correctAnswer)
            {
                if (RiddleForm.currentLevel == 1)
                {
                    soundPlayer.Stream = RiddleResources.win;
                    soundPlayer.Play();
                    //Handle completion of the riddles for level 1
                    TimerInfo.isWin = true;
                    MiniGameTimer.isFinish = true;
                    MessageBox.Show("Congratulations! You completed the challenge!");
                    
                    MiniGameTimer.GetTimer.Stop();

                    riddleForm.CloseForm();
                }
                else if (RiddleForm.currentLevel >= 2)
                {
                    soundPlayer.Stream = RiddleResources.right_1;
                    soundPlayer.Play();
                    DisplayNextRiddle();
                }
            }
            else
            {
                soundPlayer.Stream = RiddleResources.wrong_2;
                soundPlayer.Play();
                //display a message for an incorrect answer
                MessageBox.Show("Incorrect! Try again.");
            }
        }

        //event handler for the submit button
        public void submitButton_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        public void gameStart()
        {
            DisplayNextRiddle();
            RiddleForm.timer.RiddleTimerStart();
        }
    }
}
