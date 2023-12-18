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


    }
}