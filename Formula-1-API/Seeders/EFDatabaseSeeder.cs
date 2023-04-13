﻿using System;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Formula_1_API.Factories;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Formula_1_API.Services;
using Formula_1_API.Datasources;
using Formula_1_API.Datasources.ClassMaps;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Seeders
{
    public class EFDatabaseSeeder : IDatabaseSeeder
    {
        private const string CONFIGURATION_KEY = "DataSourcePath";
        private readonly string _basePath;

        private IServiceProvider _provider { get; set; }

        public EFDatabaseSeeder(IServiceProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _basePath = configuration.GetValue<string>(CONFIGURATION_KEY);
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
        
            if(await repository.Count() > 1)
            {
                Console.Write($": already seeded \n");
                return;
            }

            var reader = CsvReaderFactory.Create(_basePath);
            var items = reader.Read<T>(filename);

            if(limit != null && limit != 0)
            {
                items = items.Take((int) limit).ToList();
            }
            
            Console.WriteLine();
            await repository.AddMany(items);
        }

        public async Task Seed<T, Map>(string filename, int? limit = null) where T : class, IEntity where Map : ClassMap
        {
            var typeName = typeof(T).Name;
            Console.Write($"- {typeName}");

            var repository = _provider.GetService<IRepository<T>>();

            if (repository == null)
            {
                throw new Exception($"Unable to Get {typeName}Repository from ServiceProvider");
            }

            if(await repository.Count() > 1)
            {
                Console.Write($": already seeded \n");
                return;
            }

            var reader = CsvReaderFactory.Create(_basePath);
            var items = reader.Read<T, Map>(filename).ToList();

            if (limit != null && limit != 0)
            {
                items = items.Take((int)limit).ToList();
            }

            Console.WriteLine();
            await repository.AddMany(items);
        }
    }
}