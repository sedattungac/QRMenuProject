using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Controllers
{
    public class MenuController : Controller
    {
        FoodCategoryManager foodCategoryManager = new FoodCategoryManager(new EfFoodCategoryDal());
        FoodManager foodManager = new FoodManager(new EfFoodDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = foodCategoryManager.TGetList();
            return View(values);
        }
    }
}
