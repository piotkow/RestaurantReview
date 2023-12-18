namespace RestaurantLibrary
{
    public enum Cuisine
    {
        Chinese,
        Japanese,
        Korean,
        Thai,
        Italian,
        Indian,
        Mexican,
        Polish,
        Lebanese,
        Romanian,
        Greek,
        Turkish,
        Other
    }
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public Cuisine Cuisine { get; set; }


        public Restaurant(int id, string name, string zipCode, Cuisine cuisine)
        {
            Id = id;
            Name = name;
            ZipCode = zipCode;
            Cuisine = cuisine;
        }

        public void SeedRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant(1,"Pierogi Place","80-001",Cuisine.Polish),
                new Restaurant(2,"Tacos El Sol","70-003",Cuisine.Mexican),
                new Restaurant(3,"Best Kebab","53-089",Cuisine.Turkish),
                new Restaurant(4,"Bella Napoli Pizzeria","50-003",Cuisine.Italian),
                new Restaurant(5,"Thai Orchid","40-456",Cuisine.Thai),
                new Restaurant(6,"Delicious Sarmale","10-568",Cuisine.Romanian),
                new Restaurant(7,"Taj Tandoori","93-893",Cuisine.Indian),
                new Restaurant(8,"Dragon's Delight","38-002",Cuisine.Chinese),
                new Restaurant(9,"Sakura Sushi","30-709",Cuisine.Japanese),
                new Restaurant(10,"Seoul Savory","11-231",Cuisine.Korean),
                new Restaurant(11,"Aegean Eats","46-078",Cuisine.Greek)

            };
        }

        public List<Restaurant> GetDetails(FileManager<Restaurant> restaurantFileManager)
        {
            return restaurantFileManager.GetAllItemsFromFile();
        }

        public List<Restaurant> SearchByName(FileManager<Restaurant> restaurantFileManager, string name)
        {
            List<Restaurant> restaurants = restaurantFileManager.GetAllItemsFromFile();

            var filteredRestaurants = restaurants.Where<Restaurant>(r => r.Name == name).ToList();

            return filteredRestaurants;
        }



    }
}