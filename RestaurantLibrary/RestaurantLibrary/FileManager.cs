using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace RestaurantLibrary
{
    public class FileManager<T>
    {
        private string _fileName;
        List<T> list;

        FileManager(string fileName)
        {
            this._fileName = fileName;
            LoadData();
        }
        public List<T> GetAll()
        {
            return list;
        }

        public T GetById(string name)
        {
            return list.FirstOrDefault(x=>x.Equals(name));
        }

        public T Add(T obj)
        {
            list.Add(obj);
            SaveData();
            return obj;
        }

        private List<T> LoadData()
        {
            if (File.Exists(_fileName))
            {
                string json = File.ReadAllText(_fileName);
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            return new List<T>();
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_fileName, json);
        }

    }
}
