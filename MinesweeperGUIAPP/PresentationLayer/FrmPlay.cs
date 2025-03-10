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

        private FrmStart frmStart;


        public FrmPlay()
        {

            InitializeComponent();

        }
        public void FrmPlayLoadEH(object sender, EventArgs e)
        {
            // Use the passed data
            if (!string.IsNullOrEmpty(DifficultyLevel))
            {
                MessageBox.Show("Difficulty: " + DifficultyLevel);
                //or set a label.text, etc.
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

        //new methods
        private void BtnPlayClickEH(object sender, EventArgs e)
        {
            int size = trbSize.Value;
            int difficulty = trbDifficulty.Value;
            var frmstart = Application.OpenForms["FrmStart"] as FrmStart;
            frmstart.SizeText = size.ToString();
            frmstart.DifficultyText = difficulty.ToString();
            this.Hide();  // Hide the current form
        }
      
    }
}