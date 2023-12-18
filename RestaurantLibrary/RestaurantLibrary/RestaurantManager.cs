using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class RestaurantManager
    {

        public Restaurant SearchByName(FileManager<Restaurant> restaurantFileManager, string name)
        {
            List<Restaurant> restaurants = restaurantFileManager.GetAllItemsFromFile();

            var filteredRestaurant = restaurants.First<Restaurant>(r => r.Name == name);

            return filteredRestaurant;
        }

        public List<Restaurant> SearchByAverageRating(FileManager<Restaurant> restaurantFileManager, FileManager<Review> reviewFileManager, double rating)
        {
            List<Restaurant> restaurants = restaurantFileManager.GetAllItemsFromFile();

            var filteredRestaurants = restaurants.Where<Restaurant>(r => r.CalculateAverageRating(reviewFileManager) >= rating).ToList();

            return filteredRestaurants;
        }

    }
}
