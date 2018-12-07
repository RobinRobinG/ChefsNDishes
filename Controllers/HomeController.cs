using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
  public class HomeController : Controller
    {
        private ProjectContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(ProjectContext context)
        {
            dbContext = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(c => c.Dishes).ToList();
            return View(AllChefs);
        }
        // GET: /Dishes/
        [HttpGet]
        [Route("dishes")]
        public IActionResult DishesList()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(d => d.DishChef).ToList();
            return View(AllDishes);
        }
        // GET: /Newchef/
        [HttpGet]
        [Route("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        // GET: /Newdish/
        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> chefs = dbContext.Chefs.ToList();
            ViewBag.allchefs = chefs;
            return View("NewDish");
        }

        // POST: /newdish/
        [HttpPost]
        [Route("dishes/add")]
        public IActionResult AddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("DishesList");
            }
            List<Chef> chefs = dbContext.Chefs.ToList();
            ViewBag.allchefs = chefs;
            return View("NewDish");
        }

        [HttpGet]
        [Route("dishes/delete/{tempid}")]
        public IActionResult DeleteDish(int tempid)
        {
            Dish deletedish = dbContext.Dishes.SingleOrDefault(d => d.DishId == tempid);
            dbContext.Dishes.Remove(deletedish);
            dbContext.SaveChanges();
            return RedirectToAction("DishesList");
        }
              

        // POST: /newchef/
        [HttpPost]
        [Route("addchef")]
        public IActionResult AddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewChef");
        }

        //Delete a chef/
        [HttpGet]
        [Route("delete/{tempid}")]
        public IActionResult DeleteChef(int tempid)
        {
            Chef deleteuser = dbContext.Chefs.SingleOrDefault(c => c.ChefId == tempid);
            dbContext.Chefs.Remove(deleteuser);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
