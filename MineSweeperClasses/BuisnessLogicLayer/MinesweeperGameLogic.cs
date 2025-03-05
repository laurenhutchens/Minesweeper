using System;
using MineSweeperClasses.Models;

namespace MineSweeper.BusinessLogicLayer
{
    public class MinesweeperGameLogic
    {
        // Declare field for the board model (the game board)
        private BoardModel board;

        public MinesweeperGameLogic(int size, int difficulty)
        {
            // Initialize the board based on size and difficulty
            board = new BoardModel(size, difficulty);
        }

        // Method to get the current state of the board
        public BoardModel GetBoardModel()
        {
            return board;
        }

        /// <summary>
        /// Method to handle the player's move. It checks if the clicked cell is a bomb or not,
        /// and processes the move accordingly (reveals the cell, checks game status).
        /// </summary>
        /// <param name="row">The row of the clicked cell.</param>
        /// <param name="col">The column of the clicked cell.</param>
        public void MakeMove(int row, int col)
        {
           {
                if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                {
                    throw new ArgumentException("Invalid cell coordinates.");
                }

                // If the cell is already visited or flagged, we don't process it.
                var cell = board.Cells[row, col];
                if (cell.IsVisited || cell.IsFlagged)
                {
                    return;
                }

                // Visit the cell
                cell.IsVisited = true;

                // If it's a bomb, game over
                if (cell.IsBomb)
                {
                  // Set game status to Lost
                    RevealAllBombs(); // Reveal all bombs
                    return;
                }

                // If the cell has no neighboring bombs, use flood fill to reveal adjacent safe cells
                if (cell.NumberOfBombNeighbors == 0)
                {
                    FloodFill(row, col);
                }

                // After each move, check if the game has been won
                if (CheckGameWin())
                {
                   
                }
                else
                {
                   
                }
            }

        }

        /// <summary>
        /// Method to check if the game has been won. 
        /// The game is won when all non-bomb cells have been revealed.
        /// </summary>
        /// <returns>True if the game is won, false otherwise.</returns>
        public bool CheckGameWin()
        {
            foreach (var cell in board.Cells)
            {
                // If there's any non-bomb cell that's not revealed, the game is not won yet.
                if (!cell.IsBomb && !cell.IsVisited)
                {
                    return false;
                }
            }

            return true; // All non-bomb cells are revealed
        }

        /// <summary>
        /// Recursively reveals all connected cells if they have no adjacent bombs (flood fill).
        /// </summary>
        private void FloodFill(int row, int col)
        {
            // Perform flood fill if the cell is within bounds and is safe
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size ||
                board.Cells[row, col].IsVisited || board.Cells[row, col].IsBomb)
            {
                return;
            }

            var cell = board.Cells[row, col];
            cell.IsVisited = true;

            // If the current cell has no bomb neighbors, flood fill its neighbors
            if (cell.NumberOfBombNeighbors == 0)
            {
                FloodFill(row - 1, col); // Up
                FloodFill(row + 1, col); // Down
                FloodFill(row, col - 1); // Left
                FloodFill(row, col + 1); // Right
            }
        }

        /// <summary>
        /// Reveals all bombs on the board (used when the game is lost).
        /// </summary>
        private void RevealAllBombs()
        {
            foreach (var cell in board.Cells)
            {
                if (cell.IsBomb)
                {
                    cell.IsVisited = true;
                }
            }
        }

        /// <summary>
        /// Marks a cell as flagged or unflagged.
        /// </summary>
        /// <param name="row">The row of the cell to flag/unflag.</param>
        /// <param name="col">The column of the cell to flag/unflag.</param>
        public void ToggleFlag(int row, int col)
        {
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                throw new ArgumentException("Invalid cell coordinates.");
            }

            var cell = board.Cells[row, col];
            if (cell.IsVisited)
            {
                return; // Can't flag a visited cell
            }

            cell.IsFlagged = !cell.IsFlagged;
        }

        /// <summary>
        /// Uses a special bonus like a hint to help the player.
        /// </summary>
        /// <param name="rewardType">The type of reward (e.g., "Hint").</param>
        /// <returns>True if the reward was used, false if not.</returns>
        public bool UseSpecialBonus(string rewardType)
        {
            return board.UseSpecialBonus(rewardType);
        }

        /// <summary>
        /// Returns whether the game is over (either won or lost).
        /// </summary>
        /// <returns>True if the game is over, false if ongoing.</returns>
      
       
        /// <summary>
        /// Get the current game status (InProgress, Won, Lost).
        /// </summary>
        /// <returns>The current game status.</returns>
      
    
    }
}
