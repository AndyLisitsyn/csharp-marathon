using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Policy = "DiscountPageAccess")]
    public class DiscountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
