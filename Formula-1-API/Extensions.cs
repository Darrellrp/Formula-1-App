
using Formula_1_API.Seeders;

namespace Formula_1_API
{
    public static class Extensions
    {
        public static async Task SeedDatabase(this WebApplication app, string[] args)
        {
            var seeder = new EFDatabaseSeeder(app.Services, app.Configuration);

            try
            {
                if (args.Length > 1 && args[1] != null)
                {
                    if (!int.TryParse(args[1], out var limit))
                    {
                        Console.WriteLine("Invalid second parameter: seeding limit must be an integer");
                        Environment.Exit(1);
                        return;
                    }

                    await seeder.SeedAll(limit);
                }
                else
                {
                    await seeder.SeedAll();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine($"An error occured during database seeding: {exception}");
            }
        }
    }
}