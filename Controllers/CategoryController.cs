using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
       // [Authorize]
        public IActionResult Index()
        {

            return View(categoryRepository.TList());
          
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }

            categoryRepository.TAdd(p);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                CategoryDescription=x.CategoryDescription
            };
            return View(ct);
        }

        public IActionResult CategoryUpdate(Category p)
        {
            var a = categoryRepository.TGet(p.CategoryID);
            a.CategoryID = p.CategoryID;
            a.CategoryName = p.CategoryName;
            a.CategoryDescription = p.CategoryDescription;
            a.Status = true;
            categoryRepository.TUpdate(a);



            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var a=categoryRepository.TGet(id);
            a.Status = false;
            categoryRepository.TUpdate(a);
            return RedirectToAction("Index");
        }


    }
}
