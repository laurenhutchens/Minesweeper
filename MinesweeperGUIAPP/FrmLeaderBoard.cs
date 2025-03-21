using MineSweeperClasses.BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinesweeperGUIAPP
{
    public partial class FrmLeaderBoard : Form
    {
        // List to store game statistics
        private List<GameStat> statList = new List<GameStat>();
        private BindingSource bindingSource = new BindingSource();

        public FrmLeaderBoard(string name, int score, TimeSpan gameTime)
        {
            InitializeComponent();

            // Create a new game stat record
            var gameStat = new GameStat
            {
                Id = statList.Count + 1, // Generate a new ID
                Name = name,
                Score = score,
                Date = DateTime.Now,
                GameTime = gameTime
            };

            // Add the new record to the list
            statList.Add(gameStat);

            // Bind the list to the DataGridView
            bindingSource.DataSource = statList;
            dgvScoreBoard.DataSource = bindingSource;

            // Customize DataGridView columns
            SetupDataGridView();
        }

        private void FrmLeaderBoard_Load(object sender, EventArgs e)
        {
            // Ensure the leaderboard is displayed correctly when the form loads
            bindingSource.ResetBindings(false);
        }

        private void SetupDataGridView()
        {
            // Set column headers if not already defined
            if (dgvScoreBoard.Columns.Count == 0)
            {
                dgvScoreBoard.AutoGenerateColumns = false;

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    ReadOnly = true
                });

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    DataPropertyName = "Name",
                    ReadOnly = true
                });

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Score",
                    DataPropertyName = "Score",
                    ReadOnly = true
                });

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Date",
                    DataPropertyName = "Date",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "MM/dd/yyyy" }
                });

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Game Time",
                    DataPropertyName = "GameTime",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = @"mm\:ss" } // Format TimeSpan
                });
            }
        }

        // Menu handlers can be implemented here if needed
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logic to load leaderboard data from a file or database
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sort by name and refresh the DataGridView
            statList.Sort((a, b) => a.Name.CompareTo(b.Name));
            bindingSource.ResetBindings(false);
        }

        private void ByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sort by score in descending order and refresh
            statList.Sort((a, b) => b.Score.CompareTo(a.Score));
            bindingSource.ResetBindings(false);
        }

        private void ByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sort by date and refresh
            statList.Sort((a, b) => a.Date.CompareTo(b.Date));
            bindingSource.ResetBindings(false);
        }
    }
}
