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

        private List<T> GetAllItemsFromFile()
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

        public List<T> GetAll()
        {
            return GetAllItemsFromFile();
        }

        public T GetById(string id)
        {
            List<T> items = GetAllItemsFromFile();
            if (items != null)
            {
                try
                {
                    return items.FirstOrDefault(item =>
                        item.GetType().GetProperty("Id")?.GetValue(item)?.ToString() == id) ?? default!;
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