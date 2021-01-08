using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprint_16.Models;

namespace Sprint_16.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingContext _context;
        public ProductController(ShoppingContext context)
        {
            _context = context;
        }

        /*public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }*/
        public IActionResult Index(string sortOrder)
        {

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Date" ? "name_desc" : "Date";

            var products = _context.Products.Select(x => x);

            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(s => s.Id);
                    break;
                case "Date":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                default:
                    products = products.OrderBy(s => s.Id);
                    break;
            }
            return View(products);
        }

        // ----- View -----
        [HttpGet("/product/{id}")]
        public IActionResult View(int id)
        {
            if (!IsProductInList(id))
            {
                return View("ProductNotFound", id);
            }
            return View(GetProductById(id));
        }


        // ----- Edit -----
        [HttpGet("/product/edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (!IsProductInList(id))
            {
                return View("ProductNotFound", id);
            }
            return View(GetProductById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product.Name == null )//|| product.Price == 0)
            {
                return RedirectToAction("Index"); //"Edit", product.Id
            }

            int index = _context.Products.ToList().FindLastIndex(x => x.Id == product.Id);
            _context.Products.ToList()[index].Name = product.Name;
            _context.Products.ToList()[index].Price = product.Price;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // ----- Create -----
        [HttpGet("product/create")]
        public IActionResult Create()
        {
            return View();//new Product() { Id = ((_context.Products.LastOrDefault()).Id + 1), Name = null, Price = 0 });
        }
        [HttpPost]
        public IActionResult Create(string name, string price)//Product product)
        {
            ViewData["CreateName"] = name;
            ViewData["CreatePrice"] = price;
            if (name != null )//|| product.Price == 0)
            {
                if (double.TryParse(price, out double result))
                {
                    _context.Products.AddRange(
                        new Product { Name = name, Price = result }
                    );
                    _context.SaveChanges();
                }
                else
                {
                    return RedirectToAction("create");
                }
            }
            else
            {
                return RedirectToAction("create");
            }
            return RedirectToAction("Index");
        }


        // ----- Delete -----_context.Products.ToList()
        [Route("product/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsProductInList(id))
                return View("ProductNotFound", id);

            var product = GetProductById(id);//_context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(GetProductById(id));//_context.Products.First(p => p.Id == id));
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // dop
        private bool IsProductInList(int id)
        {
            if (!(_context.Products).Contains(GetProductById(id)))
            {
                Response.StatusCode = 404;
                return false;
            }
            return true;
        }

        private Product GetProductById(int id)
        {
            return (_context.Products.FirstOrDefault(x => x.Id == id));
        }
    }
}
