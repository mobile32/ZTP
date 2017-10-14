using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public void addpizza([FromBody] PizzaStore.DAL.Pizza pizza)
        {

        }
    }
}
