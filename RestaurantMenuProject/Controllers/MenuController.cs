using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public ActionResult MenuDetail(int? id)
        {
            var value = context.Foods.Where(x => x.FoodCategoryId == id).ToList();
            ViewBag.category = context.FoodCategories.Where(x => x.FoodCategoryId == id).Select(x => x.Title).FirstOrDefault();
            return View(value);
        }
        public ActionResult Status(int id)
        {
            using Context context = new Context();
            var value = context.FoodCategories.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
                foodCategoryManager.TUpdate(value);
                return RedirectToAction("Index");

            }
            else
            {
                value.Status = true;
                foodCategoryManager.TUpdate(value);
                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = foodCategoryManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(FoodCategory foodCategory)
        {

            foodCategoryManager.TUpdate(foodCategory);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var getId = foodCategoryManager.TGetById(id);
            foodCategoryManager.TDelete(getId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(FoodCategory foodCategory)
        {
            foodCategoryManager.TAdd(foodCategory);
            return RedirectToAction("Index");
        }
        //Food
        public IActionResult FoodList()
        {
            var values = foodManager.GetFoodWithFoodCategory().ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditFood(int id)
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.FoodCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.FoodCategoryId.ToString()

                                             }).ToList();
            ViewBag.category = category;
            var value = foodManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditFood(Food food)
        {
            foodManager.TUpdate(food);
            return RedirectToAction("FoodList");
        }
        public IActionResult DeleteFood(int id)
        {
            var getId = foodManager.TGetById(id);
            foodManager.TDelete(getId);
            return RedirectToAction("FoodList");
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.FoodCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.FoodCategoryId.ToString()

                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            foodManager.TAdd(food);
            return RedirectToAction("FoodList");
        }
    }
}
