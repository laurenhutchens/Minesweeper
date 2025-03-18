using System;

namespace MineSweeperClasses.BuisnessLogicLayer
{
    public class GameStat
    {
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

        // Optional ToString() override for debugging
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Score: {Score}, Time: {GameTime}, Date: {Date}";
        }
    }
}