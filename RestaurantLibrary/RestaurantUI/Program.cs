//while not authorized:
//        try to log the user


//1. show all possible menu options
//        -include logout
//2. select proper option
//3. diplay the result


using RestaurantLibrary;
using System.Data;

User user = new User();
FileManager<User> userFile = new FileManager<User>("./Data/Users.json");

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
    Console.WriteLine("1. Display details of a restaurant");
    Console.WriteLine("2. Add reviews to a restaurant");
    Console.WriteLine("3. View reviews of restaurants");
    Console.WriteLine("4. Calculate reviews’ average rating for each restaurant");
    Console.WriteLine("5. Search restaurant (by name, rating, zip code, etc.)");

    if (user.Role == Role.Admin)
    {
        Console.WriteLine("6. Add a new user");
        Console.WriteLine("7. Search user");
    }

    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            // DisplayRestaurantDetails();
            break;
        case 2:
            // AddRestaurantReview();
            break;
        case 3:
            // ViewRestaurantDetails();
            break;
        case 4:
            // ViewRestaurantReviews();
            break;
        case 5:
            // CalculateAverageRating();
            break;
        case 6:
            // SearchRestaurant();
            break;
        case 7:
            if (user.Role == Role.Admin)
            {
                // AddNewUser();
            }
            break;
        case 8:
            if (user.Role == Role.Admin)
            {
                // SearchUser();
            }
            break;
        case 0:
            user = new User();
            logUser();
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
