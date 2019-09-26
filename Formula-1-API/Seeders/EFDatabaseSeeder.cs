using System;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Formula_1_API.Models;
using Formula_1_API.Utils;
using Formula_1_API.Utils.ClassMaps;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Seeders
{
    public static class EFDatabaseSeeder
    {
        private static readonly string BasePath = "Data/formula-1-race-data";

        public static ModelBuilder Seed<T>(string filename, ModelBuilder modelBuilder, bool setIds = false) where T : class, IIdentifier
        {
            var reader = new CsvReader(BasePath);
            var items = reader.Read<T>(filename).Take(10).ToList();

            if (setIds)
            {
                Helper.SetModelIds(items);
            }
            
            modelBuilder.Entity<T>().HasData(items.ToArray());            

            return modelBuilder;
        }

        public static ModelBuilder Seed<T, Map>(string filename, ModelBuilder modelBuilder, bool setIds = false) where T : class, IIdentifier where Map : ClassMap
        {
            var reader = new CsvReader(BasePath);
            var items = reader.Read<T, Map>(filename).Take(10).ToList();

            if (setIds)
            {
                Helper.SetModelIds(items);
            }

            modelBuilder.Entity<T>().HasData(items.ToArray());

            return modelBuilder;
        }
    }
}
