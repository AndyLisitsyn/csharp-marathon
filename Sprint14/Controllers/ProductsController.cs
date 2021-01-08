using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        [Route("products")]
        [Route("products/index")]
        [Route("items")]
        [Route("items/index")]
        public IActionResult Index(string filterId, string filtername)
        {
            if (filtername == null || filterId == null)
            {
                return View(myProducts);
            }
            else
            {
                var products = myProducts.Where(pr =>
                    pr.GetType().GetProperty(filtername).GetValue(pr, null).ToString() == filterId);
                return View(products);
            }
        }

        [Route("products/{id?}")]
        public IActionResult View(int id)
        {
            if (!IsIdCorrect(id))
                return RedirectToProductNotFound();

            return View(myProducts.Where(pr => pr.Id == id).FirstOrDefault());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsIdCorrect(id))
                return RedirectToProductNotFound();

            return View(myProducts.Where(pr => pr.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var currentProduct = myProducts.Where(pr => pr.Id == product.Id).FirstOrDefault();
            myProducts.Remove(currentProduct);
            myProducts.Add(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/products/create")]
        [Route("/products/new")]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return RedirectToAction("Index");
        }

        [Route("/products/create")]
        [Route("/products/new")]
        public IActionResult Create()
        {
            var newId = myProducts.Count == 0 ? 1 : myProducts.Max(x => x.Id) + 1;
            return View(new Product(){Id = newId});
        }

        public IActionResult Delete(int id)
        {
            if (!IsIdCorrect(id))
                return RedirectToProductNotFound();

            var currentProduct = myProducts.Where(pr => pr.Id == id).FirstOrDefault();
            myProducts.Remove(currentProduct);
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        bool IsIdCorrect(int id) => myProducts.Any(pr => pr.Id == id);

        RedirectResult RedirectToProductNotFound() => Redirect("~/Error/ProductNotFound");
    }
}
