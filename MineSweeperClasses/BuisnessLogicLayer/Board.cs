using System;
using MineSweeper.Entities;
using MineSweeperClasses.BuisnessLayer;

namespace MineSweeper.Entities
{
    public class Board
    {
        //getters and setters
        public int Size { get; }
        //TODO:
        public int Difficulty { get; }
        public Cell[,] Cells { get; private set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { InProgress, Won, Lost }

        private readonly Random _random = new Random();

        public Dictionary<string, int> AvailableRewards { get; private set; }


        private int _difficulty; // Store the difficulty
        public Board(int size, int difficulty)
        {
            _difficulty = difficulty; // Store it!
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            RewardsRemaining = 0;

            InitializeCells();
            InitializeBoard();
        }

        //initialize cells
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

        //initialize board
        private void InitializeBoard()
        {
            SetupBombs(_difficulty);
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        //PrintAnswers method
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

                    Console.Write(Cells[row, col].IsBomb ? "B " : $"{Cells[row, col].NumberOfBombNeighbors} ");
                }
                Console.WriteLine();
            }
        }

        //TODO: UseSpecialBonus method
            public bool UseSpecialBonus(string rewardType) // No row/col needed for Hint
            {
                if (!AvailableRewards.ContainsKey(rewardType) || AvailableRewards[rewardType] <= 0)
                {
                    Console.WriteLine($"No {rewardType} rewards available.");
                    return false; // Reward not available
                }

                switch (rewardType)
                {
                    case "Hint":
                        ShowHint();
                        break;
                    // Add other cases here as you implement more rewards
                    // case "TimeFreeze": ...
                    // case "BombDefuseKit": ...
                    // case "Undo": ...
                    default:
                        Console.WriteLine("Invalid reward type.");
                        return false;
                }

                AvailableRewards[rewardType]--;  // Decrement reward count
                return true; // Reward used successfully
            }

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

            Random random = new Random();
            int randomIndex = random.Next(bombLocations.Count);
            Tuple<int, int> hintLocation = bombLocations[randomIndex];

            Console.WriteLine($"Hint: Bomb is at ({hintLocation.Item1 + 1}, {hintLocation.Item2 + 1})"); // User-friendly coordinates
        }


        //TODO: DetermineFinalScore method

        //helper function to determine if a cell is out of bounds
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        //use during setup to calculate the number of bomb neighbors for each cell
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

        //helper function to determine the number of bomb neighbors for a cell
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

        //use during setup to place bombs on the board
        private void SetupBombs(int difficulty)
        {
            int numBombs = (int)(Size * Size * Difficulty);

            switch (difficulty)
            {
                case 1: // Easy
                    numBombs = (int)(Size * Size * 0.15f); // Example: 15% bombs
                    break;
                case 2: // Medium
                    numBombs = (int)(Size * Size * 0.25f); // Example: 25% bombs
                    break;
                case 3: // Hard
                    numBombs = (int)(Size * Size * 0.40f); // Example: 40% bombs
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

        //use during setup to place rewards on the board
        private void SetupRewards()
        {
            // Now you can initialize the dictionary correctly:
            AvailableRewards = new Dictionary<string, int>();

            AvailableRewards.Add("Hint", 2); // Example: 2 hints
                                             // Add other rewards as needed
        }

        //use every turn to determine the current game state
        //This method will inspectthe contents of the Board and return one of three values: won, lost, stillPlaying
        public Board.GameStatus DetermineGameStatus()
        {
            bool allNonBombCellsRevealed = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cell currentCell = Cells[row, col]; // Store cell for easier access

                    if (currentCell.IsBomb && currentCell.IsVisited)
                    {
                        return Board.GameStatus.Lost; // Bomb visited - game lost
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
                return Board.GameStatus.Won; // All safe cells revealed - game won
            }
            else
            {
                return Board.GameStatus.InProgress; // Still cells to reveal
            }
        }
    }
}
