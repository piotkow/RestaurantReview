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
    public class FileManager<T>
    {
        private string _fileName;

        public FileManager(string fileName)
        {
            this._fileName = fileName;
        }

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