using DBLocalization.Demo.WebAPI.Models;

namespace DBLocalization.Demo.WebAPI.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
