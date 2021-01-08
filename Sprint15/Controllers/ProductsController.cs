using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Services;
using static ProductsValidation.Models.Product;

namespace ProductsValidation.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }

        [Route("products/details/{id}")]
        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
                return View("View", product);
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                myProducts.Add(product);
                return View("View", product);
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Create()
        {
            return View(new Product(){Id = myProducts.Last().Id + 1});
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove(myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult ChangePrice(Product.Category category)
        {
            var typeProduct = myProducts.Where(prod => prod.Type == category).ToList();
            return View(typeProduct);
        }

        [HttpPost]
        public IActionResult ChangePrice(List<Product> typeProducts)
        {
            SetNewPrice(typeProducts);
            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetNewPrice(List<Product> products)
        {
            foreach (var prod in products)
            {
                var tempProduct = myProducts.FirstOrDefault(x => x.Id == prod.Id);
                if (tempProduct != null)
                {
                    tempProduct.Price = prod.Price;
                }
            }
        }
    }
}
