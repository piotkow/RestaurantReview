using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} " +
                $"Name: {Restaurant.Name}"+
                $"Rating: {Rating}" +
                $" Comment: {Comment}";
        }

    }
}