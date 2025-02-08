/*
* Milestone 2: Interactive Playable Version
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 2/9/2005
*/

using System;
using System.Collections.Generic;
using MineSweeper.Entities;
using MineSweeperClasses.Models;

namespace MineSweeper.Entities
{
    public class Board
    {
        //getters and setters
        public int Size { get; }
        //dificulty getter and setter
        public int Difficulty { get; }
        public Cell[,] Cells { get; private set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { InProgress, Won, Lost }

        private readonly Random _random = new Random();


        public Dictionary<string, int> AvailableRewards { get; private set; }


        private int _difficulty; // Store the difficulty

        /// <summary>
        /// parameterized constructor for the board, with the parameters 
        /// of size and difficulty based on user input
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
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

        /// <summary>
        /// method to initialize the cells
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
        /// method to set up the baord
        /// </summary>
        private void InitializeBoard()
        {
            SetupBombs(_difficulty);
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// method to print the answers ex: f(Flagged)
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

                    Console.Write(Cells[row, col].IsBomb ? "B " : $"{Cells[row, col].NumberOfBombNeighbors} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// method for the user to choose reward
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
                //if the user does not input "Hint" it will be invalid
                default:
                    Console.WriteLine("Invalid reward type.");
                    return false;
            }
            AvailableRewards[rewardType]--;  //decrement reward count
            return true; //reward used successfully!
        }

        /// <summary>
        /// method to make the ShowHint to be displayed on the board cell
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

            Random random = new Random();
            int randomIndex = random.Next(bombLocations.Count);
            Tuple<int, int> hintLocation = bombLocations[randomIndex];

            Console.WriteLine($"Hint: Bomb is at ({hintLocation.Item1 + 1}, {hintLocation.Item2 + 1})");
        }

        /// <summary>
        /// helper function to determine if a cell is out of bounds
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }
        /// <summary>
        /// use during setup to calculate the number of bomb neighbors for each cell
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
        /// helper function to determine the number of bomb neighbors for a cell
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
        /// use during setup to place bombs on the board
        /// 3 case statements to ask the user for easy, medium, or hard
        /// </summary>
        /// <param name="difficulty"></param>
        private void SetupBombs(int difficulty)
        {
            int numBombs = (int)(Size * Size * Difficulty);

            switch (difficulty)
            {
                case 1: // Easy
                    numBombs = (int)(Size * Size * 0.15f); //ex: 15% bombs
                    break;
                case 2: // Medium
                    numBombs = (int)(Size * Size * 0.25f); //ex: 25% bombs
                    break;
                case 3: // Hard
                    numBombs = (int)(Size * Size * 0.40f); //ex: 40% bombs
                    break;
                default:
                    numBombs = (int)(Size * Size * 0.25f); //default to medium if something goes wrong
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
        /// use during setup to place rewards on the board
        /// </summary>
        private void SetupRewards()
        {
            //instatiate the dictionary
            AvailableRewards = new Dictionary<string, int>();

            AvailableRewards.Add("Hint", 2);
        }

        /// <summary>
        /// use every turn to determine the current game state
        /// this method will inspect the contents of the Board and return one of three values: won, lost, stillPlaying
        /// </summary>
        /// <returns></returns>
        public Board.GameStatus DetermineGameStatus()
        {
            bool allNonBombCellsRevealed = true;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cell currentCell = Cells[row, col];

                    if (currentCell.IsBomb && currentCell.IsVisited)
                    {
                        return Board.GameStatus.Lost; //bomb visited - game lost
                    }

                    if (!currentCell.IsBomb && !currentCell.IsVisited)
                    {
                        allNonBombCellsRevealed = false; //unvisited non-bomb cell found
                    }
                }
            }

            //check if ALL non-bomb cells are either visited OR correctly flagged
            if (allNonBombCellsRevealed)
            {
                return Board.GameStatus.Won; //all safe cells revealed - game won
            }
            else
            {
                return Board.GameStatus.InProgress; //still cells to reveal
            }
        }
    }
}