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
            return fileManager.GetAllItemsFromFile();
        }
    }
}