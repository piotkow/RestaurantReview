using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RestaurantLibrary
{
    /// <summary>
    /// Manages file operations for items of type T.
    /// </summary>
    /// <typeparam name="T">The type of items to manage.</typeparam>
    public class FileManager<T>
    {
        private string _fileName;

        /// <summary>
        /// Initializes a new instance of the FileManager class with the specified file name.
        /// </summary>
        /// <param name="fileName">The name of the file to manage.</param>
        public FileManager(string fileName)
        {
            this._fileName = fileName;
        }

        /// <summary>
        /// Retrieves all items from the file.
        /// </summary>
        /// <returns>Returns a list of all items from the file.</returns>
        public List<T> GetAllItemsFromFile()
        {
            List<T> items = new List<T>();
            try
            {
                if (File.Exists(_fileName))
                {
                    using (StreamReader sr = new StreamReader(_fileName))
                    {
                        string jsonString = sr.ReadToEnd();
                        items = JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
                    }
                }
                else
                {
                    Console.WriteLine("File not found. Returning an empty list.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return items;
        }

        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <returns>Returns the item with the specified ID if found, default value otherwise.</returns>
        public T GetById(int id)
        {
            List<T> items = GetAllItemsFromFile();
            if (items != null)
            {
                try
                {
                    return items.FirstOrDefault(item =>
                        Convert.ToInt32(item.GetType().GetProperty("Id")?.GetValue(item)) == id) ?? default!;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting item by Id: {ex.Message}");
                }
            }
            return default!;
        }

        /// <summary>
        /// Adds an item to the file.
        /// </summary>
        /// <param name="obj">The item to add.</param>
        /// <returns>Returns true if the item is successfully added, false otherwise.</returns>
        public bool Add(T obj)
        {
            List<T> items = GetAllItemsFromFile();
            if (items == null)
            {
                items = new List<T>();
            }
            items.Add(obj);

            try
            {
                string jsonString = JsonSerializer.Serialize(items);
                File.WriteAllText(_fileName, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
                return false;
            }
        }
    }

}