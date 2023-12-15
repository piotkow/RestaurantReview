using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class FileManager<T>
    {
        private string _fileName;
        FileManager(string fileName)
        {
            this._fileName = fileName;
        }
        public List<T> GetAll()
        {

        }

        public T GetById(string name)
        {

        }

        public T Add(T obj)
        {

        }
    }
}
