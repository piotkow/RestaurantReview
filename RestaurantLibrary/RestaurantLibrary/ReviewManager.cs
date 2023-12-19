using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class ReviewManager
    {
        public bool AddRestaurantReview(int rating, string comment, User user, Restaurant restaurant, FileManager<Review> fileManager)
        {
            Review newReview = new Review
            {
                Rating = rating,
                Comment = comment,
                User = user,
                Restaurant = restaurant
            };

            fileManager.Add(newReview);

            return true;
        }

        public List<Review> ViewRestaurantReviews(FileManager<Review> fileManager)
        {
            return fileManager.GetAllItemsFromFile();
        }

    }
}
