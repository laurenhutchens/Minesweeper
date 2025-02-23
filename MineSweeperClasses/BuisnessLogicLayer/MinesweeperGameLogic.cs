using System;
using MineSweeperClasses.Models;

namespace MineSweeper.BusinessLogicLayer
{
    // This class encapsulates the rules and operations of the Minesweeper game
    public class MinesweeperGameLogic
    {
        // Declare field
        private BoardModel board;

        public MinesweeperGameLogic(int size, int difficulty)
        {
            // Instantiate a new board 
            board = new BoardModel(size, difficulty);
        }

        /// <summary>
        /// Method to ask/check if the user input is valid. In this case it is for the BoardSize. 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to ask/check if the user input is valid. In this case it is for the Difficulty. 
        /// </summary>
        /// <returns></returns>
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
                // Checks to see if the user input is acceptable or not. 
                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty >= 1 && difficulty <= 3)
                {
                    return difficulty;
                }
                Console.WriteLine("Invalid input, please enter 1, 2, or 3.");
            }
        }
    }
}