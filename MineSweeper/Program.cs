/*
 * Milestone 2: Interactive Playable Version
 * Lauren Hutchens and Arie Gerard
 * Professor Hughes
 * CST-250
 * 2/9/2005
 */

using System;
using MineSweeper.BusinessLogicLayer;
using MineSweeper.Entities;

class Program
{
    /// <summary>
    /// Handles the main welcome message and gameplay operations
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Minesweeper!");
        // Checks to see if the size and difficulty are valid by calling the GetValid methods in MinesweeperGameLogic.
        int size = MinesweeperGameLogic.GetValidBoardSize();
        int difficulty = MinesweeperGameLogic.GetValidDifficulty();
        // Instantiates a new board with the desires size and difficulty. 
        Board board = new Board(size, difficulty);

        while (board.DetermineGameStatus() == Board.GameStatus.InProgress)
        {
            PrintBoard(board);
           
            Console.WriteLine("Enter row and column (e.g., 1,2): ");
            string[] input = Console.ReadLine().Split(','); // Allows the user to split their input using a comma. 
            //Error handeling for the input using Try.Parse. 
            if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) || row < 0 || row >= size || col < 0 || col >= size) // Added bounds check
            {
                Console.WriteLine("Invalid Input. Please try again (Valid range: 0-" + (size - 1) + ")");
                continue;
            }

            Console.WriteLine("Enter action 1.) Flag / 2.) Visit / 3.) UseReward");
            string actionInput = Console.ReadLine();
            //Error handeling using int.TryParse for the action. 
            if (!int.TryParse(actionInput, out int action) || action < 1 || action > 3)
            {
                Console.WriteLine("Invalid Action. Please try again.");
                continue;
            }
            //Choosing a reward when 3 is clicked. 
            if (action == 3)
            {
                Console.WriteLine("Choose a reward: Hint");
                string chosenReward = Console.ReadLine();

                if (board.UseSpecialBonus(chosenReward))
                {
                    Console.WriteLine($"{chosenReward} used successfully!");
                }
            }

            row--;
            col--;
            // Action loop that handles the user input actions. 
            switch (action)
            {
                case 1: // Flag
                    board.Cells[row, col].IsFlagged = !board.Cells[row, col].IsFlagged;
                    break;
                case 2: // Visit
                    if (board.Cells[row, col].IsVisited) // Prevent re-visiting
                    {
                        Console.WriteLine("Cell already visited.");
                        break;
                    }

                    board.Cells[row, col].IsVisited = true;
                    if (board.Cells[row, col].IsBomb)
                    {
                        Console.WriteLine("Game Over!! You hit a Bomb.");
                        board.PrintAnswers(); // Reveal all bombs
                        return; // End the game
                    }
                    break;
                case 3: // Reward
                 
                    break;
                default:
                    Console.WriteLine("Issue with the input");
                    break;
            }
        }

        if (board.DetermineGameStatus() == Board.GameStatus.Won)
        {
            Console.WriteLine("Congratulations! You won!");
            PrintBoard(board); // Show the final board state
        }
    }//end main method









    //displays the board during the game play
    static void PrintBoard(Board board)
    {
        // Print column numbers
        Console.Write("  "); // Adjust spacing as needed
        for (int i = 0; i < board.Size; i++)
        {
            Console.Write($"{i,2} "); // Format column numbers
        }
        Console.WriteLine();

        // Print divider line above the board
        Console.WriteLine("  " + new string('-', board.Size * 3 + 1));

        // For loop and if statements to handle the outprint of specific components. 
        for (int row = 0; row < board.Size; row++)
        {
            // Print row number
            Console.Write($"{row,2}|");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write(" "); // Space before cell content

                if (board.Cells[row, col].IsFlagged)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Example
                    Console.Write("F");
                }
                else if (board.Cells[row, col].IsVisited && board.Cells[row, col].IsBomb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("B");
                }
                else if (board.Cells[row, col].IsVisited)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                    {
                        Console.Write(board.Cells[row, col].NumberOfBombNeighbors);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("?"); // Or some other hidden representation
                }

                Console.ForegroundColor = ConsoleColor.White; // Reset color
                Console.Write(" |"); // Divider line between cells
            }
            Console.WriteLine();
            // Print divider line below the row
            Console.WriteLine("  " + new string('-', board.Size * 3 + 1));
        }
    }
}