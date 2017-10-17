namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        Franch,
        Japanese,
        American
    }

    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
