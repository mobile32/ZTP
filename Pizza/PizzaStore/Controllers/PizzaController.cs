using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PizzaStore.BLL.Interfaces;

namespace PizzaStore.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index(string lang, string id)
        {
            return Json(_pizzaService.GetByLanguage(new ObjectId(id), lang));
        }
    }
}
