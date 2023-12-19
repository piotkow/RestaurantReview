using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    /// <summary>
    /// Represents a review for a restaurant.
    /// </summary>
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }


        /// <summary>
        /// Returns a string that represents the current review.
        /// </summary>
        /// <returns>A string that contains the restaurant's name, the rating, and the comment of the review.</returns>
        public override string ToString()
        {
            return
                $"Name: {Restaurant.Name}"+
                $" Rating: {Rating}" +
                $" Comment: {Comment}";
        }

    }
}