/*
* Milestone 6: Game Extensions
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 4/27/2005
*/

using System;
using System.Collections.Generic;

namespace MineSweeperClasses.Models
{
    /// <summary>
    /// Represents the state of the Minesweeper game board,
    /// including cell layout, bomb and reward placement, and game logic like win/loss detection.
    /// </summary>
    public class BoardModel
    {
        // Board configuration
        public int Size { get; }
        public int Difficulty { get; }
        public Cell[,] Cells { get; private set; }

        // Game metadata
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Game status options
        public enum GameStatus { InProgress, Won, Lost }

        // Internal random generator
        private readonly Random _random = new Random();

        // Available rewards (e.g., hints)
        public Dictionary<string, int> AvailableRewards { get; private set; }

        /// <summary>
        /// Constructor to initialize a board model with size and difficulty.
        /// </summary>
        public BoardModel(int size, int difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            RewardsRemaining = 0;

            InitializeCells();
            InitializeBoard();
        }

        /// <summary>
        /// Initializes all cells in the grid with default state.
        /// </summary>
        private void InitializeCells()
        {
            for (int row = 0; row < Size; row++)
                for (int col = 0; col < Size; col++)
                    Cells[row, col] = new Cell(row, col);
        }

        /// <summary>
        /// Fully sets up the board with bombs, rewards, and neighbor counts.
        /// </summary>
        public void InitializeBoard()
        {
            SetupBombs(Difficulty);
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// Uses a special reward if available (e.g., "Hint").
        /// </summary>
        public bool UseSpecialBonus(string rewardType)
        {
            if (!AvailableRewards.ContainsKey(rewardType) || AvailableRewards[rewardType] <= 0)
                return false;

            switch (rewardType)
            {
                case "Hint":
                    ShowHint();
                    break;
                default:
                    return false;
            }

            AvailableRewards[rewardType]--;
            return true;
        }

        /// <summary>
        /// Displays a hint to the user by revealing a random bomb coordinate (console only).
        /// </summary>
        private void ShowHint()
        {
            List<Tuple<int, int>> bombLocations = new();
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (Cells[r, c].IsBomb)
                        bombLocations.Add(Tuple.Create(r, c));

            if (bombLocations.Count == 0)
                return;

            var hintLocation = bombLocations[_random.Next(bombLocations.Count)];
            Console.WriteLine($"Hint: Bomb is at ({hintLocation.Item1 + 1}, {hintLocation.Item2 + 1})");
        }

        /// <summary>
        /// Checks if a given cell coordinate is within bounds of the board.
        /// </summary>
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        /// <summary>
        /// Calculates number of bomb neighbors for each cell.
        /// </summary>
        private void CalculateNumberOfBombNeighbors()
        {
            for (int row = 0; row < Size; row++)
                for (int col = 0; col < Size; col++)
                    Cells[row, col].NumberOfBombNeighbors = GetNumberOfBombNeighbors(row, col);
        }

        /// <summary>
        /// Gets the number of bombs surrounding a specific cell.
        /// </summary>
        private int GetNumberOfBombNeighbors(int row, int col)
        {
            int count = 0;
            int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int neighborRow = row + rowOffsets[i];
                int neighborCol = col + colOffsets[i];
                if (IsCellOnBoard(neighborRow, neighborCol) && Cells[neighborRow, neighborCol].IsBomb)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Places bombs randomly based on difficulty level.
        /// </summary>
        private void SetupBombs(int difficulty)
        {
            int numBombs = difficulty switch
            {
                1 => (int)(Size * Size * 0.15f),
                2 => (int)(Size * Size * 0.25f),
                3 => (int)(Size * Size * 0.40f),
                _ => (int)(Size * Size * 0.25f)
            };

            while (numBombs > 0)
            {
                int row = _random.Next(Size);
                int col = _random.Next(Size);

                if (!Cells[row, col].IsBomb)
                {
                    Cells[row, col].IsBomb = true;
                    numBombs--;
                }
            }
        }

        /// <summary>
        /// Initializes available rewards for this board.
        /// </summary>
        private void SetupRewards()
        {
            AvailableRewards = new Dictionary<string, int>
            {
                { "Hint", 2 }
            };
        }

        /// <summary>
        /// Determines the current state of the game (Won, Lost, In Progress).
        /// </summary>
        public GameStatus DetermineGameStatus()
        {
            bool allNonBombCellsRevealed = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var cell = Cells[row, col];
                    if (cell.IsBomb && cell.IsVisited)
                        return GameStatus.Lost;

                    if (!cell.IsBomb && !cell.IsVisited)
                        allNonBombCellsRevealed = false;
                }
            }

            return allNonBombCellsRevealed ? GameStatus.Won : GameStatus.InProgress;
        }

        /// <summary>
        /// Marks a cell as visited and checks for bomb hits (console-based check).
        /// </summary>
        public void VisitCell(int row, int col)
        {
            if (!IsCellOnBoard(row, col) || Cells[row, col].IsVisited || Cells[row, col].IsFlagged)
                return;

            Cells[row, col].IsVisited = true;

            if (Cells[row, col].IsBomb)
            {
                Console.WriteLine("Game Over!! You hit a Bomb.");
                PrintAnswers();
            }
        }

        /// <summary>
        /// Prints the current state of the board in console format.
        /// </summary>
        public void PrintAnswers()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Cells[row, col].IsFlagged)
                        Console.Write("F ");
                    else
                        Console.Write(Cells[row, col].IsBomb ? "B " : $"{Cells[row, col].NumberOfBombNeighbors} ");
                }
                Console.WriteLine();
            }
        }
    }
}
