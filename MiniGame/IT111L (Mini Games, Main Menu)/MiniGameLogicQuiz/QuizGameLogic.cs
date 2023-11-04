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

namespace MiniGameLogicQuiz
{
    internal class QuizGameLogic : QuizGameElements
    {
        private Random random = new Random();
        MiniGameMainTimer timer = new MiniGameMainTimer();

        public static int numQuestion = 0;

        public void SetUpQs()
        {
            GameFileHandler.MGReadQuestion read = new GameFileHandler.MGReadQuestion();
            string filename = "";
            
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
            
            QuizGameInfo.questions = read.ReadTxtFileQuestion(filename);
            QuizGameInfo.questionPoolLeft = QuizGameInfo.questions.Length;
        }


        public void DisplayRandomQuestion(int idx)
        {
            QuizQuestion.Text = (string)QuizGameInfo.questionsAL[idx];
            QuizGameInfo.CorrectAnswer = (string)QuizGameInfo.answersAL[idx];
            DisplayQuestion(QuizGameInfo.choiceAL[idx]);
            PanelForm.Controls.Add(SignQuiz);
            PanelForm.Controls.Add(QuizQuestion);
            PanelForm.Controls.Add(QuizGameInfo.LblTimer);
            PanelForm.Controls.Add(QuizGameInfo.LblRightAnsLeft);
            SignQuiz.SendToBack();
            QuizQuestion.BringToFront();
        }


        public void CheckAnswer(string ans, string correctAns)
        {
            if (QuizGameInfo.questionPoolLeft == 1)
            {
                LoadQuiz();
            }

            if (ans == correctAns)
            {
                QuizGameInfo.currScore -= 1;
                QuizGameInfo.noOfQuesToAns -= 1;

                if (0 == QuizGameInfo.currScore)
                {
                    timer.CGFormTimerStop("You Won!");
                    return;
                }

                PanelForm.Controls.Clear();
                ShuffleQuestionPick();
            }
            else
            {
                QuizGameInfo.noOfQuesToAns += 1;
                QuizGameInfo.currScore += 1;
                PanelForm.Controls.Clear();
                ShuffleQuestionPick();
            }

            QuizGameInfo.questionPoolLeft -= 1;
        }


        public void ShuffleQuestionPick()
        {
            int rIdx = random.Next(0, QuizGameInfo.questionsAL.Count);
            while (QuizGameInfo.arrRandAL.Contains(rIdx))
            {
                rIdx = random.Next(0, QuizGameInfo.questionsAL.Count);
            }
            QuizGameInfo.arrRandAL.Add(rIdx);
            
            DisplayRandomQuestion(rIdx);
        }
    

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


        public void ChoiceAction(object sender, EventArgs e)
        {
            string playerAns = (sender as Button).Text;
            CheckAnswer(playerAns, QuizGameInfo.CorrectAnswer);
        }

 
        public void LoadQuiz()
        {
            SetUpQs();

            for (int i = 0; i < QuizGameInfo.questions.Length; i++)
            {
                QuizGameInfo.qChoice = new Button[4];
                string[] qSplitter = QuizGameInfo.questions[i].Split('|');

                QuizGameInfo.questionsAL.Add(qSplitter[0]);
                QuizGameInfo.answersAL.Add(qSplitter[4]);

                qSplitter = qSplitter.Skip(1).ToArray();
                ShuffleAnswerChoices(ref qSplitter);

                for (int j = 0; j <= 3; j++)
                {
                    QuizGameInfo.qChoice[j] = AddChoiceBtnQuiz(qSplitter[j]);
                    QuizGameInfo.qChoice[j].Click += ChoiceAction;
                }

                QuizGameInfo.choiceAL.Add(QuizGameInfo.qChoice);
            }
        }
    }
}
