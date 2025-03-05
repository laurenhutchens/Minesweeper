using MineSweeperClasses.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using static MineSweeperClasses.Models.BoardModel;

namespace MineSweeperGUI
{
    public partial class MineSweeperGame : Form
    {
        public MinesweeperGameLogic gameLogic; // Game logic to manage the board and game state
        public BoardModel board; // Reference to the board model to manage cells and status

        public MineSweeperGame()
        {
            InitializeComponent();
        }

        // Start the game when the button is clicked
        public void btnStartGame_Click(object sender, EventArgs e)
        {
            int boardSize = hsbSize.Value; // hsbSize is the TrackBar control for size
            int difficulty = hsbDifficulty.Value; // hsbDifficulty is the TrackBar control for difficulty

            // Validate the values if necessary (ensure they're within the acceptable range)
            if (boardSize < 5 || boardSize > 20)
            {
                MessageBox.Show("Board size must be between 5 and 20.");
                return;
            }

            if (difficulty < 1 || difficulty > 3)
            {
                MessageBox.Show("Difficulty must be between 1 and 3.");
                return;
            }

            // Initialize the game logic with the chosen size and difficulty
            gameLogic = new MinesweeperGameLogic(boardSize, difficulty);
            board = gameLogic.Board; // Retrieve the board from game logic, no need to initialize it again here.

            // Create a grid of buttons based on the board size
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    // Create a new button
                    Button btn = new Button();
                    btn.Width = 40;
                    btn.Height = 40;
                    btn.Tag = new Cell(row, col);  // Associate this button with a cell
                    btn.Click += (s, e) => Btn_Click(s, e);  // Pass row and col to the handler

                    // Position the button in a grid layout
                    btn.Left = col * 40;
                    btn.Top = row * 40;

                    // Add the button to the form
                    this.Controls.Add(btn);
                }
            }

            // Now that the board is initialized, update the board cells with bombs and neighboring bomb counts
            board.InitializeBoard();  // This will place bombs and calculate neighboring bomb counts
        }

        // Handle the button click to reveal a cell or flag it
        private void Btn_Click(object sender, EventArgs e)
        {
            // Retrieve the Button that was clicked
            Button btn = sender as Button;
            if (btn == null) return;

            // Retrieve the Cell associated with the button from its Tag property
            Cell clickedCell = btn.Tag as Cell;
            if (clickedCell == null) return;

            int row = clickedCell.Row;
            int col = clickedCell.Column;

            // Ensure that row and col are within the board bounds
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                MessageBox.Show("Cell out of bounds.");
                return;
            }

            // Check if the clicked cell is a bomb
            if (clickedCell.IsBomb)
            {
                MessageBox.Show("Game Over! You hit a bomb.");
                // Handle game over scenario (e.g., reveal all bombs, disable further clicks, etc.)
                RevealAllCells(); // Reveal all cells when game over
            }
            else
            {
                // Reveal the cell (or handle other logic based on the number of neighboring bombs)
                clickedCell.Reveal();

                // Update the button's display based on the revealed cell
                btn.Text = clickedCell.DisplayChar.ToString();

                // Check for win/loss conditions (optional)
                if (board.DetermineGameStatus() == BoardModel.GameStatus.Won)
                {
                    MessageBox.Show("You won the game!");
                }
            }
        }

        // Reset the game when the reset button is clicked
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Get the current board size and difficulty
            int boardSize = hsbSize.Value;
            int difficulty = hsbDifficulty.Value;

            // Reset the game logic (recreate the game logic instance)
            gameLogic = new MinesweeperGameLogic(boardSize, difficulty);
            board = gameLogic.Board; // Ensure that board is reinitialized

            // Loop through all buttons to reset the state
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                // Get the associated Cell object for this button (the Cell contains the game state)
                Cell cell = (Cell)btn.Tag;

                // Reset the button's display based on the cell's state
                if (cell.IsFlagged)
                {
                    // Keep the flag visible for flagged cells
                    btn.Text = "F";  // 'F' for flagged cell
                    btn.BackColor = Color.Yellow; // Optionally change color for flagged cells
                }
                else
                {
                    // Reset the button text to hidden state for non-flagged cells
                    btn.Text = "#";  // Reset to hidden state
                    btn.BackColor = Color.LightGray; // Reset button background color
                    btn.Enabled = true; // Ensure buttons are enabled for the new game
                }

                // Optionally, reset revealed cells (if game was reset and you're revealing cells)
                if (cell.IsVisited)
                {
                    // For revealed cells, we can show the bomb or the number of bombs around it
                    if (cell.IsBomb)
                    {
                        btn.Text = "B"; // Show a bomb
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        btn.Text = cell.NumberOfBombNeighbors.ToString(); // Show the number of neighboring bombs
                    }
                    else
                    {
                        btn.Text = "."; // Empty cell
                    }

                    btn.Enabled = false; // Disable the button so it can't be clicked again
                }
            }
        }

        // Reveal all cells (can be called when the game ends)
        private void RevealAllCells()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                Cell cell = (Cell)btn.Tag;

                if (cell.IsBomb)
                {
                    btn.Text = "B";
                    btn.BackColor = Color.Red;
                }
                else
                {
                    if (cell.NumberOfBombNeighbors > 0)
                    {
                        btn.Text = cell.NumberOfBombNeighbors.ToString();
                    }
                    else
                    {
                        btn.Text = ".";
                    }

                    btn.BackColor = Color.LightGray;
                }

                btn.Enabled = false; // Disable buttons when the game ends
            }
        }
    }
}
