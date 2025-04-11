/* Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 * 04/11/2025
 */
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

        /// <summary>
        /// Event handler to load the leaderboard form and display the game statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLeaderBoardLoad(object sender, EventArgs e)
        {
            // Ensure the leaderboard is displayed correctly when the form loads
            bindingSource.ResetBindings(false);
        }
        /// <summary>
        /// method to set up the data grid view 
        /// </summary>
        private void SetupDataGridView()
        {
            // Set column headers if not already added
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

        /// <summary>
        /// Event handler to load a file with game statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmLoadClickEH(object sender, EventArgs e)
        {
            // method to load the file
        }
        /// <summary>
        /// Event handler toe xit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmExitClickEH(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// button to orginize by name 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TsmByNameClickEH(object sender, EventArgs e)
        {
            // Sort by name and refresh the DataGridView
            statList.Sort((a, b) => a.Name.CompareTo(b.Name));
            bindingSource.ResetBindings(false);
        }
        /// <summary>
        /// Button to Orginize by score 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmByScoreClickEH(object sender, EventArgs e)
        {
            // Sort by score in descending order and refresh
            statList.Sort((a, b) => b.Score.CompareTo(a.Score));
            bindingSource.ResetBindings(false);
        }
        /// <summary>
        /// Button to orginize by date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TsmByDateClickEH(object sender, EventArgs e)
        {
            // Sort by date and refresh
            statList.Sort((a, b) => a.Date.CompareTo(b.Date));
            bindingSource.ResetBindings(false);
        }

        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            // To save the file 
        }
    }
}
