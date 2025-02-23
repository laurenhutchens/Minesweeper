/*
*Milestone 3: Using Recursion
*Lauren Hutchens and Arie Gerard
*2/23/2025
*Professor Hughes
*CST-250
*/

using System;
using MineSweeper.BusinessLogicLayer;
using MineSweeperClasses.Models;

// I'm starting the Minesweeper game, displaying a welcoming message.
Console.WriteLine("Welcome to Minesweeper!");

// I need to get the board size from the player, ensuring it's valid.
int size = MinesweeperGameLogic.GetValidBoardSize();

// Now, I'm getting the difficulty level from the player, again ensuring it's valid.
int difficulty = MinesweeperGameLogic.GetValidDifficulty();

// I'm creating a new game board with the size and difficulty the player chose.
BoardModel board = new BoardModel(size, difficulty);

// I'm starting the main game loop, which continues as long as the game is in progress.
while (board.DetermineGameStatus() == BoardModel.GameStatus.InProgress)
{
    // I'm displaying the current state of the game board.
    PrintBoard(board);

    // I'm also printing the answers, which is useful for debugging but also for the player to see what they are trying to solve.
    board.PrintAnswers();

    // I'm asking the player to enter the row and column of the cell they want to interact with.
    Console.WriteLine("Enter row and column (e.g., 1,2): ");

    // I'm reading the player's input and splitting it into row and column values.
    string[] input = Console.ReadLine().Split(',');

    // I'm validating the player's input to make sure it's in the correct format and within the board's bounds.
    if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col) || row < 1 || row > size || col < 1 || col > size)
    {
        // If the input is invalid, I'm displaying an error message and continuing to the next iteration of the loop.
        Console.WriteLine("Invalid Input. Please try again (Valid range: 1-" + size + ")");
        continue;
    }

    // I'm asking the player to choose an action: flag, visit, or use a reward.
    Console.WriteLine("Enter action 1.) Flag / 2.) Visit / 3.) UseReward");

    // I'm reading the player's action input.
    string actionInput = Console.ReadLine();

    // I'm validating the player's action input to make sure it's a valid choice.
    if (!int.TryParse(actionInput, out int action) || action < 1 || action > 3)
    {
        // If the action is invalid, I'm displaying an error message and continuing to the next iteration of the loop.
        Console.WriteLine("Invalid Action. Please try again.");
        continue;
    }

    // If the player chose to use a reward, I'm asking them to choose which reward to use.
    if (action == 3)
    {
        Console.WriteLine("Choose a reward: Hint");
        string chosenReward = Console.ReadLine();

        // I'm checking if the player has the chosen reward and using it if they do.
        if (board.UseSpecialBonus(chosenReward))
        {
            Console.WriteLine($"{chosenReward} used successfully!");
        }
    }

    // I'm adjusting the row and column values to be zero-based, which is what the board array uses.
    row--;
    col--;

    // I'm performing the player's chosen action.
    switch (action)
    {
        case 1: // Flag
            // I'm toggling the flag on the selected cell.
            board.Cells[row, col].IsFlagged = !board.Cells[row, col].IsFlagged;
            break;
        case 2: // Visit
            // I am calling the flood fill method to reveal empty cells around the one clicked.
            BoardModel.FloodFill(board, row, col);
            // I'm visiting the selected cell.
            board.VisitCell(row, col);
            break;
        case 3: // Reward
            // I'm not doing anything here because the reward logic is already handled above.
            break;
        default:
            // If the action is invalid, I'm displaying an error message.
            Console.WriteLine("Issue with the input");
            break;
    }
}

// The game loop has ended, so I'm checking if the player won or lost.
if (board.DetermineGameStatus() == BoardModel.GameStatus.Won)
{
    // If the player won, I'm displaying a congratulatory message and the final board state.
    Console.WriteLine("Congratulations! You won!");
    PrintBoard(board);
}

// I'm defining a method to print the game board to the console.
static void PrintBoard(BoardModel board)
{
    // I am printing the column numbers at the top.
    Console.Write("    ");
    for (int i = 0; i < board.Size; i++)
    {
        Console.Write($" {i,2} ");
    }
    Console.WriteLine();

    // I am printing a horizontal line to separate the column numbers from the board.
    Console.WriteLine("    " + new string('-', board.Size * 4 + 1));

    // I am looping through each row of the board.
    for (int row = 0; row < board.Size; row++)
    {
        // I am printing the row number at the beginning of each row.
        Console.Write($"{row,2}|");

        // I am looping through each cell in the row.
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write(" "); // Space before cell content

            // I am checking the state of the cell and printing the appropriate character.
            if (board.Cells[row, col].IsFlagged)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                    Console.Write(board.Cells[row, col].DisplayChar);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("?");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" |");
        }
        Console.WriteLine();
        Console.WriteLine("    " + new string('-', board.Size * 4 + 1));
    }
}