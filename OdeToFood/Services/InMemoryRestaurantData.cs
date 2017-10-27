using System.Collections.Generic;
using System.Linq;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        // BAD practice: not thread safe!
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Mike's Burgers", Cuisine = CuisineType.American },
                new Restaurant { Id = 2, Name = "Don Vito Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "City Sushi", Cuisine = CuisineType.Japanese }
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);

            return restaurant;
        }

        public void Commit()
        {
            // NA
        }
    }
}
