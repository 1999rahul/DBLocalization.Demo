using DBLocalization.Demo.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLocalization.Demo.WebAPI
{
    public class LocalizationDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }

        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options) { }
    }
}
