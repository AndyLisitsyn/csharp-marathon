using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWithRouting.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ProductNotFound()
        {
            return View();
        }
    }
}
