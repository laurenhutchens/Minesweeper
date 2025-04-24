/*
* Milestone 6: Game Extensions
* Lauren Hutchens and Arie Gerard
* Professor Hughes
* CST-250
* 4/27/2005
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MineSweeperClasses.DataAccessLayer
{
    /// <summary>
    /// Handles data persistence for the Minesweeper game using JSON.
    /// Includes methods for saving and loading game statistics.
    /// </summary>
    public class MinesweeperDAO
    {
        /// <summary>
        /// Saves the provided data object to a specified file path using JSON serialization.
        /// </summary>
        /// <param name="data">The object to save (e.g., list of GameStat)</param>
        /// <param name="filePath">File path to save the JSON data</param>
        public static void TsmSave(object data, string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Data saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads JSON data from a file and deserializes it into an object of type T.
        /// </summary>
        /// <typeparam name="T">Type of object to return (e.g., List&lt;GameStat&gt;)</typeparam>
        /// <param name="filePath">Path to the JSON file</param>
        /// <returns>Deserialized object of type T or null if error</returns>
        public static T TsmLoad<T>(string filePath) where T : class
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    T data = JsonSerializer.Deserialize<T>(jsonString);
                    return data;
                }
                else
                {
                    Console.WriteLine("File not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return null;
            }
        }
    }
}
