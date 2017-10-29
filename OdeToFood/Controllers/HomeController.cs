using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Restaurants = _restaurantData.GetAll()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;
                restaurant = _restaurantData.Add(restaurant);
                _restaurantData.Commit();

                return RedirectToAction(nameof(Details), new { Id = restaurant.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);

            if (ModelState.IsValid)
            {
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;
                _restaurantData.Commit();

                return RedirectToAction(nameof(Details), new { Id = restaurant.Id });
            }
            else
            {
                return View(restaurant);
            }
        }
    }
}
