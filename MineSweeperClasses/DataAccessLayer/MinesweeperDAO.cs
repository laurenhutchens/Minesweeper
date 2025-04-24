/*
 * Milestone 2: Interactive Playable Version
 * Lauren Hutchens and Arie Gerard
 * Professor Hughes
 * CST-250
 * 2/9/2005
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MineSweeperClasses.DataAccessLayer
{

    //this class is intended to handle data access, specifically saving and loading game states (not yet implemented). 
    public class MinesweeperDAO
    {
        /// <summary>
        /// Save handler for saving to a file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        public static void TsmSave(object data, string filePath)
        {
            try
            {
                //instantiates a jsonserializer and and writes to the file 
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
        /// touple for loading ans serializing load
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public static T TsmLoad<T>(string filePath) where T : class
        {
            try
            {
                //Checks if the file exists
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
