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


        public bool AddReviewToRestaurant(int rating, string comment, string username, Restaurant restaurant, FileManager<Review> fileManager)
        {
            Review newReview = new Review
            {
                Rating = rating,
                Comment = comment,
                User = new User { UserName = username, Role = Role.User },
                Restaurant = restaurant
            };

            fileManager.Add(newReview);

            return true;
        }
    }
}