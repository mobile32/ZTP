using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}