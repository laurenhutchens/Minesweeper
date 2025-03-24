/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUIAPP.PresentationLayer
{
    public partial class FrmWin : Form
    {
        // Setting the properties of the player name, score, and game time
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public TimeSpan GameTime { get; set; }
        public FrmWin(int score, TimeSpan gameTime)
        {
            InitializeComponent();
            Score = score;
            GameTime = gameTime;
            lblFinalScore.Text = score.ToString(); // Display the score as a string
        }

       
        private void BtnSaveClick(object sender, EventArgs e)
        {
            string playerName = txtName.Text;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter a player name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if player name is empty or whitespace
            }
            FrmLeaderBoard leaderBoard = new FrmLeaderBoard(playerName, Score, GameTime);
            leaderBoard.Show();
        }
    }
}