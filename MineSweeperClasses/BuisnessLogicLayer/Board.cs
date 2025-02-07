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
            // Future implementation
        }

        //use every turn to determine the current game state
        public Board.GameStatus DetermineGameStatus()
        {
            bool allCellsVisited = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Cells[row, col].IsBomb && Cells[row, col].IsVisited)
                        return Board.GameStatus.Lost;

                    if (!Cells[row, col].IsBomb && !Cells[row, col].IsVisited)
                        allCellsVisited = false;

                }
            }
            return allCellsVisited ? Board.GameStatus.Won : Board.GameStatus.InProgress;
        }
    }
}
