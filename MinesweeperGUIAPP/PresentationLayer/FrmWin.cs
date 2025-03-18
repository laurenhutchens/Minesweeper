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
        public string PlayerName { get; set; }

        public int Score { get; set; }

        public FrmWin(int score)
        {
            InitializeComponent();

            Score = score;
            lblFinalScore.Text = score.ToString(); // Display the score as a string

           

        }

        private void FrmWin_Load(object sender, EventArgs e)
        {


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string playerName = txtName.Text;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter a player name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if player name is empty or whitespace
            }

            FrmLeaderBoard leaderBoard = new FrmLeaderBoard(playerName, Score);
            leaderBoard.Show();
        }
    }
}