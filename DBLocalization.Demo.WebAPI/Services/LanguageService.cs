﻿using DBLocalization.Demo.WebAPI.Models;

namespace DBLocalization.Demo.WebAPI.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly LocalizationDbContext _context;

        public LanguageService(LocalizationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            
            return _context.Languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Languages.FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}
