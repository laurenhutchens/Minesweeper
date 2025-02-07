using System;
using System.Diagnostics;
using MineSweeper.Entities;

namespace MineSweeper.BusinessLogicLayer
{

    //this class encapsulates the rules and operations of the Minesweeper game
    //this class controls the game's overall flow and rules. It initializes the game board,
    //handles user input (row, column, and action), updates the board based on user actions (flag, visit),
    //checks for game over conditions (win/loss), and prints the board's current state to the console.
    //It also contains methods to get the board size and difficulty
    public class MinesweeperGameLogic
    {
        //declare field
        private Board board;

        public MinesweeperGameLogic(int size, int difficulty)
        {
            board = new Board(size, difficulty);
        }

        public static int GetValidBoardSize()
        {
            int size;
            while (true)
            {
                Console.Write("Enter Board Size (5 - 20): ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 5 && size <= 20)
                {
                    return size;
                }
                Console.WriteLine("Invalid Input. Please enter a number between 5 and 20.");
            }
        }

        public static int GetValidDifficulty()
        {
            int difficulty;
            while (true)
            {
                Console.WriteLine("Difficulty Levels:");
                Console.WriteLine("1 - Easy");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Hard");
                Console.Write("Enter difficulty (1, 2, or 3): ");

                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty >= 1 && difficulty <= 3)
                {
                    return difficulty;
                }
                Console.WriteLine("Invalid input, please enter 1, 2, or 3.");
            }
        }
        public static bool GetValidInput()
        {
            bool valid = true;
            return true;
            //fix out of bounds handeling. 

        }

    }
}
