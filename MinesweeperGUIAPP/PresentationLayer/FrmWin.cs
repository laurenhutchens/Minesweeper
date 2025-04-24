/* Arie Gerard and Lauren Hutches 
* Cst-250
* Minesweeper 
* Bill Hughes
* 03/10/2025
*/

using System;
using System.Windows.Forms;

namespace MinesweeperGUIAPP.PresentationLayer
{
    /// <summary>
    /// FrmWin is shown when a game is won or completed.
    /// Displays the final score and time, and allows the player to save their name to the leaderboard.
    /// </summary>
    public partial class FrmWin : Form
    {
        /// <summary>
        /// Gets or sets the name entered by the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the player's final score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the time it took the player to finish the game.
        /// </summary>
        public TimeSpan GameTime { get; set; }

        /// <summary>
        /// Initializes the win form and sets score/time display.
        /// </summary>
        /// <param name="score">Final score achieved by the player</param>
        /// <param name="gameTime">Time taken to win the game</param>
        public FrmWin(int score, TimeSpan gameTime)
        {
            InitializeComponent();
            Score = score;
            GameTime = gameTime;
            lblFinalScore.Text = score.ToString(); // Display final score on label
        }

        /// <summary>
        /// Handles the save button click.
        /// Validates the name entry and opens the leaderboard form with the new data.
        /// </summary>
        private void BtnSaveClick(object sender, EventArgs e)
        {
            string playerName = txtName.Text;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter a player name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open leaderboard with this player's data
            FrmLeaderBoard leaderBoard = new FrmLeaderBoard(playerName, Score, GameTime);
            leaderBoard.Show();
        }
    }
}
