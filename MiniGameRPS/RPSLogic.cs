using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

// The RPSLogic class handles the logic of the Rock, Paper, Scissors (RPS) mini-game.
namespace MiniGameRPS
{
    internal class RPSLogic
    {
        // RPSElements instance for managing elements used in the RPS logic.
        public RPSElements rpsElements;

        // RPSForm instance for interacting with the RPS form.
        public RPSForm rpsForm;

        // SoundPlayer instance for playing sound effects during the game.
        private SoundPlayer soundPlayer = new SoundPlayer();

        // Boolean indicating whether the player has won the game.
        public static bool isWin = false;

        // Constructor for RPSLogic, initializing RPSElements and RPSForm instances.
        public RPSLogic(RPSElements rpsElements, RPSForm rpsForm)
        {
            this.rpsElements = rpsElements;
            this.rpsForm = rpsForm;
        }

        // Event handler for button clicks representing the player's choice in the RPS game.
        public void GetChoice_Click(object sender, EventArgs e)
        {
            // Play a sound effect when the player makes a choice.
            soundPlayer.Stream = RPSResources.press;
            soundPlayer.Play();

            // Get the text (choice) of the button clicked by the player.
            string playerChoice = (sender as Button).Text.ToLower();

            // Get the computer's random choice.
            string computerChoice = GetCompPick();

            // Update the PictureBox images based on player and computer choices.
            UpdatePlayerPictureBox(rpsElements.PlayerRPS, playerChoice);
            UpdateCompPictureBox(rpsElements.CompRPS, computerChoice);

            // Determine the winner based on the choices made.
            DetermineWinner(playerChoice, computerChoice);
        }

        // Method to randomly choose the computer's pick (rock, paper, or scissors).
        public string GetCompPick()
        {
            Random random = new Random();
            string[] choices = { "rock", "paper", "scissors" };
            int index = random.Next(choices.Length);
            return choices[index];
        }

        // Method to determine the winner based on player and computer choices.
        public void DetermineWinner(string playerPick, string compPick)
        {
            // Check for a tie.
            if (playerPick == compPick)
            {
                MessageBox.Show("It's a Tie!");
            }
            // Check for player win conditions.
            else if ((playerPick == "rock" && compPick == "scissors") ||
                     (playerPick == "paper" && compPick == "rock") ||
                     (playerPick == "scissors" && compPick == "paper"))
            {
                // Play a winning sound effect.
                soundPlayer.Stream = RPSResources.win;
                soundPlayer.Play();

                // Set the isWin flag to true, display a win message, and close the form.
                isWin = true;
                MessageBox.Show("You Win!");
                rpsForm.CloseForm();
            }
            // If none of the above conditions are met, the player loses.
            else
            {
                // Play a losing sound effect and display a lose message.
                soundPlayer.Stream = RPSResources.lose;
                soundPlayer.Play();
                MessageBox.Show("You Lose!");
                rpsForm.CloseForm();
            }
        }

        // Method to update the player's PictureBox based on their choice.
        private void UpdatePlayerPictureBox(PictureBox pictureBox, string choice)
        {
            // Update the PictureBox image based on the player's choice.
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

            // Refresh the PictureBox to update the displayed image.
            pictureBox.Refresh();
        }

        // Method to update the computer's PictureBox based on its choice.
        private void UpdateCompPictureBox(PictureBox pictureBox, string choice)
        {
            // Update the PictureBox image based on the computer's choice.
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

            // Refresh the PictureBox to update the displayed image.
            pictureBox.Refresh();
        }
    }
}

