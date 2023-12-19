using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    /// <summary>
    /// Manages operations for restaurants.
    /// </summary>
    public class RestaurantManager
    {
        /// <summary>
        /// Searches for a restaurant by name.
        /// </summary>
        /// <param name="restaurantFileManager">The file manager that handles the storage of restaurants.</param>
        /// <param name="name">The name of the restaurant to search for.</param>
        /// <returns>Returns the restaurant with the specified name if found, null otherwise.</returns>
        public Restaurant SearchByName(FileManager<Restaurant> restaurantFileManager, string name)
        {
            List<Restaurant> restaurants = restaurantFileManager.GetAllItemsFromFile();

            var filteredRestaurant = restaurants.First<Restaurant>(r => r.Name == name);

            return filteredRestaurant;
        }

        /// <summary>
        /// Searches for restaurants by average rating.
        /// </summary>
        /// <param name="restaurantFileManager">The file manager that handles the storage of restaurants.</param>
        /// <param name="reviewFileManager">The file manager that handles the storage of reviews.</param>
        /// <param name="rating">The average rating to search for.</param>
        /// <returns>Returns a list of restaurants whose average rating is approximately equal to the specified rating.</returns>
        public List<Restaurant> SearchByAverageRating(FileManager<Restaurant> restaurantFileManager, FileManager<Review> reviewFileManager, double rating)
        {
            List<Restaurant> restaurants = restaurantFileManager.GetAllItemsFromFile();
            var filteredRestaurants = restaurants
.               Where(r => Math.Abs(r.CalculateAverageRating(reviewFileManager) - rating) < 0.0001)
                .ToList();

            return filteredRestaurants;
        }
    }
}
