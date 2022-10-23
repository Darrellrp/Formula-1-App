using System;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Formula_1_App.Factories;
using Formula_1_App.Models;
using Formula_1_App.Repositories;
using Formula_1_App.Services;
using Formula_1_App.Datasources;
using Formula_1_App.Datasources.ClassMaps;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_App.Seeders
{
    public class EFDatabaseSeeder : IDatabaseSeeder
    {
        private readonly string _basePath = "Data/formula-1-race-data";

        private IServiceProvider _provider { get; set; }

        public EFDatabaseSeeder(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task SeedAll(int? limit = null)
        {

            Console.WriteLine("Started Database seeding...");

            if (limit != null && limit != 0) {
                Console.WriteLine($"Limit: {limit}");
            }

            Console.WriteLine();

            await Seed<Circuit>("circuits.csv", limit);
            await Seed<ConstructorResult>("constructorResults.csv", limit);
            await Seed<Constructor>("constructors.csv", limit);
            await Seed<ConstructorStanding>("constructorStandings.csv");
            await Seed<Driver>("drivers.csv");
            await Seed<DriverStanding>("driverStandings.csv", limit);
            await Seed<LapTime, LapTimeMap>("lapTimes.csv", limit);
            await Seed<PitStop, PitStopMap>("pitStops.csv", limit);
            await Seed<Qualification>("qualifying.csv", limit);
            await Seed<Race>("races.csv", limit);
            await Seed<RaceResult, RaceResultMap>("results.csv", limit);
            await Seed<Season, SeasonMap>("seasons.csv", limit);
            await Seed<ResultStatus>("status.csv", limit);

            Console.WriteLine();
            Console.WriteLine("Completed Database seeding!");
        }

        public async Task Seed<T>(string filename, int? limit = null) where T : class, IEntity
        {
            var typeName = typeof(T).Name;
            Console.Write($"- {typeName}");

            var repository = _provider.GetService<IRepository<T>>();

            if(repository == null)
            {
                throw new Exception($"Unable to get {typeName}Repository from ServiceProvider");
            }

            var reader = CsvReaderFactory.Create(_basePath);
            var items = reader.Read<T>(filename);

            if(limit != null && limit != 0)
            {
                items = items.Take((int) limit).ToList();
            }

            var existingRecords = await repository.GetAll();
            var newRecords = items.Where(x => !existingRecords.Contains(x)).ToList();

            if(newRecords.Count < 1 || (existingRecords.Count > 1 && newRecords.All(x => x.Id == null)))
            {
                Console.Write($": already seeded \n");
                return;
            }

            Console.WriteLine();
            await repository.AddMany(newRecords);
        }

        public async Task Seed<T, Map>(string filename, int? limit = null) where T : class, IEntity where Map : ClassMap
        {
            var typeName = typeof(T).Name;
            Console.Write($"- {typeName}");

            var repository = _provider.GetService<IRepository<T>>();

            if (repository == null)
            {
                throw new Exception($"Unable to Get {typeName}Repository");
            }

            var reader = CsvReaderFactory.Create(_basePath);
            var items = reader.Read<T, Map>(filename).ToList();

            if (limit != null && limit != 0)
            {
                items = items.Take((int)limit).ToList();
            }

            var existingRecords = await repository.GetAll();
            var newRecords = items.Where(x => !existingRecords.Contains(x)).ToList();

            if (newRecords.Count < 1 || (existingRecords.Count > 1 && newRecords.All(x => x.Id == null)))
            {
                Console.Write($": already seeded \n");
                return;
            }

            Console.WriteLine();
            await repository.AddMany(newRecords);
        }
    }
}
