using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Context
{
    public class EFDatabaseMigrator : IDatabaseMigrator
    {
        private readonly DbContext _context;

        public EFDatabaseMigrator(DbContext context)
        {
            _context = context;
        }

        public async Task Migrate()
        {
            Console.WriteLine("Running migrations on Database");
            await _context.Database.MigrateAsync();
            Console.WriteLine("Succesfully ran migrations on Database");
        }
    }
}