
using System.Text.RegularExpressions;
using Formula_1_API.Context;
using Formula_1_API.Seeders;

namespace Formula_1_API
{
    public static class Extensions
    {
        public static async Task SeedDatabase(this WebApplication app, int? limit)
        {
            var seeder = app.Services.GetRequiredService<IDatabaseSeeder>();

            try
            {
                if (limit == null)
                {
                    await seeder.SeedAll();
                }
                else
                {
                    await seeder.SeedAll(limit);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine($"An error occured during database seeding: {exception}");
            }
        }

        public static async Task RunMigrations(this WebApplication app)
        {
            var migrator = app.Services.GetRequiredService<IDatabaseMigrator>();

            try
            {
                await migrator.Migrate();
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine($"An error occured during database seeding: {exception}");
            }
        }

        public static string AddSpacesToPascalCase(this string text)
        {
            return Regex.Replace(text, "(\\B[A-Z])", " $1");
        }
    }
}