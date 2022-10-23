using System;
using System.Threading.Tasks;

namespace Formula_1_App.Seeders
{
    public interface IDatabaseSeeder
    {
        Task SeedAll(int? limit);
    }
}

