using System.ComponentModel.DataAnnotations;

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

        [Required, MaxLength(80)]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; }

        [Display(Name = ("Type of cuisine"))]
        public CuisineType Cuisine { get; set; }
    }
}
