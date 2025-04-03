//using System;
//using MineSweeperClasses.BusinessLogicLayer;
using MineSweeperClasses.Models;

class Program
{
    /// <summary>
    /// Handles the main welcome message and gameplay operations.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Minesweeper!");]

        // Checks to see if the size and difficulty are valid by calling the GetValid methods in MinesweeperGameLogic.
        int size = MinesweeperGameLogic.GetValidBoardSize();
        int difficulty = MinesweeperGameLogic.GetValidDifficulty();
        // Instantiates a new board with the desired size and difficulty. 
        BoardModel board = new BoardModel(size, difficulty);
        while (board.DetermineGameStatus() == BoardModel.GameStatus.InProgress)
        {
            PrintBoard(board);
            board.PrintAnswers();




            Console.WriteLine("Enter row and column (e.g., 1,2): ");
            string[] input = Console.ReadLine().Split(','); // Allows the user to split their input using a comma.
            // Error handling for the input using Try.Parse. 
            if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) || row < 0 || row >= size || col < 0 || col >= size) // Added bounds check
            {
                Console.WriteLine("Invalid Input. Please try again (Valid range: 0-" + (size - 1) + ")");
                continue;
            }

            Console.WriteLine("Enter action 1.) Flag / 2.) Visit / 3.) UseReward");
            string actionInput = Console.ReadLine();
            // Error handling using int.TryParse for the action. 
            if (!int.TryParse(actionInput, out int action) || action < 1 || action > 3)
            {
                Console.WriteLine("Invalid Action. Please try again.");
                continue;
            }
            // Choosing a reward when 3 is clicked. 
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
                    BoardModel.FloodFill(board, row, col); // Call the FloodFill method
                    board.VisitCell(row, col);

                    break;
                case 3: // Reward
                    break;
                default:
                    Console.WriteLine("Issue with the input");
                    break;
            }
        }

        if (board.DetermineGameStatus() == BoardModel.GameStatus.Won)
        {
            Console.WriteLine("Congratulations! You won!");
            PrintBoard(board); // Show the final board state
        }
    }



    /// <summary>
    /// Displays the board during the gameplay.
    /// </summary>
    /// <param name="board"></param>
    static void PrintBoard(BoardModel board)
    {
        // Print column numbers
        Console.Write("   "); // Adjust spacing for column headers
        for (int i = 0; i < board.Size; i++)
        {
            Console.Write($" {i,2} "); // Format column numbers with two spaces
        }
        Console.WriteLine();

        // Print divider line above the board
        Console.WriteLine("   " + new string('-', board.Size * 4 + 1));

        // For loop and if statements to handle the output of specific components. 
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
                        Console.Write(board.Cells[row, col].DisplayChar); // Use DisplayChar
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
            Console.WriteLine("   " + new string('-', board.Size * 4 + 1));
        }
    }

}
