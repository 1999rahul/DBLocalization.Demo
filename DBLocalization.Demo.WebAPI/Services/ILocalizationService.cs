using DBLocalization.Demo.WebAPI.Models;

namespace DBLocalization.Demo.WebAPI.Services
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);
    }
}
