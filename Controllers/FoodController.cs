using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();


        FoodRepository foodRepository = new FoodRepository();



        public IActionResult Index(int page=1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {


            List<SelectListItem> Values = (from x in c.Categorys.ToList()
                                           select new SelectListItem

                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }


                                           ).ToList();
            ViewBag.v1 = Values;

            return View();
        }

        [HttpPost]

        public IActionResult FoodAdd(Food p)

        {
            foodRepository.TAdd(p);

            return RedirectToAction("Index");
        }


        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FoodGet(int id)
        {
            List<SelectListItem> value = (from a in c.Categorys.ToList()
                                          select new SelectListItem
                                          {
                                              Text = a.CategoryName,
                                              Value = a.CategoryID.ToString()
                                          }).ToList();

            ViewBag.ca = value;



            var x = foodRepository.TGet(id);
            Food fd = new Food()
            {

                FoodID = x.FoodID,
                Name = x.Name,

                Description = x.Description,
                ImageURL = x.ImageURL,
                Price = x.Price,
                Stok = x.Stok
            };
            return View(fd);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.FoodID = p.FoodID;
            x.CategoryID = p.CategoryID;
            x.Name = p.Name;
            x.Stok = p.Stok;
            x.Description = p.Description;
            x.Stok = p.Stok;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");

        }






    }
}
