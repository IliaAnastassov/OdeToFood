using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
    public class HomePageViewModel
    {
        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
