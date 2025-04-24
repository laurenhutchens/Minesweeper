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

        // Static Method to Calculate Average Score from a List of GameStats
        public static double CalculateAverageScore(List<GameStat> stats)
        {
            if (stats == null || stats.Count == 0)
                return 0;

            double totalScore = stats.Sum(stat => stat.Score);
            return totalScore / stats.Count;
        }
        // Static Method to Calculate Average Game Time from a List of GameStats
        public static TimeSpan CalculateAverageGameTime(List<GameStat> stats)
        {
            if (stats == null || stats.Count == 0)
                return TimeSpan.Zero;

            TimeSpan totalGameTime = new TimeSpan(stats.Sum(stat => stat.GameTime.Ticks));
            return TimeSpan.FromTicks(totalGameTime.Ticks / stats.Count);
        }

    }
}