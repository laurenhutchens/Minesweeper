/* Arie Gerard and Lauren Hutches 
* Cst-250
* Minesweeper 
* Bill Hughes
* 03/10/2025
*/

using MineSweeperClasses.BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinesweeperGUIAPP
{
    /// <summary>
    /// Represents the Leaderboard form that displays game stats such as player names, scores,
    /// and game duration. Allows sorting and file operations for persistence.
    /// </summary>
    public partial class FrmLeaderBoard : Form
    {
        private List<GameStat> statList = new List<GameStat>(); // Stores game statistics
        private BindingSource bindingSource = new BindingSource(); // Binds data to DataGridView

        /// <summary>
        /// Constructor to initialize leaderboard with a new game result.
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="score">Player score</param>
        /// <param name="gameTime">Time taken to complete the game</param>
        public FrmLeaderBoard(string name, int score, TimeSpan gameTime)
        {
            InitializeComponent();

            var gameStat = new GameStat
            {
                Id = statList.Count + 1,
                Name = name,
                Score = score,
                Date = DateTime.Now,
                GameTime = gameTime
            };

            statList.Add(gameStat);
            bindingSource.DataSource = statList;
            dgvScoreBoard.DataSource = bindingSource;

            SetupDataGridView();
        }

        /// <summary>
        /// Ensures the binding source is refreshed when the form loads.
        /// </summary>
        private void FrmLeaderBoardLoad(object sender, EventArgs e)
        {
            bindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Configures the columns of the DataGridView for display.
        /// </summary>
        private void SetupDataGridView()
        {
            if (dgvScoreBoard.Columns.Count == 0)
            {
                dgvScoreBoard.AutoGenerateColumns = false;

                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true });
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true });
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Score", DataPropertyName = "Score", ReadOnly = true });
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", ReadOnly = true, DefaultCellStyle = { Format = "MM/dd/yyyy" } });
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Game Time", DataPropertyName = "GameTime", ReadOnly = true, DefaultCellStyle = { Format = @"mm\:ss" } });
            }
        }

        /// <summary>
        /// Loads a JSON file containing game statistics into the leaderboard.
        /// </summary>
        private void TsmLoadClickEH(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Load Leaderboard";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var loadedData = MineSweeperClasses.DataAccessLayer.MinesweeperDAO.TsmLoad<List<GameStat>>(openFileDialog.FileName);
                    if (loadedData != null)
                    {
                        statList = loadedData;
                        bindingSource.DataSource = statList;
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("File loaded!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to load leaderboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Closes the leaderboard form.
        /// </summary>
        private void TsmExitClickEH(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sorts the leaderboard by player name in ascending order.
        /// </summary>
        private void TsmByNameClickEH(object sender, EventArgs e)
        {
            statList.Sort((a, b) => a.Name.CompareTo(b.Name));
            bindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Sorts the leaderboard by score in descending order.
        /// </summary>
        private void TsmByScoreClickEH(object sender, EventArgs e)
        {
            statList.Sort((a, b) => b.Score.CompareTo(a.Score));
            bindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Sorts the leaderboard by date of game.
        /// </summary>
        private void TsmByDateClickEH(object sender, EventArgs e)
        {
            statList.Sort((a, b) => a.Date.CompareTo(b.Date));
            bindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Saves the current leaderboard stats to a JSON file.
        /// </summary>
        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Leaderboard";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var gameData = GetGameDataToSave();
                    MineSweeperClasses.DataAccessLayer.MinesweeperDAO.TsmSave(gameData, saveFileDialog.FileName);
                    MessageBox.Show("File saved!");
                }
                else
                {
                    MessageBox.Show("Save Failed");
                }
            }
        }

        /// <summary>
        /// Returns the list of game statistics to be saved.
        /// </summary>
        private object GetGameDataToSave()
        {
            return statList;
        }
    }
}
