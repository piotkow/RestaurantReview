namespace RestaurantLibrary
{
    /// <summary>
    /// Represents the type of cuisine of a restaurant.
    /// </summary>
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

    /// <summary>
    /// Represents a restaurant.
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public Cuisine Cuisine { get; set; }


        /// <summary>
        /// Initializes a new instance of the Restaurant class.
        /// </summary>
        /// <param name="id">The ID of the restaurant.</param>
        /// <param name="name">The name of the restaurant.</param>
        /// <param name="zipCode">The zip code of the restaurant.</param>
        /// <param name="cuisine">The cuisine of the restaurant.</param>
        public Restaurant(int id, string name, string zipCode, Cuisine cuisine)
        {
            Id = id;
            Name = name;
            ZipCode = zipCode;
            Cuisine = cuisine;
        }

        /// <summary>
        /// Calculates the average rating of the restaurant.
        /// </summary>
        /// <param name="reviewFileManager">The file manager that handles the storage of reviews.</param>
        /// <returns>Returns the average rating of the restaurant.</returns>
        public double CalculateAverageRating(FileManager<Review> reviewFileManager)
        {
            List<Review> reviews = reviewFileManager.GetAllItemsFromFile();

            var averageRating = reviews.Where<Review>(review => review.Restaurant.Id == Id).Average(review => review.Rating);

            return averageRating;
        }

        /// <summary>
        /// Returns a string that represents the current restaurant.
        /// </summary>
        /// <returns>A string that contains the name, zip code, and cuisine of the restaurant.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, ZipCode: {ZipCode}, Cuisine: {Cuisine}";
        }

    }
}