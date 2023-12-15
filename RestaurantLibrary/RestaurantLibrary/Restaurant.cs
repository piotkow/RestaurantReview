namespace RestaurantLibrary
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Cuisine { get; set; }

        public List<Restaurant> GetDetails(FileManager<Restaurant> fileManager)
        {
            return fileManager.Add(new Restaurant { Id = 1, Name = "Restaurant A", ZipCode = "12345", Cuisine = "Italian" });
        }
    }
}