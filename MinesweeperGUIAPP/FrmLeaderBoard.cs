using MineSweeperClasses.BuisnessLogicLayer;
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
    public partial class FrmLeaderBoard : Form
    {
        GameStat gameStat;

        BindingSource bindingSource = new BindingSource();
        public List<GameStat> statList = new List<GameStat>();
        public FrmLeaderBoard(string name, int score)
        {
            InitializeComponent();
            gameStat = new GameStat();
            gameStat.Name = name;
            gameStat.Score = score;
            gameStat.Date = DateTime.Now;
            gameStat.Id = statList.Count + 1;
            statList.Add(gameStat);

            bindingSource.DataSource = statList;

            dgvScoreBoard.DataSource = bindingSource;






        }

        private void FrmLeaderBoard_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Save 
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
