using System;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Formula_1_App.Factories;
using Formula_1_App.Models;
using Formula_1_App.Utils;
using Formula_1_App.Utils.ClassMaps;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_App.Seeders
{
    public static class EFDatabaseSeeder
    {
        private static readonly string BasePath = "Data/formula-1-race-data";

        public static Task SeedAll(int? limit = null, bool setIds = false)
        {
            //EFDatabaseSeeder.Seed<Circuit>("circuits.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<ConstructorResult>("constructorResults.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<Constructor>("constructors.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<ConstructorStanding>("constructorStandings.csv", modelBuilder);
            //EFDatabaseSeeder.Seed<Driver>("drivers.csv", modelBuilder, setIds: true);
            //EFDatabaseSeeder.Seed<DriverStanding>("driverStandings.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<LapTime, LapTimeMap>("lapTimes.csv", modelBuilder, limit, setIds);
            //EFDatabaseSeeder.Seed<PitStop, PitStopMap>("pitStops.csv", modelBuilder, limit, setIds);
            //EFDatabaseSeeder.Seed<Qualification>("qualifying.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<Race>("races.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<RaceResult, RaceResultMap>("results.csv", modelBuilder, limit);
            //EFDatabaseSeeder.Seed<Season, SeasonMap>("seasons.csv", modelBuilder, limit, setIds);
            //EFDatabaseSeeder.Seed<ResultStatus>("status.csv", modelBuilder, limit);
            Console.WriteLine("Seed initiated...");

            return Task.CompletedTask;
        }

        public static ModelBuilder Seed<T>(string filename, ModelBuilder modelBuilder, int? limit = null, bool setIds = false) where T : class, IIdentifier
        {
            var reader = CsvReaderFactory.Create(BasePath);
            var items = reader.Read<T>(filename).ToList();

            if(limit != null)
            {
                items = items.Take((int)limit).ToList();
            }            

            if (setIds)
            {
                Helper.SetModelIds(items);
            }
            
            modelBuilder.Entity<T>().HasData(items.ToArray());            

            return modelBuilder;
        }

        public static ModelBuilder Seed<T, Map>(string filename, ModelBuilder modelBuilder, int? limit = null, bool setIds = false) where T : class, IIdentifier where Map : ClassMap
        {
            var reader = CsvReaderFactory.Create(BasePath);
            var items = reader.Read<T, Map>(filename).ToList();

            if (limit != null)
            {
                items = items.Take((int)limit).ToList();
            }

            if (setIds)
            {
                Helper.SetModelIds(items);
            }

            modelBuilder.Entity<T>().HasData(items.ToArray());

            return modelBuilder;
        }
    }
}
