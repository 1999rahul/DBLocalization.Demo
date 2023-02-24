using DBLocalization.Demo.WebAPI.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBLocalization.Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;

        public BaseController(ILanguageService languageService, ILocalizationService localizationService)
        {
            _languageService = languageService;
            _localizationService = localizationService;
        }

        public string Localize(string resourceKey)
        {
            var currentCulture = Request.Headers["Accept-Language"].ToString();

            if (string.IsNullOrEmpty(currentCulture))
            {
                currentCulture = "en-IN";
            }
            //var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);
            
            if (language != null)
            {
                var stringResource = _localizationService.GetStringResource(resourceKey, language.Id);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                {
                    return resourceKey;
                }

                return stringResource.Value;
            }
            return resourceKey;
        }
    }
}
