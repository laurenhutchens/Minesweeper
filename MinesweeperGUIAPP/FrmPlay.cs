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

        private void FrmPlayLoadEH(object sender, EventArgs e)
        {
            // Use the passed data
            if (!string.IsNullOrEmpty(DifficultyLevel))
            {
                MessageBox.Show("Difficulty: " + DifficultyLevel);
                //or set a label.text, etc.
            }
        }
    }
}
