using MineSweeperClasses.Models;

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
}
