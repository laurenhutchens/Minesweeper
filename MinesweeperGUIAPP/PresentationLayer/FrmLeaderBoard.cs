/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
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
        private TimeSpan averageTime = new TimeSpan();

        /// <summary>
        /// Passes specific perameters for game logic. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="gameTime"></param>
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

                //Add ID
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    ReadOnly = true
                });
                //Add Name
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    DataPropertyName = "Name",
                    ReadOnly = true
                });

                //Add Score
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Score",
                    DataPropertyName = "Score",
                    ReadOnly = true
                });

                //Add Date
                dgvScoreBoard.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Date",
                    DataPropertyName = "Date",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "MM/dd/yyyy" }
                });

                //Add GameTime
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Load Leaderboard";

                // Set a default directory dynamically
                string defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.InitialDirectory = defaultDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    var loadedData = MineSweeperClasses.DataAccessLayer.MinesweeperDAO.TsmLoad<List<GameStat>>(filePath);

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
        /// <summary>
        /// Tsm to save 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Leaderboard";

                // Set a default directory dynamically
                string defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.InitialDirectory = defaultDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    var gameData = GetGameDataToSave();
                    MineSweeperClasses.DataAccessLayer.MinesweeperDAO.TsmSave(gameData, filePath);
                    MessageBox.Show("File saved!");
                }
                else
                {
                    MessageBox.Show("Save Failed");
                }
            }
        }
        /// <summary>
        /// Method To Get Game Data and save it. 
        /// </summary>
        /// <returns></returns>
        private object GetGameDataToSave()
        {
            return statList;
        }
 
        /// <summary>
        /// Button to calculate the average score and display it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalculateAverageClickEH(object sender, EventArgs e)
        {
            //calculate the average score from the gamestat class using the stalist. 
            double averageScore = GameStat.CalculateAverageScore(statList);
            lblAverageScore.Text = $"Average Score: {averageScore:F2}";
        }

        /// <summary>
        /// Button to calculate the average game time and display it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalculateAverageTimeClickEH(object sender, EventArgs e)
        {   
            //Calculate the average time using the gamestat logic using the statlist. 
            TimeSpan averageTime = GameStat.CalculateAverageGameTime(statList);
            lblAverageTime.Text = $"Average Time: {averageTime:hh\\:mm\\:ss}";
        }
    }
}
