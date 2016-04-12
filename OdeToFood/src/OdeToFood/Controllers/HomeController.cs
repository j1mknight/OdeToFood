﻿using Microsoft.AspNet.Mvc;
using OdeToFood.ViewModels;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller 
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;
        public HomeController(
            IRestaurantData restaurantData,
            IGreeter greeter
        )
        {
            _restaurantData = restaurantData;
            _greeter = greeter; 
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();

            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                //if Id not mapping to a restaurant, just show all...
                return RedirectToAction("Index");
            }

            return View(model);
                        
        }
    }
}
