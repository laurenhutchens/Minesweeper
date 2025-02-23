/*
*Milestone 3: Using Recursion
*Lauren Hutchens and Arie Gerard
*2/23/2025
*Professor Hughes
*CST-250
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.Models
{
    public class Cell
    {
        // Declaring properties
        public int Row { get; }
        public int Column { get; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }
        public char DisplayChar { get; set; } // Character representation of the cell

        // Constructor
        public Cell(int row, int column, bool isBomb = false, bool hasSpecialReward = false)
        {
            Row = row;
            Column = column;
            IsBomb = isBomb;
            HasSpecialReward = hasSpecialReward;
            IsVisited = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;

            // Initialize display character
            DisplayChar = '#'; // Hidden by default
        }

        // Method to update the display character when revealed
        public void Reveal()
        {
            IsVisited = true;

            // For bombs, set the display character to 'B'
            if (IsBomb)
            {
                DisplayChar = 'B';
            }
            // If there are bomb neighbors, show the number of neighbors
            else if (NumberOfBombNeighbors > 0)
            {
                DisplayChar = (char)(NumberOfBombNeighbors + '0');  // Convert to char ('0'-'9')
            }
            // If there are no bomb neighbors, set the display to '.'
            else
            {
                DisplayChar = '.';  // Empty cell should be represented by '.'
            }
        }


    }
}