/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */
//Todo. make both the visable lables invsiable. whoops. 
using MineSweeperClasses.Models;
using static System.Formats.Asn1.AsnWriter;
public class MinesweeperGameLogic
{
    public BoardModel Board { get; private set; }
    private int boardSize;
    private int difficulty;
    private Random rand = new Random();

    public MinesweeperGameLogic(int size, int difficulty)
    {
        this.boardSize = size;
        this.difficulty = difficulty;

        // Initialize the board with the given size and difficulty
        Board = new BoardModel(boardSize, difficulty);

        // Initialize the game board
        InitializeBoard();
    }
    private void InitializeBoard()
    {
        // First, clear any previous setup on the board
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                // Create a new cell for each position on the board
                Board.Cells[row, col] = new Cell(row, col);
            }
        }
        // Determine number of bombs based on difficulty
        int totalBombs = GetTotalBombsForDifficulty(difficulty);

        // Randomly place bombs on the board
        PlaceBombs(totalBombs);

        // After placing bombs, calculate neighboring bombs for each non-bomb cell
        CalculateNeighboringBombs();
    }
    
    /// <summary>
    /// Gets the total bombs per difficulty. 
    /// </summary>
    /// <param name="difficulty"></param>
    /// <returns></returns>
    private int GetTotalBombsForDifficulty(int difficulty)
    {
        // The number of bombs changes based on difficulty
        switch (difficulty)
        {
            case 1: return (int)(boardSize * boardSize * 0.1); // Easy: 10% of cells are bombs
            case 2: return (int)(boardSize * boardSize * 0.15); // Medium: 15% of cells are bombs
            case 3: return (int)(boardSize * boardSize * 0.2); // Hard: 20% of cells are bombs
            default: return 0;
        }
    }

    /// <summary>
    /// Method to place the bombs
    /// </summary>
    /// <param name="totalBombs"></param>
    private void PlaceBombs(int totalBombs)
    {
        int bombsPlaced = 0;
        while (bombsPlaced < totalBombs)
        {
            int row = rand.Next(boardSize);
            int col = rand.Next(boardSize);

            // Place a bomb only if the cell doesn't already have a bomb
            if (!Board.Cells[row, col].IsBomb)
            {
                Board.Cells[row, col].IsBomb = true;
                bombsPlaced++;
            }
        }
    }

    /// <summary>
    /// Method to handle the player's move. It checks if the clicked cell is a bomb or not,
    /// and processes the move accordingly (reveals the cell, checks game status).
    /// </summary>
    /// <param name="row">The row of the clicked cell.</param>
    /// <param name="col">The column of the clicked cell.</param>
    public void MakeMove(int row, int col)
    {
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size)
        {
            throw new ArgumentException("Invalid cell coordinates.");
        }

        // If the cell is already visited or flagged, we don't process it.
        var cell = Board.Cells[row, col];
        if (cell.IsVisited || cell.IsFlagged)
        {
            return;
        }

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
            //handled elsewhere for GUI 
        }
    }

    /// <summary>
    /// Method to check if the game has been won. 
    /// The game is won when all non-bomb cells have been revealed.
    /// </summary>
    /// <returns>True if the game is won, false otherwise.</returns>
    public bool CheckGameWin()
    {
        foreach (var cell in Board.Cells)
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
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size ||
            Board.Cells[row, col].IsVisited || Board.Cells[row, col].IsBomb)
        {
            return;
        }

        var cell = Board.Cells[row, col];
        cell.IsVisited = true;

        // If the current cell has no bomb neighbors, flood fill its neighbors
        if (cell.NumberOfBombNeighbors == 0)
        {
            FloodFill(row - 1, col); // Up
            FloodFill(row + 1, col); // Down
            FloodFill(row, col - 1); // Left
            FloodFill(row, col + 1); // Right
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Reveals all bombs on the board (used when the game is lost).
    /// </summary>
    private void RevealAllBombs()
    {
        foreach (var cell in Board.Cells)
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
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size)
        {
            throw new ArgumentException("Invalid cell coordinates.");
        }

        var cell = Board.Cells[row, col];
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
        return Board.UseSpecialBonus(rewardType);
    }

    /// <summary>
    /// Returns whether the game is over (either won or lost).
    /// </summary>
    /// <returns>True if the game is over, false if ongoing.</returns>
    public bool IsGameOver()
    {
        return CheckGameWin() || Board.Cells.Cast<Cell>().Any(cell => cell.IsBomb && cell.IsVisited);
    }
  
    /// <summary>
    /// Calculuate the number of neighboring bombs. 
    /// </summary>
    private void CalculateNeighboringBombs()
    {
        // Iterate through each cell on the board
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                // Skip cells that are bombs
                if (Board.Cells[row, col].IsBomb)
                {
                    continue;
                }

                // Calculate the number of bombs in neighboring cells
                int bombCount = 0;

                // Check all adjacent cells (8 directions: up, down, left, right, diagonals)
                for (int r = -1; r <= 1; r++)
                {
                    for (int c = -1; c <= 1; c++)
                    {
                        int neighborRow = row + r;
                        int neighborCol = col + c;

                        // Make sure the neighbor is within bounds
                        if (neighborRow >= 0 && neighborRow < boardSize &&
                            neighborCol >= 0 && neighborCol < boardSize &&
                            Board.Cells[neighborRow, neighborCol].IsBomb)
                        {
                            bombCount++;
                        }
                    }
                }

                // Set the number of neighboring bombs for the current cell
                Board.Cells[row, col].NumberOfBombNeighbors = bombCount;

               
            }
        }
    }
    /// <summary>
    /// Method to return the board model 
    /// </summary>
    /// <returns></returns>
    public BoardModel GetBoardModel()
    {
        return Board;
    }
    /// <summary>
    /// Gets the coordinates of a random bomb from the board.
    /// </summary>
    /// <returns>A tuple containing the (row, column) coordinates of the bomb, or null if no bombs are found.</returns>
    public (int, int)? GetRandomBombCoordinates()
    {
        // Create a list to store all bomb cells
        List<(int, int)> bombCoordinates = new List<(int, int)>();

        // Iterate through the board to find bomb cells
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (Board.Cells[row, col].IsBomb)
                {
                    bombCoordinates.Add((row, col));
                }
            }
        }

        // If there are no bombs, return null
        if (bombCoordinates.Count == 0)
        {
            return null;
        }

        // Randomly select a bomb's coordinates from the list
        int randomIndex = rand.Next(bombCoordinates.Count);
        return bombCoordinates[randomIndex];
    }
}
