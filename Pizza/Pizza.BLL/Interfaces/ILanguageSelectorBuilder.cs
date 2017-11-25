namespace PizzaStore.BLL.Interfaces
{
    public interface ILanguageSelectorBuilder
    {
        ILanguageSelectorBuilder AddLanguage(string language);
        ILanguageSelector Build();
    }
}