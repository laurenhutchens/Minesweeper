using System;
using System.IO;
using System.Text.Json;

namespace MineSweeperClasses.DataAccessLayer
{
    public class MinesweeperDAO
    {
        public static void tsmSave(object data, string filePath)
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

        public static T tsmLoad<T>(string filePath) where T : class
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
