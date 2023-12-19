using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    /// <summary>
    /// This class manages reviews. 
    /// </summary>
    public class ReviewManager
    {
        /// <summary>
        /// Adds a new review for a restaurant.
        /// </summary>
        /// <param name="rating">The rating given by the user.</param>
        /// <param name="comment">The comment provided by the user.</param>
        /// <param name="user">The user who is adding the review.</param>
        /// <param name="restaurant">The restaurant that is being reviewed.</param>
        /// <param name="fileManager">The file manager that handles the storage of reviews.</param>
        /// <returns>Returns true if the review is successfully added.</returns>
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

        /// <summary>
        /// Retrieves all restaurant reviews.
        /// </summary>
        /// <param name="fileManager">The file manager that handles the storage of reviews.</param>
        /// <returns>Returns a list of all reviews from the file.</returns>
        public List<Review> ViewRestaurantReviews(FileManager<Review> fileManager)
        {
            return fileManager.GetAllItemsFromFile();
        }

    }
}
