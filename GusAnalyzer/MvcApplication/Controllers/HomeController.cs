using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGusAnalyzer _gus;

        public HomeController(IGusAnalyzer gus)
        {
            _gus = gus;
        }
        public IActionResult Index()
        {
            return Json(_gus.GetLocations(@"D:\test\simc.xml"));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}