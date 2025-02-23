/*
*Milestone 3: Using Recursion
*Lauren Hutchens and Arie Gerard
*2/23/2025
*Professor Hughes
*CST-250
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

        private readonly Random _random = new Random();
        public Dictionary<string, int> AvailableRewards { get; private set; }

        /// <summary>
        /// Parameterized constructor for the board, with the parameters 
        /// of size and difficulty based on user input
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
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
        private void InitializeBoard()
        {
            SetupBombs(Difficulty);
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// Method to print the answers
        /// </summary>
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

        /// <summary>
        /// Method for the user to choose reward
        /// </summary>
        /// <param name="rewardType"></param>
        /// <returns>hint</returns>
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
        /// Method to make the ShowHint to be displayed on the board cell
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
        /// Helper function to determine if a cell is out of bounds
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        /// <summary>
        /// Use during setup to calculate the number of bomb neighbors for each cell
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
        /// Helper function to determine the number of bomb neighbors for a cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
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
        /// Use during setup to place bombs on the board
        /// </summary>
        /// <param name="difficulty"></param>
        private void SetupBombs(int difficulty)
        {
            int numBombs;

            switch (difficulty)
            {
                case 1: // Easy
                    numBombs = (int)(Size * Size * 0.15f); // 15% bombs
                    break;
                case 2: // Medium
                    numBombs = (int)(Size * Size * 0.25f); // 25% bombs
                    break;
                case 3: // Hard
                    numBombs = (int)(Size * Size * 0.40f); // 40% bombs
                    break;
                default:
                    numBombs = (int)(Size * Size * 0.25f); // Default to medium if something goes wrong
                    break;
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
        /// Use during setup to place rewards on the board
        /// </summary>
        private void SetupRewards()
        {
            // Instantiate the dictionary
            AvailableRewards = new Dictionary<string, int>
            {
                { "Hint", 2 }
            };
        }

        /// <summary>
        /// Use every turn to determine the current game state
        /// </summary>
        /// <returns></returns>
        public GameStatus DetermineGameStatus()
        {
            bool allNonBombCellsRevealed = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cell currentCell = Cells[row, col];

                    if (currentCell.IsBomb && currentCell.IsVisited)
                    {
                        return GameStatus.Lost; // Bomb visited - game lost
                    }

                    if (!currentCell.IsBomb && !currentCell.IsVisited)
                    {
                        allNonBombCellsRevealed = false; // Unvisited non-bomb cell found
                    }
                }
            }

            // Check if ALL non-bomb cells are either visited OR correctly flagged
            if (allNonBombCellsRevealed)
            {
                return GameStatus.Won; // All safe cells revealed - game won
            }
            else
            {
                return GameStatus.InProgress; // Still cells to reveal
            }
        }

        /// <summary>
        /// Flood fill algorithm to reveal empty cells
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>


        /// <summary>
        /// Visit a cell and handle game logic
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
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
                return;
            }



        }

        /// <summary>
        /// when a player clicks on an empty cell, the method recursively uncovers all adjacent empty cells and any further connected empty cells, revealing a whole area of the board at once.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>

        public static void FloodFill(BoardModel board, int x, int y)
        {
            if (x < 0 || x >= board.Size || y < 0 || y >= board.Size || board.Cells[x, y].IsVisited || board.Cells[x, y].IsBomb)
            {
                return;
            }
            board.Cells[x, y].DisplayChar = '.';
            board.Cells[x, y].IsVisited = true;

            if (board.Cells[x, y].NumberOfBombNeighbors == 0)
            {
                FloodFill(board, x + 1, y);
                FloodFill(board, x - 1, y);
                FloodFill(board, x, y + 1);
                FloodFill(board, x, y - 1);
            }
        }



    }
}