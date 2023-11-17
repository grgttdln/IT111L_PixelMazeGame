using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace MiniGameRPS
{
    internal class RPSLogic
    {
        public RPSElements rpsElements;
        public RPSForm rpsForm;
        private SoundPlayer soundPlayer = new SoundPlayer();
        public static bool isWin = false;

        public RPSLogic(RPSElements rpsElements, RPSForm rpsForm)
        {
            this.rpsElements = rpsElements;
            this.rpsForm = rpsForm;
        }

        public void GetChoice_Click(object sender, EventArgs e)
        {
            soundPlayer.Stream = RPSResources.press;
            soundPlayer.Play();

            string playerChoice = (sender as Button).Text.ToLower();
            string computerChoice = GetCompPick();

            UpdatePlayerPictureBox(rpsElements.PlayerRPS, playerChoice);
            UpdateCompPictureBox(rpsElements.CompRPS, computerChoice);

            DetermineWinner(playerChoice, computerChoice);

        }


        public string GetCompPick()
        {
            Random random = new Random();

            string[] choices = { "rock", "paper", "scissors" };
            int index = random.Next(choices.Length);
            return choices[index];

        }

        public void DetermineWinner(string playerPick, string compPick)
        {

            if (playerPick == compPick)
            {
                MessageBox.Show("Its a Tie!");

            }

            else if ((playerPick == "rock" && compPick == "scissors") || (playerPick == "paper" && compPick == "rock") || (playerPick == "scissors" && compPick == "paper"))
            {
                
                soundPlayer.Stream = RPSResources.win;
                soundPlayer.Play();
                isWin = true;
                MessageBox.Show("You Win!");
                rpsForm.CloseForm();
            }

            else
            {
                soundPlayer.Stream = RPSResources.lose;
                soundPlayer.Play();
                MessageBox.Show("You Lose!");
                rpsForm.CloseForm();
            }
        }

        private void UpdatePlayerPictureBox(PictureBox pictureBox, string choice)
        {
            
            if (choice == "rock")
            {
                pictureBox.Image = RPSResources.player_rock;

            }
            else if (choice == "paper")
            {
                pictureBox.Image = RPSResources.player_paper;

            }
            else if (choice == "scissors")
            {
                pictureBox.Image = RPSResources.player_scissors;

            }
            pictureBox.Refresh();
        }

        private void UpdateCompPictureBox(PictureBox pictureBox, string choice)
        {
            
            if (choice == "rock")
            {
                pictureBox.Image = RPSResources.comp_rock;


            }
            else if (choice == "paper")
            {
                pictureBox.Image = RPSResources.comp_paper;


            }
            else if (choice == "scissors")
            {
                pictureBox.Image = RPSResources.comp_scissors;


            }
            pictureBox.Refresh();
        }






    }
}
