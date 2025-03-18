/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */
using System;
using System.Collections.Generic;

namespace MineSweeperClasses.Models
{
    public class BoardModel
    {
        // Getters and setters
        public int Size { get; }
        public int Difficulty { get; }
        public Cell[,] Cells { get; private set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public enum GameStatus { InProgress, Won, Lost }

        private readonly Random _random = new Random(); // Fixed typo here: removed space in _rand om


        public Dictionary<string, int> AvailableRewards { get; private set; }

        /// <summary>
        /// Parameterized constructor for the board, with the parameters of size and difficulty based on user input
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
        /// Method to initialize the cells
        /// </summary>
        private void InitializeCells()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col] = new Cell(row, col);
                }
            }
        }

        /// <summary>
        /// Method to set up the board
        /// </summary>
        public void InitializeBoard()
        {
            SetupBombs(Difficulty);
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// Method for the user to choose reward
        /// </summary>
        public bool UseSpecialBonus(string rewardType)
        {
            if (!AvailableRewards.ContainsKey(rewardType) || AvailableRewards[rewardType] <= 0)
            {
                Console.WriteLine($"No {rewardType} rewards available.");
                return false;
            }

            switch (rewardType)
            {
                case "Hint":
                    ShowHint();
                    break;
                default:
                    Console.WriteLine("Invalid reward type.");
                    return false;
            }

            AvailableRewards[rewardType]--;  // Decrement reward count
            return true; // Reward used successfully!
        }

        /// <summary>
        /// Method to show a hint (display bomb location randomly)
        /// </summary>
        private void ShowHint()
        {
            List<Tuple<int, int>> bombLocations = new List<Tuple<int, int>>();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (Cells[r, c].IsBomb)
                    {
                        bombLocations.Add(new Tuple<int, int>(r, c));
                    }
                }
            }

            if (bombLocations.Count == 0)
            {
                Console.WriteLine("No bombs to reveal!");
                return;
            }

            int randomIndex = _random.Next(bombLocations.Count);
            Tuple<int, int> hintLocation = bombLocations[randomIndex];

            Console.WriteLine($"Hint: Bomb is at ({hintLocation.Item1 + 1}, {hintLocation.Item2 + 1})");
        }

        /// <summary>
        /// Helper function to determine if a cell is within the board's bounds
        /// </summary>
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        /// <summary>
        /// Calculate the number of bomb neighbors for each cell
        /// </summary>
        private void CalculateNumberOfBombNeighbors()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col].NumberOfBombNeighbors = GetNumberOfBombNeighbors(row, col);
                }
            }
        }

        /// <summary>
        /// Helper function to determine the number of bomb neighbors for a given cell
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
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Setup bombs on the board based on the difficulty level
        /// </summary>
        private void SetupBombs(int difficulty)
        {
            int numBombs;
            switch (difficulty)
            {
                case 1: numBombs = (int)(Size * Size * 0.15f); break; // 15% bombs
                case 2: numBombs = (int)(Size * Size * 0.25f); break; // 25% bombs
                case 3: numBombs = (int)(Size * Size * 0.40f); break; // 40% bombs
                default: numBombs = (int)(Size * Size * 0.25f); break; // Default to medium
            }

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
        /// Setup rewards for the board
        /// </summary>
        private void SetupRewards()
        {
            AvailableRewards = new Dictionary<string, int>
            {
                { "Hint", 2 }
            };
        }

        /// <summary>
        /// Determine the current game status (In Progress, Won, Lost)
        /// </summary>
        public GameStatus DetermineGameStatus()
        {
            bool allNonBombCellsRevealed = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cell currentCell = Cells[row, col];

                    // If a bomb is visited, the game is lost.
                    if (currentCell.IsBomb && currentCell.IsVisited)
                    {
                        return GameStatus.Lost; // Bomb visited, game lost.
                    }

                    // If a non-bomb cell is not revealed, the game is not won yet.
                    if (!currentCell.IsBomb && !currentCell.IsVisited)
                    {
                        allNonBombCellsRevealed = false; // There are still non-bomb cells that are not revealed
                    }
                }
            }

            return allNonBombCellsRevealed ? GameStatus.Won : GameStatus.InProgress;
        }

        /// <summary>
        /// Flood fill algorithm to reveal empty cells
        /// </summary>
       

        /// <summary>
        /// Visit a cell and handle the game logic when revealing a cell
        /// </summary>
        public void VisitCell(int row, int col)
        {
            if (!IsCellOnBoard(row, col) || Cells[row, col].IsVisited || Cells[row, col].IsFlagged)
            {
                Console.WriteLine("Invalid move: Cell is out of bounds, already visited, or flagged.");
                return;
            }

            Cells[row, col].IsVisited = true;

            if (Cells[row, col].IsBomb)
            {
                Console.WriteLine("Game Over!! You hit a Bomb.");
                PrintAnswers(); // Reveal all bombs
            }
        }
        public void PrintAnswers()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Cells[row, col].IsFlagged)
                    {
                        Console.Write("F ");
                    }
                    else
                    {
                        Console.Write(Cells[row, col].IsBomb ? "B " : $"{Cells[row, col].NumberOfBombNeighbors} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
