using DBLocalization.Demo.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DBLocalization.Demo.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LocalizationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:sqlConnection").Value);

            });
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ILocalizationService, LocalizationService>();

            builder.Services.AddLocalization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var serviceProvider = builder.Services.BuildServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var languages = languageService.GetLanguages();
            var supportedCultures = languages.Select(x => x.Culture).ToArray();

            //var supportedCultures = new[] { "en-US", "hi-IN" };
            var localizationOptions =
                new RequestLocalizationOptions().SetDefaultCulture("en-US")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseRequestLocalization();


            app.MapControllers();

            app.Run();
        }
    }
}