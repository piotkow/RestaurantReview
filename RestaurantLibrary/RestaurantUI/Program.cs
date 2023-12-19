
using RestaurantLibrary;
using System.Data;

User user = new User();
FileManager<User> userFile = new FileManager<User>(@"..\..\..\Data\Users.json");
FileManager<Restaurant> restaurantFile = new FileManager<Restaurant>(@"..\..\..\Data\Restaurants.json");
FileManager<Review> reviewFile = new FileManager<Review>(@"..\..\..\Data\Reviews.json");
RestaurantManager restaurantManager = new RestaurantManager();
ReviewManager reviewManager = new ReviewManager();

void logUser()
{
    while (user.Id == -1)
    {
        Console.WriteLine("Enter your login:");
        string login = Console.ReadLine() ?? "";
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine() ?? "";
        user = User.LogIn(login, password, userFile);
    }
}

logUser();


while (true)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("0. Logout");
    Console.WriteLine("1. Add reviews to a restaurant");
    Console.WriteLine("2. View reviews of restaurants");
    Console.WriteLine("3. Calculate reviews’ average rating for each restaurant");
    Console.WriteLine("4. Search restaurant by name");
    Console.WriteLine("5. Search restaurant by average rating");

    if (user.Role == Role.Admin)
    {
        Console.WriteLine("6. Add a new user");
        Console.WriteLine("7. Search user");
    }

    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("Restaurant name: ");
            string nameC1 = Console.ReadLine();
            Restaurant resC1 = restaurantManager.SearchByName(restaurantFile, nameC1);
            Console.WriteLine("Rating: ");
            int rating = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Comment: ");
            string comment = Console.ReadLine();
            reviewManager.AddRestaurantReview(rating, comment, user, resC1, reviewFile);
            break;
        case 2:
            List<Review> reviews = reviewManager.ViewRestaurantReviews(reviewFile);
            foreach (Review review in reviews)
            {
                Console.WriteLine(review.ToString());
            }
            break;
        case 3:
            Console.WriteLine("Restaurant name: ");
            string nameC3 = Console.ReadLine();
            Restaurant resC3 = restaurantManager.SearchByName(restaurantFile, nameC3);
            Console.WriteLine("Average rating: " + resC3.CalculateAverageRating(reviewFile));
            break;
        case 4:
            Console.WriteLine("Name: ");
            string nameC4 = Console.ReadLine();
            Console.WriteLine(restaurantManager.SearchByName(restaurantFile, nameC4));
            break;
        case 5:
            Console.WriteLine("Average rating: ");
            string ratingC5 = Console.ReadLine();
            List<Restaurant> listC5 = restaurantManager.SearchByAverageRating(restaurantFile, reviewFile, Double.Parse(ratingC5));
            if (!listC5.Any())
            {
                Console.WriteLine("No restaurant with such avarage rating");
                break;
            }
            foreach (Restaurant restaurant in listC5)
            {
                Console.WriteLine(restaurant.ToString());
            }
            break;
        case 6:
            if (user.Role == Role.Admin)
            {
                Console.WriteLine("Username: ");
                string usernameC6 = Console.ReadLine();
                Console.WriteLine("Password: ");
                string passwordC6 = Console.ReadLine();
                user.AddNewUser(usernameC6, passwordC6, Role.User, userFile);
            }
            break;
        case 7:
            if (user.Role == Role.Admin)
            {
                Console.WriteLine("Username: ");
                string usernameC7 = Console.ReadLine();
                User userC7 = User.SearchByName(usernameC7, userFile);
                Console.WriteLine("Username: " + userC7.UserName + "\nRole: " + userC7.Role);
            }
            break;
        case 0:
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
