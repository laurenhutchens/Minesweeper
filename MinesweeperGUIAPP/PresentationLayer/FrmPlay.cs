/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */

using MineSweeperClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUIAPP
{
    public partial class FrmPlay : Form
    {
        public string DifficultyLevel { get; set; }
        public FrmPlay()
        {
            InitializeComponent();
        }
        /// <summary>
        /// To load the trbs and their minimun and max values. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FrmPlayLoadEH(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(DifficultyLevel))
            {
                MessageBox.Show("Difficulty: " + DifficultyLevel);
            }
             // Set basic values for trbSize
            trbSize.Minimum = 5; 
            trbSize.Maximum = 25; 
            trbSize.Value = 5; 

            // Set basic values for trbDifficulty
            trbDifficulty.Minimum = 1; 
            trbDifficulty.Maximum = 3; 
            trbDifficulty.Value = 1; 

        }
        /// <summary>
        /// CLicke event to play and pass the data from teh secondary form to the main form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayClickEH(object sender, EventArgs e)
        {
            //grabbing the size from the difficulty 
            
            int size = trbSize.Value;
            int difficulty = trbDifficulty.Value;
            //using application to grab data from form start and send it to form start 
            var frmstart = Application.OpenForms["FrmStart"] as FrmStart;

            frmstart.SizeText = size.ToString();
            frmstart.DifficultyText = difficulty.ToString();

            this.Hide();  // Hide the current form
        }
      
    }
}