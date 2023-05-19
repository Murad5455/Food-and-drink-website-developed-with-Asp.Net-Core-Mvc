using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
        [AllowAnonymous]
    
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stok = 150
            });

            cs.Add(new Class1()
            {
                proname = "Lcd",
                stok = 75

            });
            cs.Add(new Class1()
            {
                proname = "Usb disk",
                stok = 220
            });
            return cs;
        }


        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            
            return Json( FoodList());
        }
        public List<Class2>FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stok
                }).ToList();
            }



            return cs2;
        }


        public IActionResult Statistics()

        {
            Context c= new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categorys.Count();
            ViewBag.d2=deger2;


            var foid = c.Categorys.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d9 = foid;
            var deger3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.CategoryID == c.Categorys.Where(a=>a.CategoryName== "Vegetables").
            Select(y=>y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;


            var deger5 = c.Foods.Sum(x => x.Stok);
            ViewBag.d5 = deger5;



            var deger6 = c.Foods.Where(x => x.CategoryID == c.Categorys.Where(a => a.CategoryName == "Legumes").
            Select(s => s.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;



            var deger7 = c.Foods.OrderByDescending(x => x.Stok).Select(a => a.Name).FirstOrDefault();
           ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x => x.Stok).Select(a=>a.Name).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;

            var deger10p = c.Categorys.Where(a => a.CategoryName== "Fruit").Select(x=>x.CategoryID).FirstOrDefault();
            var deger10 = c.Foods.Where(x => x.CategoryID == deger10p).Sum(s => s.Stok);
            
            ViewBag.d10 = deger10;

            var deger11p = c.Categorys.Where(x => x.CategoryName == "Vegetables").Select(a => a.CategoryID).FirstOrDefault();
            var deger11 = c.Foods.Where(w => w.CategoryID == deger11p).Sum(q => q.Stok);
            ViewBag.d11 = deger11;

            var deger12 = c.Foods.OrderByDescending(x => x.Price).Select(a => a.Name).FirstOrDefault();
            ViewBag.d12 = deger12;




            return View();
        }



    }
}
