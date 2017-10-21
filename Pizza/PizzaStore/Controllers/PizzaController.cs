using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PizzaStore.Models;
using PizzaStore.BLL.Interfaces;

namespace PizzaStore.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this._pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            return View(_pizzaService.GetAll());
        }

        public IActionResult test(string lang, string id)
        {
            return Json(_pizzaService.GetByLanguage(new ObjectId(id), lang));
        }
        public void addpizza([FromBody] PizzaStore.DAL.Pizza pizza)
        {

        }
    }
}
