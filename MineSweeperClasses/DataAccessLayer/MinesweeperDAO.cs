<<<<<<< HEAD
﻿using System;
using System.IO;
using System.Text.Json;

namespace MineSweeperClasses.DataAccessLayer
{
=======
﻿/*
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
>>>>>>> a6af47b419ab4330c29fa78aaf2c2c8992f6c93d
    public class MinesweeperDAO
    {
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
