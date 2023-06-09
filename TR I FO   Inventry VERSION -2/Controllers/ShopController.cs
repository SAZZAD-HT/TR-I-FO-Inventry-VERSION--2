﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TR_I_FO___Inventry_VERSION__2.Models;
using TR_I_FO___Inventry_VERSION__2.Models.Databases;
using System.IO;
using Microsoft.Identity.Client;

namespace TR_I_FO___Inventry_VERSION__2.Controllers
{
    public class ShopController : Controller
    {
        private readonly context _context;

      
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShopController(IWebHostEnvironment webHostEnvironment, context context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewShop()
        {
            var db = new context();
            var emp = db.Shop.ToList();

            return View(emp);
        }

        [HttpGet]
        public IActionResult AddToshop()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult AddToshop(Shop h, IFormFile file)
        {
            //Image save in folder 
            if (file != null && file.Length > 0)
            {


                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images");//folder set in wwwroot 
                var maxNumber = Directory.GetFiles(path)                           //Cheaking existing image in same name 
                    .Select(f => Path.GetFileNameWithoutExtension(f))
                    .Where(f => f.StartsWith("pic"))
                    .Select(f => int.Parse(f.Substring(3)))
                    .DefaultIfEmpty(0)
                    .Max();
                var newFileName = $"pic{maxNumber + 1}{Path.GetExtension(file.FileName)}";//assigning name
                var fullPath = Path.Combine(path, newFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyToAsync(stream);//core feture
                }
                h.sPicture = fullPath;
            }
            else {h.sPicture ="images/images.png"; }
            //Stock Update
            if (h.Quantity != null)
            {
                h.stock = "IN STOCK";
            }
            else
            {
                h.stock = "OUT OF STOCK";

            }
            //Profit Calculation 
            void profit()
            {
                h.profit = h.Sell_Price - h.Buy_Price;
            }
            
            var db = new context();
            db.Shop.Add(h);
            db.SaveChanges();
            return RedirectToAction("ViewShop");
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var db = new context();
            var Shops = (from sh in db.Shop
                             where sh.Shop_prd_id == id
                             select sh).SingleOrDefault();
                return View(Shops)
          

                ;
        }



        [HttpPost]
        public IActionResult Edit(Shop h)
        {
            var db = new context();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == h.Shop_prd_id
                         select sh).SingleOrDefault();
            Shops.sProduct_name = h.sProduct_name;
            Shops.country = h.country;
            Shops.sDescription = h.sDescription;
            Shops.sPicture = h.sPicture;
            Shops.sell_date = h.sell_date;
            Shops.Buy_Price = h.Buy_Price;
            Shops.Sell_Price = h.Sell_Price;
            Shops.Quantity = h.Quantity;
            Shops.Customer_name = h.Customer_name;
            Shops.CustomerEmail = h.CustomerEmail;
            Shops.Customer_mobiler = h.Customer_mobiler;
            if (Shops.Quantity != null)
            {
                h.stock = "IN STOCK";
            }
            else
            {
                h.stock = "OUT OF STOCK";

            }

            db.SaveChanges();
            return Redirect("ViewShop");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var db = new context();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();

            return View(Shops);
        }
        [HttpPost]
        public IActionResult Delete(Shop sh)
        {
            var db = new context();
            var Shops = (from shi in db.Shop
                         where shi.Shop_prd_id == sh.Shop_prd_id
                         select shi).SingleOrDefault();
            db.Shop.Remove(Shops);
            db.SaveChanges();
            return RedirectToAction("ViewShop");
        }
        public IActionResult Details(int id)
        {
            var db = new context();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();


            return View(Shops);
        }
        public IActionResult image_cheack()
        {
            var dummy = "C:\\Users\\SAZZAD H.T\\source\\repos\\Trifo(Inventory_Management)\\Trifo(Inventory_Management)\\App_data\\PicturesSave\\pic8.jpg";
            return View(dummy);
        }
    }
}
