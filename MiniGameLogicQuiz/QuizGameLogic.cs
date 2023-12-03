using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFileHandler;
using System.Media;

// The QuizGameLogic class manages the logic of the Quiz Game, including loading questions,
// displaying questions, checking answers, shuffling questions, and handling game start.
namespace MiniGameLogicQuiz
{
    internal class QuizGameLogic : QuizGameElements
    {
        // Random object for shuffling questions and choices.
        private Random random = new Random();

        // SoundPlayer for playing sounds during the game.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Timer instance for managing game time.
        MiniGameMainTimer timer = new MiniGameMainTimer();

        // Variable to store the number of questions to be displayed.
        public static int numQuestion = 0;

        // Method to set up questions for the game.
        public void SetUpQs()
        {
            // Instance of MGReadQuestion to read questions from a file.
            GameFileHandler.MGReadQuestion read = new GameFileHandler.MGReadQuestion();

            // File path for the quiz questions.
            string filename = "";

            // If the current score is not set, set it based on the player's level.
            if (QuizGameInfo.currScore == -1)
            {
                switch (QuizGameForm.currentPlayerLevel)
                {
                    case 1:
                        QuizGameInfo.currScore = 3;
                        break;
                    case 2:
                        QuizGameInfo.currScore = 4;
                        break;
                    case 3:
                        QuizGameInfo.currScore = 5;
                        break;
                }
            }

            // Determine the number of questions and file path based on the player's level.
            switch (QuizGameForm.currentPlayerLevel)
            {
                case 1:
                    numQuestion = 3;
                    QuizGameInfo.noOfQuesToAns = 3;
                    filename = "./data/quiz-easy.txt";
                    break;
                case 2:
                    numQuestion = 4;
                    QuizGameInfo.noOfQuesToAns = 4;
                    filename = "./data/quiz-ave.txt";
                    break;
                case 3:
                    QuizGameInfo.noOfQuesToAns = 5;
                    filename = "./data/quiz-difficult.txt";
                    break;
            }

            // Read questions from the file and initialize question-related variables.
            QuizGameInfo.questions = read.ReadTxtFileQuestion(filename);
            QuizGameInfo.questionPoolLeft = QuizGameInfo.questions.Length;
        }

        // Method to display a randomly chosen question and its choices.
        public void DisplayRandomQuestion(int idx)
        {
            // Set the question text and correct answer.
            QuizQuestion.Text = (string)QuizGameInfo.questionsAL[idx];
            QuizGameInfo.CorrectAnswer = (string)QuizGameInfo.answersAL[idx];

            // Display the question and choices.
            DisplayQuestion(QuizGameInfo.choiceAL[idx]);

            // Add necessary controls to the form.
            PanelForm.Controls.Add(SignQuiz);
            PanelForm.Controls.Add(QuizQuestion);
            PanelForm.Controls.Add(QuizGameInfo.LblTimer);
            PanelForm.Controls.Add(QuizGameInfo.LblRightAnsLeft);

            // Set control order.
            SignQuiz.SendToBack();
            QuizQuestion.BringToFront();
        }

