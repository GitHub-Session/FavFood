using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fav_Food.Models;

namespace Fav_Food.Controllers
{
    public class FoodController : Controller
    {

        private List<FoodModel> _foodFavorites = new List<FoodModel>
        {
           new FoodModel(){ Id = 1, Name = "Pizza", Rating = "⭐⭐⭐"}
        };

        public IActionResult Index()
        {
            ViewBag.FoodList = _foodFavorites;
            return View();
        }

        public IActionResult Create([Bind("Id", "Name", "Rating")]FoodModel food)
        {
            if (ModelState.IsValid)
            {
                _foodFavorites.Add(new FoodModel() {Id = food.Id, Name = food.Name, Rating = food.Rating});
                return RedirectToAction("Index");
            }
            
            return View(food);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        
    }
}
