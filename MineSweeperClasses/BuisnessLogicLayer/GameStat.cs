/*
* Milestone 6: Game Extensions
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 4/27/2005
*/

using System;

namespace MineSweeperClasses.BuisnessLogicLayer
{
    /// <summary>
    /// Represents a single game result, including player name, score, game duration, and date played.
    /// Used primarily for leaderboard storage and display.
    /// </summary>
    public class GameStat
    {
        /// <summary>
        /// Unique identifier for the game stat record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The score the player achieved.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The time taken by the player to complete the game.
        /// </summary>
        public TimeSpan GameTime { get; set; }

        /// <summary>
        /// The date when the game was played.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Parameterized constructor to create a fully initialized GameStat.
        /// </summary>
        public GameStat(int id, string name, int score, TimeSpan gameTime, DateTime date)
        {
            Id = id;
            Name = name;
            Score = score;
            GameTime = gameTime;
            Date = date;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameStat() { }

        /// <summary>
        /// Returns a string that represents the current GameStat.
        /// </summary>
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Score: {Score}, Time: {GameTime}, Date: {Date}";
        }
    }
}
