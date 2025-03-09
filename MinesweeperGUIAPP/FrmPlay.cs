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

        private void FrmPlayLoadEH(object sender, EventArgs e)
        {
            // Use the passed data
            if (!string.IsNullOrEmpty(DifficultyLevel))
            {
                MessageBox.Show("Difficulty: " + DifficultyLevel);
                //or set a label.text, etc.
            }

            // Set basic values for trbSize
            trbSize.Minimum = 1; // Example minimum value
            trbSize.Maximum = 10; // Example maximum value
            trbSize.Value = 5; // Example default value

            // Set basic values for trbDifficulty
            trbDifficulty.Minimum = 1; // Example minimum value
            trbDifficulty.Maximum = 10; // Example maximum value
            trbDifficulty.Value = 3; // Example default value
        }

        private void StartGame(int size, int difficulty)
        {
            // Create a gameboard array based on size.
            int[,] gameBoard = new int[size, size];

            // Set game difficulty.
            if (difficulty > 5)
            {
                // Make the game harder.
                // Example: Place more mines, reduce time limits, etc.
                MessageBox.Show("Hard Difficulty");
            }
            else
            {
                // Make the game easier.
                // Example: Place fewer mines, increase time limits, etc.
                MessageBox.Show("Easy Difficulty");
            }
        }

        //new methods
        private void BtnPlayClickEH(object sender, EventArgs e)
        {
            int size = trbSize.Value;
            int difficulty = trbDifficulty.Value;

            // Create an instance of your game logic class
            MinesweeperGameLogic game = new MinesweeperGameLogic(size, difficulty);

            // Store the game logic instance so you can access it later (e.g., in click handlers)
            this.Tag = game; // Store it in the form's Tag property

            // Create and display the game board in the UI
            CreateGameBoardUI(game.Board);

            // Optionally hide the difficulty selection controls
            trbSize.Visible = false;
            trbDifficulty.Visible = false;
            btnPlay.Visible = false;
            lblSize.Visible = false;
            lblDifficulty.Visible = false;
            lblPlayMinesweeper.Visible = false;
        }

        private void CreateGameBoardUI(BoardModel board)
        {
            // Clear any existing game board controls
            this.Controls.OfType<Button>().Where(b => b.Tag is Cell).ToList().ForEach(b => this.Controls.Remove(b));

            int buttonSize = 30; // Adjust button size as needed
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Button cellButton = new Button();
                    cellButton.Width = buttonSize;
                    cellButton.Height = buttonSize;
                    cellButton.Left = col * buttonSize;
                    cellButton.Top = row * buttonSize;
                    cellButton.Tag = board.Cells[row, col]; // Store the Cell object in the button's Tag
                    cellButton.Click += CellButtonClickEH; // Add click event handler
                    this.Controls.Add(cellButton);
                }
            }
        }

        private void CellButtonClickEH(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Cell cell = (Cell)clickedButton.Tag;
            MinesweeperGameLogic game = (MinesweeperGameLogic)this.Tag; // Retrieve the game logic instance

            if (game != null)
            {
                game.MakeMove(cell.Row, cell.Column);

                // Update the UI based on the game state
                UpdateGameBoardUI(game.Board);

                if (game.IsGameOver())
                {
                    HandleGameOver(game.CheckGameWin());
                }
            }
        }

        private void UpdateGameBoardUI(BoardModel board)
        {
            foreach (Button button in this.Controls.OfType<Button>().Where(b => b.Tag is Cell))
            {
                Cell cell = (Cell)button.Tag;
                if (cell.IsVisited)
                {
                    if (cell.IsBomb)
                    {
                        button.Text = "B"; // Or an image of a bomb
                        button.BackColor = Color.Red;
                    }
                    else
                    {
                        button.Text = cell.NumberOfBombNeighbors.ToString();
                        button.BackColor = Color.LightGray;
                    }
                }
                else if (cell.IsFlagged)
                {
                    button.Text = "F";
                }
                else
                {
                    button.Text = ""; // Hide the cell
                    button.BackColor = default(Color);
                }
            }
        }

        private void HandleGameOver(bool win)
        {
            if (win)
            {
                MessageBox.Show("You Win!");
            }
            else
            {
                MessageBox.Show("You Lose!");
            }
            // Optionally, reset the game or display a "Play Again" button
        }
    }
}