        // Method to check the player's answer against the correct answer.
        public void CheckAnswer(string ans, string correctAns)
        {
            // If it is the last question or the last question to answer, load a new set of questions.
            if (QuizGameInfo.questionPoolLeft == 1)
            {
                LoadQuiz();
            }

            // Check if the answer is correct.
            if (ans == correctAns)
            {
                // Play the correct sound.
                soundPlayer.Stream = MiniGameQuizResources.right_1;
                soundPlayer.Play();

                // Update score and questions left to answer.
                QuizGameInfo.currScore -= 1;
                QuizGameInfo.noOfQuesToAns -= 1;

                // If the player has answered all questions or reached a score of 0, end the game.
                if (0 == QuizGameInfo.currScore || 0 == QuizGameInfo.noOfQuesToAns)
                {
                    soundPlayer.Stream = MiniGameQuizResources.win;
                    soundPlayer.Play();
                    QuizGameInfo.isWin = true;
                    timer.isFinish = true;
                    MiniGameMainTimer.GetTimer.Stop();
                    MessageBox.Show("You Won!");
                    QuizGameForm.form.CloseForm();
                    return;
                }

                // Clear controls and shuffle questions for the next question.
                PanelForm.Controls.Clear();
                ShuffleQuestionPick();
            }
            else
            {
                // Play the wrong sound.
                soundPlayer.Stream = MiniGameQuizResources.wrong_2;
                soundPlayer.Play();

                // Update questions left to answer and score.
                QuizGameInfo.noOfQuesToAns += 1;
                QuizGameInfo.currScore += 1;

                // Clear controls and shuffle questions for the next question.
                PanelForm.Controls.Clear();
                ShuffleQuestionPick();
            }

            // Decrease the remaining question pool.
            QuizGameInfo.questionPoolLeft -= 1;
        }

        // Method to shuffle the question index for the next question.
        public void ShuffleQuestionPick()
        {
            // Choose a random index that has not been used before.
            int rIdx = random.Next(0, QuizGameInfo.questionsAL.Count);
            while (QuizGameInfo.arrRandAL.Contains(rIdx))
            {
                rIdx = random.Next(0, QuizGameInfo.questionsAL.Count);
            }
            QuizGameInfo.arrRandAL.Add(rIdx);

            // Display the randomly chosen question.
            DisplayRandomQuestion(rIdx);
        }

        // Method to shuffle the answer choices.
        public void ShuffleAnswerChoices(ref string[] array)
        {
            ArrayList arrRand = new ArrayList();
            string[] tempArr = new string[4];
            Array.Copy(array, tempArr, 4);

            for (int i = 0; i < 4; i++)
            {
                int rIdx = random.Next(0, 4);
                while (arrRand.Contains(rIdx))
                {
                    rIdx = random.Next(0, 4);
                }
                arrRand.Add(rIdx);

                tempArr[i] = array[rIdx];
            }

            Array.Copy(tempArr, array, 4);
        }

        // Event handler for the player's choice button click.
        public void ChoiceAction(object sender, EventArgs e)
        {
            string playerAns = (sender as Button).Text;
            CheckAnswer(playerAns, QuizGameInfo.CorrectAnswer);
        }

        // Method to load questions and choices for the quiz game.
        public void LoadQuiz()
        {
            // Clear controls and reset game status.
            PanelForm.Controls.Clear();
            QuizGameInfo.isWin = false;

            // Set up questions for the game.
            SetUpQs();

            // Loop through each question and its choices.
            for (int i = 0; i < QuizGameInfo.questions.Length; i++)
            {
                // Initialize the array to store choices for the current question.
                QuizGameInfo.qChoice = new Button[4];

                // Split the question string and extract choices and correct answer.
                string[] qSplitter = QuizGameInfo.questions[i].Split('|');

                // Add question and answer to their respective ArrayLists.
                QuizGameInfo.questionsAL.Add(qSplitter[0]);
                QuizGameInfo.answersAL.Add(qSplitter[4]);

                // Skip the question text and shuffle the answer choices.
                qSplitter = qSplitter.Skip(1).ToArray();
                ShuffleAnswerChoices(ref qSplitter);

                // Create and attach choice buttons to the event handler.
                for (int j = 0; j <= 3; j++)
                {
                    QuizGameInfo.qChoice[j] = AddChoiceBtnQuiz(qSplitter[j]);
                    QuizGameInfo.qChoice[j].Click += ChoiceAction;
                }

                // Add the array of choices to the choice ArrayList.
                QuizGameInfo.choiceAL.Add(QuizGameInfo.qChoice);
            }
        }

        // Method to start the game by loading questions, shuffling, and displaying the first question.
        public void gameStart()
        {
            LoadQuiz();
            ShuffleQuestionPick();
            QuizGameForm.timer.CGFormTimerStart();
        }
    }
}
