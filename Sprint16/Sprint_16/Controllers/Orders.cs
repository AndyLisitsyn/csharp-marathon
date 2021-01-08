using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprint_16.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sprint_16.Controllers
{
    public class Orders : Controller
    {
        private readonly ShoppingContext _context;

        public Orders(ShoppingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Orders.Include(o => o.Supermarket).Include(o => o.Customer).ToList());
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.Include(o => o.OrderDetails).ThenInclude(d => d.Product).FirstOrDefault(o => o.Id == id);
            return View(order.OrderDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["SuperMarketId"] = new SelectList(_context.Supermarkets, "Id", "Id");
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["SuperMarketId"] = new SelectList(_context.Supermarkets, "Id", "Id");
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            var orderToEdit = _context.Orders.FirstOrDefault(s => s.Id == order.Id);
            orderToEdit.CustomerId = order.CustomerId;
            orderToEdit.SupermarketId = order.SupermarketId;
            orderToEdit.OrderDate = order.OrderDate;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditOrderDetails(int id)
        {
            var orderDetails = _context.OrderDetails.FirstOrDefault(o => o.Id == id);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View(orderDetails);
        }

        [HttpPost]
        public IActionResult EditOrderDetails(OrderDetail orderDetails)
        {
            var orderDetailsToEdit = _context.OrderDetails.FirstOrDefault(s => s.Id == orderDetails.Id);
            orderDetailsToEdit.ProductId = orderDetails.ProductId;
            orderDetailsToEdit.Quantity = orderDetails.Quantity;
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = orderDetails.OrderId });
        }

        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            _context.Remove(order);
            _context.SaveChanges();
            return View("Index", _context.Orders.ToList());
        }

        public IActionResult DeleteOrderDetails(int id)
        {
            var orderDetailsToRemove = _context.OrderDetails.FirstOrDefault(o => o.Id == id);
            var orderId = orderDetailsToRemove.OrderId;
            _context.Remove(orderDetailsToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = orderId });
        }
    }
}
