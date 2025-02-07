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
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.BuisnessLayer
{
    //it stores information about the cell, such as its row and column,
    //whether it's been visited, whether it contains a bomb, whether it's flagged
    //by the user, the number of neighboring cells that contain bombs, and whether it has a special reward.
    public class Cell
    {
        //declaring property
        public int Row { get; }
        public int Column { get; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }

        //constructor
        public Cell(int row, int column, bool isBomb = false, bool hasSpecialReward = false)
        {
            Row = row;
            Column = column;
            IsBomb = isBomb;
            HasSpecialReward = hasSpecialReward;
            IsVisited = false; // Initialize IsVisited to false
            IsFlagged = false; // Initialize IsFlagged to false
            NumberOfBombNeighbors = 0; // Initialize NumberOfBombNeighbors to 0
        }
    }
}
