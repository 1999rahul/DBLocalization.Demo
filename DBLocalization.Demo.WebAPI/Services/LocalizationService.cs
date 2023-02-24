using DBLocalization.Demo.WebAPI.Models;

namespace DBLocalization.Demo.WebAPI.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly LocalizationDbContext _context;

        public LocalizationService(LocalizationDbContext context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            var res=_context.StringResources.ToList();
            return _context.StringResources.FirstOrDefault(x =>
                    x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}
