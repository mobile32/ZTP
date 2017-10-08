using Pizza.BLL.Interfaces;
using Pizza.DAL.Interfaces;

namespace Pizza.BLL.Implementations
{
    public class PizzaService:IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
    }
}