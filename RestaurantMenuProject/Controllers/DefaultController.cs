using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Controllers
{
    public class DefaultController : Controller
    {
        FoodCategoryManager foodCategoryManager = new FoodCategoryManager(new EfFoodCategoryDal());
        FoodManager foodManager = new FoodManager(new EfFoodDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = foodCategoryManager.TGetList().Where(x => x.Status == true).ToList();
            return View(values);
        }
        public IActionResult MenuDetail(int id)
        {
            var value = context.Foods.Where(x => x.FoodCategoryId == id).ToList();
            ViewBag.category = context.FoodCategories.
                Where(x => x.FoodCategoryId == id).Select(x => x.Title).FirstOrDefault();
            return View(value);
        }
        [HttpGet]
        public IActionResult Reservation()
        {
            return View();
        }
    }
}
