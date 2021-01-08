using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprint_16.Models;

namespace Sprint_16.Controllers
{
    public class Supermarkets : Controller
    {
        private readonly ShoppingContext _context;

        public Supermarkets(ShoppingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Supermarkets.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Supermarket());
        }

        [HttpPost]
        public IActionResult Create(Supermarket supermarket)
        {
            _context.Add(supermarket);
            _context.SaveChanges();
            return View("Details", supermarket);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supermarket = _context.Supermarkets.FirstOrDefault(s => s.Id == id);
            return View(supermarket);
        }

        [HttpPost]
        public IActionResult Edit(Supermarket supermarket)
        {
            var supermarketToEdit = _context.Supermarkets.FirstOrDefault(s => s.Id == supermarket.Id);
            supermarketToEdit.Name = supermarket.Name;
            supermarketToEdit.Address = supermarket.Address;
            _context.SaveChanges();
            return View("Details", supermarket);
        }

        public IActionResult Details(int id)
        {
            var supermarket = _context.Supermarkets.FirstOrDefault(s => s.Id == id);
            return View(supermarket);
        }

        public IActionResult Delete(int id)
        {
            var supermarket = _context.Supermarkets.FirstOrDefault(s => s.Id == id);
            _context.Remove(supermarket);
            _context.SaveChanges();
            return View("Index", _context.Supermarkets.ToList());
        }
    }
}
