/*
* Milestone 6: Game Extensions
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 4/27/2005
*/

namespace MineSweeperClasses.Models
{
    /// <summary>
    /// Represents a single cell in the Minesweeper board.
    /// Each cell can store position, whether it's a bomb or flagged, and its display state.
    /// </summary>
    public class Cell
    {
        // Position of the cell in the grid
        public int Row { get; }
        public int Column { get; }

        // Game state flags
        public bool IsVisited { get; set; }      // True if the player has revealed this cell
        public bool IsBomb { get; set; }         // True if the cell contains a bomb
        public bool IsFlagged { get; set; }      // True if the player has flagged this cell

        // Game logic
        public int NumberOfBombNeighbors { get; set; } // Number of adjacent cells that are bombs
        public bool HasSpecialReward { get; set; }     // Indicates if the cell contains a special reward (e.g., hint)

        // Display character (for console use or simplified output)
        public char DisplayChar { get; set; }

        /// <summary>
        /// Initializes a new cell with default state, allowing optional bomb/reward pre-setting.
        /// </summary>
        public Cell(int row, int column, bool isBomb = false, bool hasSpecialReward = false)
        {
            Row = row;
            Column = column;
            IsBomb = isBomb;
            HasSpecialReward = hasSpecialReward;
            IsVisited = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            DisplayChar = '#'; // Default character when cell is hidden
        }

        /// <summary>
        /// Marks the cell as revealed and updates the DisplayChar.
        /// </summary>
        public void Reveal()
        {
            IsVisited = true;

            if (IsBomb)
            {
                DisplayChar = 'B'; // Bomb
            }
            else if (NumberOfBombNeighbors > 0)
            {
                DisplayChar = (char)(NumberOfBombNeighbors + '0'); // Display number of neighbors
            }
            else
            {
                DisplayChar = '.'; // Empty cell
            }
        }

        /// <summary>
        /// Resets the cell to its initial hidden state.
        /// Useful when restarting the game.
        /// </summary>
        public void Reset()
        {
            IsVisited = false;
            IsFlagged = false;
            DisplayChar = '#';
        }
    }
}
