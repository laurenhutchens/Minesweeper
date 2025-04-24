/* Arie Gerard and Lauren Hutches 
* Cst-250
* Minesweeper 
* Bill Hughes
* 03/10/2025
*/

using MineSweeperClasses.Models;
using System;
using System.Windows.Forms;

namespace MinesweeperGUIAPP
{
    /// <summary>
    /// FrmPlay allows the user to configure the game by selecting board size and difficulty.
    /// These settings are passed back to FrmStart to initiate a new game.
    /// </summary>
    public partial class FrmPlay : Form
    {
        /// <summary>
        /// Gets or sets the difficulty level as a string (communicates with FrmStart).
        /// </summary>
        public string DifficultyLevel { get; set; }

        /// <summary>
        /// Default constructor for FrmPlay. Initializes components.
        /// </summary>
        public FrmPlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the initial values for the size and difficulty trackbars.
        /// Displays the difficulty level if set.
        /// </summary>
        public void FrmPlayLoadEH(object sender, EventArgs e)
        {
            // Show selected difficulty
            if (!string.IsNullOrEmpty(DifficultyLevel))
            {
                MessageBox.Show("Difficulty: " + DifficultyLevel);
            }

            // Set bounds for board size (5x5 to 25x25)
            trbSize.Minimum = 5;
            trbSize.Maximum = 25;
            trbSize.Value = 5;

            // Set bounds for difficulty (1 = easy, 3 = hard)
            trbDifficulty.Minimum = 1;
            trbDifficulty.Maximum = 3;
            trbDifficulty.Value = 1;
        }

        /// <summary>
        /// When Play button is clicked, the selected size and difficulty
        /// are sent to FrmStart and the play configuration form is hidden.
        /// </summary>
        private void BtnPlayClickEH(object sender, EventArgs e)
        {
            int size = trbSize.Value;
            int difficulty = trbDifficulty.Value;

            // Reference the main form and send data
            var frmstart = Application.OpenForms["FrmStart"] as FrmStart;
            if (frmstart != null)
            {
                frmstart.SizeText = size.ToString();
                frmstart.DifficultyText = difficulty.ToString();
            }

            // Hide this setup form
            this.Hide();
        }
    }
}
