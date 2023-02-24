using DBLocalization.Demo.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBLocalization.Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {

        public HomeController(ILanguageService languageService, ILocalizationService localizationService)
            : base(languageService, localizationService) { }

        [HttpGet("GetCustomerData")]
        public IActionResult GetCustomerData()
        {
            var localisedtitle = Localize("title");
            var localisedFirstName = Localize("First Name");
            var localisedLastName = Localize("Last Name");

            return Ok(new { title= localisedtitle,FirstName= localisedFirstName, LastName=localisedLastName });
        }
    }
}
