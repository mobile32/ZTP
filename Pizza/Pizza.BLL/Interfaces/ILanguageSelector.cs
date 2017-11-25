using PizzaStore.DAL;

namespace PizzaStore.BLL.Interfaces
{
    public interface ILanguageSelector
    {
        Pizza GetTranslation(Pizza pizza);
    }
}