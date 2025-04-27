/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */

using System;

namespace MineSweeperClasses.BuisnessLogicLayer
{
    public class GameStat
    {
        //Properties of GameStat to set and get values
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public TimeSpan GameTime { get; set; }
        public DateTime Date { get; set; } // Add Date property

        // Constructor with Date
        public GameStat(int id, string name, int score, TimeSpan gameTime, DateTime date)
        {
            Id = id;
            Name = name;
            Score = score;
            GameTime = gameTime;
            Date = date;
        }

        //Default Constructor
        public GameStat()
        {

        }

        //Override string for to text. 
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Score: {Score}, Time: {GameTime}, Date: {Date}";
        }

        /// <summary>
        /// Method to calculate the average score
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public static double CalculateAverageScore(List<GameStat> stats)
        {
            //check if null
            if (stats == null || stats.Count == 0)
                return 0;
            //calculate and return
            double totalScore = stats.Sum(stat => stat.Score);
            return totalScore / stats.Count;
        }

        /// <summary>
        /// Calculates the average game time from a list of game statistics.
        /// </summary>
        /// <param name="stats">A list of GameStat objects containing individual game times.</param>
        /// <returns>The average game duration as a TimeSpan. Returns TimeSpan.Zero if the list is null or empty.</returns>
        public static TimeSpan CalculateAverageGameTime(List<GameStat> stats)
        {
            // Return zero if the input list is null or contains no elements
            if (stats == null || stats.Count == 0)
                return TimeSpan.Zero;

            // Sum all GameTime ticks from the stats and create a new TimeSpan from the total
            TimeSpan totalGameTime = new TimeSpan(stats.Sum(stat => stat.GameTime.Ticks));

            // Calculate the average by dividing the total ticks by the number of games
            return TimeSpan.FromTicks(totalGameTime.Ticks / stats.Count);
        }
    }
}