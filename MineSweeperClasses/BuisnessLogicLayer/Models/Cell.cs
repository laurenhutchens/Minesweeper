/*
*Milestone 2: Interactive Playable Version
*Lauren Hutchens and Arie Gerard
*2/9/2025
*Professor Hughes
*CST-250
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.BuisnessLogicLayer.Models
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
            DisplayChar = IsBomb ? 'B' : (NumberOfBombNeighbors > 0 ? (char)(NumberOfBombNeighbors + '0') : '.');
        }
    }
}
