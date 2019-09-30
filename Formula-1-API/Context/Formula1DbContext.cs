using System;
using Formula_1_API.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.IO;
using Formula_1_API.Utils;
using System.Collections.Generic;
using Formula_1_API.Utils.ClassMaps;
using Formula_1_API.Seeders;

namespace Formula_1_API.Context
{
    public class Formula1DbContext : DbContext
    {
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<ConstructorResult> ConstructorResults { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<ConstructorStanding> ConstructorStandings { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverStanding> DriverStandings { get; set; }
        public DbSet<LapTime> LapTimes { get; set; }
        public DbSet<PitStop> PitStops { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<ResultStatus> ResultStatus { get; set; }
        public DbSet<Season> Seasons { get; set; }

        public Formula1DbContext(DbContextOptions<Formula1DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EFDatabaseSeeder.Seed<Circuit>("circuits.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<ConstructorResult>("constructorResults.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<Constructor>("constructors.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<ConstructorStanding>("constructorStandings.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<Driver>("drivers.csv", modelBuilder, setIds: true, limit: 50);
            EFDatabaseSeeder.Seed<DriverStanding>("driverStandings.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<LapTime, LapTimeMap>("lapTimes.csv", modelBuilder, setIds: true, limit: 50);
            EFDatabaseSeeder.Seed<PitStop, PitStopMap>("pitStops.csv", modelBuilder, setIds: true, limit: 50);
            EFDatabaseSeeder.Seed<Qualification>("qualifying.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<Race>("races.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<RaceResult, RaceResultMap>("results.csv", modelBuilder, limit: 50);
            EFDatabaseSeeder.Seed<Season, SeasonMap>("seasons.csv", modelBuilder, setIds: true, limit: 50);
            EFDatabaseSeeder.Seed<ResultStatus>("status.csv", modelBuilder, limit: 50);
        }        
    }
}
