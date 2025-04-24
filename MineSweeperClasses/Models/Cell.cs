/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */
namespace MineSweeperClasses.Models
{
    public class Cell
    {
        // Properties for row, column, and various game states.
        public int Row { get; }
        public int Column { get; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }
        public char DisplayChar { get; set; }

        // Constructor to initialize the cell
        public Cell(int row, int column, bool isBomb = false, bool hasSpecialReward = false)
        {
            Row = row;
            Column = column;
            IsBomb = isBomb;
            HasSpecialReward = hasSpecialReward;
            IsVisited = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            DisplayChar = '#'; // Default hidden state
        }

        // Method to reveal the cell.
        public void Reveal()
        {
            IsVisited = true;

            // Handle bomb display
            if (IsBomb)
            {
                DisplayChar = 'B';
            }
            else if (NumberOfBombNeighbors > 0)
            {
                DisplayChar = (char)(NumberOfBombNeighbors + '0');  // Convert number to char ('0'-'9')
            }
            else
            {
                DisplayChar = '.';  // Empty cell
            }
        }

        // Reset the cell for new game or restart
        public void Reset()
        {
            IsVisited = false;
            IsFlagged = false;
            DisplayChar = '#';
        }
    }
}
