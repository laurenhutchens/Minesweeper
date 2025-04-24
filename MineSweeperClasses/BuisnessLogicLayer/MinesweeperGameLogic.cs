/*
* Milestone 6: Game Extensions
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 4/27/2005
*/

using MineSweeperClasses.Models;

public class MinesweeperGameLogic
{
    public BoardModel Board { get; private set; }
    private int boardSize;
    private int difficulty;
    private Random rand = new Random();

    /// <summary>
    /// Initializes the game logic with a specified board size and difficulty.
    /// </summary>
    public MinesweeperGameLogic(int size, int difficulty)
    {
        this.boardSize = size;
        this.difficulty = difficulty;

        Board = new BoardModel(boardSize, difficulty);
        InitializeBoard();
    }

    /// <summary>
    /// Sets up the board, placing bombs and calculating neighbors.
    /// </summary>
    private void InitializeBoard()
    {
        for (int row = 0; row < boardSize; row++)
            for (int col = 0; col < boardSize; col++)
                Board.Cells[row, col] = new Cell(row, col);

        int totalBombs = GetTotalBombsForDifficulty(difficulty);
        PlaceBombs(totalBombs);
        CalculateNeighboringBombs();
    }

    /// <summary>
    /// Returns number of bombs based on difficulty level.
    /// </summary>
    private int GetTotalBombsForDifficulty(int difficulty)
    {
        return difficulty switch
        {
            1 => (int)(boardSize * boardSize * 0.1),
            2 => (int)(boardSize * boardSize * 0.15),
            3 => (int)(boardSize * boardSize * 0.2),
            _ => 0
        };
    }

    /// <summary>
    /// Randomly places bombs on the board.
    /// </summary>
    private void PlaceBombs(int totalBombs)
    {
        int bombsPlaced = 0;
        while (bombsPlaced < totalBombs)
        {
            int row = rand.Next(boardSize);
            int col = rand.Next(boardSize);

            if (!Board.Cells[row, col].IsBomb)
            {
                Board.Cells[row, col].IsBomb = true;
                bombsPlaced++;
            }
        }
    }

    /// <summary>
    /// Makes a move by visiting a cell. Triggers flood fill if applicable.
    /// </summary>
    public void MakeMove(int row, int col)
    {
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size)
            throw new ArgumentException("Invalid cell coordinates.");

        var cell = Board.Cells[row, col];
        if (cell.IsVisited || cell.IsFlagged)
            return;

        if (cell.IsBomb)
        {
            RevealAllBombs();
            return;
        }

        if (cell.NumberOfBombNeighbors == 0)
            FloodFill(row, col);

        // Game win check handled externally
    }

    /// <summary>
    /// Reveals all bombs on the board (used when the game is lost).
    /// </summary>
    private void RevealAllBombs()
    {
        foreach (var cell in Board.Cells)
            if (cell.IsBomb)
                cell.IsVisited = true;
    }

    /// <summary>
    /// Performs flood fill from a cell with zero bomb neighbors.
    /// </summary>
    private void FloodFill(int row, int col)
    {
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size)
            return;

        var cell = Board.Cells[row, col];
        if (cell.IsVisited || cell.IsBomb)
            return;

        cell.IsVisited = true;

        if (cell.NumberOfBombNeighbors == 0)
        {
            FloodFill(row - 1, col);
            FloodFill(row + 1, col);
            FloodFill(row, col - 1);
            FloodFill(row, col + 1);
        }
    }

    /// <summary>
    /// Checks if all non-bomb cells are revealed, which means the game is won.
    /// </summary>
    public bool CheckGameWin()
    {
        foreach (var cell in Board.Cells)
            if (!cell.IsBomb && !cell.IsVisited)
                return false;

        return true;
    }

    /// <summary>
    /// Flags or unflags a cell.
    /// </summary>
    public void ToggleFlag(int row, int col)
    {
        if (row < 0 || row >= Board.Size || col < 0 || col >= Board.Size)
            throw new ArgumentException("Invalid cell coordinates.");

        var cell = Board.Cells[row, col];
        if (!cell.IsVisited)
            cell.IsFlagged = !cell.IsFlagged;
    }

    /// <summary>
    /// Uses a special game reward (currently only "Hint").
    /// </summary>
    public bool UseSpecialBonus(string rewardType)
    {
        return Board.UseSpecialBonus(rewardType);
    }

    /// <summary>
    /// Returns true if the game is over (either won or lost).
    /// </summary>
    public bool IsGameOver()
    {
        return CheckGameWin() || Board.Cells.Cast<Cell>().Any(cell => cell.IsBomb && cell.IsVisited);
    }

    /// <summary>
    /// Calculates and stores bomb neighbor counts for all cells.
    /// </summary>
    private void CalculateNeighboringBombs()
    {
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (Board.Cells[row, col].IsBomb) continue;

                int bombCount = 0;
                for (int r = -1; r <= 1; r++)
                {
                    for (int c = -1; c <= 1; c++)
                    {
                        int nRow = row + r;
                        int nCol = col + c;
                        if (nRow >= 0 && nRow < boardSize && nCol >= 0 && nCol < boardSize &&
                            Board.Cells[nRow, nCol].IsBomb)
                        {
                            bombCount++;
                        }
                    }
                }
                Board.Cells[row, col].NumberOfBombNeighbors = bombCount;
            }
        }
    }

    /// <summary>
    /// Returns the board model associated with this logic.
    /// </summary>
    public BoardModel GetBoardModel() => Board;

    /// <summary>
    /// Returns a random bomb location from the board.
    /// </summary>
    public (int, int)? GetRandomBombCoordinates()
    {
        List<(int, int)> bombCoordinates = new();
        for (int row = 0; row < boardSize; row++)
            for (int col = 0; col < boardSize; col++)
                if (Board.Cells[row, col].IsBomb)
                    bombCoordinates.Add((row, col));

        if (bombCoordinates.Count == 0)
            return null;

        return bombCoordinates[rand.Next(bombCoordinates.Count)];
    }
}
