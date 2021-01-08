using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprint_16.Models;

using Microsoft.EntityFrameworkCore;

namespace Sprint_16.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShoppingContext _context;
        public CustomerController(ShoppingContext context)
        {
            _context = context;
        }
        //
        public async Task<IActionResult> Index(string sortOrder, string searchStringName, string currentFilter,int? pageNumber)
        {

            ViewData["LNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "LName_desc" : "";
            ViewData["AddressSortParm"] = sortOrder == "Date" ? "Address_desc" : "Date";

            ViewData["CurrentFilterName"] = searchStringName;

            var customers = _context.Customers.Select(x => x);

            if (!String.IsNullOrEmpty(searchStringName))
            {
                customers = customers.Where(x => x.LName.Contains(searchStringName) == true || x.FName.Contains(searchStringName) == true);
            }

            switch (sortOrder)
            {
                case "LName_desc":
                    customers = customers.OrderByDescending(s => s.LName);
                    break;
                case "Date":
                    customers = customers.OrderBy(s => s.Address);
                    break;
                case "Address_desc":
                    customers = customers.OrderByDescending(s => s.Address);
                    break;
                default:
                    customers = customers.OrderBy(s => s.LName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(PaginatedList.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(customers);
        }


        // ----- View -----
        [HttpGet("/customer/{id}")]
        public IActionResult View(int id)
        {
            if (!IsCustomerInList(id))
            {
                return View("CustomerNotFound", id);
            }
            return View(GetCustomerById(id));
        }


        // ----- Edit -----
        [HttpGet("/customer/edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (!IsCustomerInList(id))
            {
                return View("CustomerNotFound", id);
            }
            return View(GetCustomerById(id));
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (customer.LName == null || customer.FName == null || customer.Address == null)//|| product.Price == 0)
            {
                return RedirectToAction("Index"); //"Edit", product.Id
            }

            int index = _context.Customers.ToList().FindLastIndex(x => x.Id == customer.Id);
            _context.Customers.ToList()[index].LName = customer.LName;
            _context.Customers.ToList()[index].FName = customer.FName;
            _context.Customers.ToList()[index].Address = customer.Address;
            _context.Customers.ToList()[index].Discount = customer.Discount;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // ----- Delete -----
        [Route("customer/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsCustomerInList(id))
            {
                return View("CustomerNotFound", id);
            }

            var customer = GetCustomerById(id);
            if (customer != null)
            {
                _context.Customers.Remove(GetCustomerById(id));
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // ----- Create -----
        [HttpGet("customer/create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string lName, string fName, string address, string discount)//Product product)
        {
            ViewData["CreateLName"] = lName;
            ViewData["CreateFName"] = fName;
            ViewData["CreateAddress"] = address;
            ViewData["CreateDiscount"] = discount;
            if (lName == null || fName == null || address == null)//|| product.Price == 0)
            {
                return RedirectToAction("create");
            }
            _context.Customers.AddRange( new Customer { FName = fName, LName = lName, Address = address, Discount = discount } );
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // dop
        private bool IsCustomerInList(int id)
        {
            if (!(_context.Customers).Contains(GetCustomerById(id)))
            {
                Response.StatusCode = 404;
                return false;
            }
            return true;
        }

        private Customer GetCustomerById(int id)
        {
            return (_context.Customers.FirstOrDefault(x => x.Id == id));
        }
    }
}
