using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint13.Controllers
{
    public class TasksController : Controller
    {
        string[] markets;
        Dictionary<string, int> shoppingList;

        public TasksController()
        {
            markets = new string[] { "Wellmart", "Silpo", "ATB", "Furshet", "Metro" };
            shoppingList = new Dictionary<string, int>
            {
                { "Milk", 2 },
                { "Bread", 2 },
                { "Cake", 1 },
                { "Ice Creams", 5 },
                { "Cola", 10 }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Greetings()
        {
            return View();
        }

        public IActionResult ProductInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.markets = markets;
            ViewBag.products = shoppingList.Keys;
            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(string name, string address)
        {
            string result = $"Your products will be shipped at: {address}. Bon appetite, {name}!";
            return Content(result);
        }

        public IActionResult ShoppingList()
        {
            return View(shoppingList);
        }

        public IActionResult SuperMarkets()
        {
            ViewBag.SuperMarkets = markets;
            return View();
        }

        public IActionResult SprintTasks()
        {
            return View();
        }
    }
}
