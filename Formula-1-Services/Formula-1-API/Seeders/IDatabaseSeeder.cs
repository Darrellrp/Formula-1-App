using System;
using System.Threading.Tasks;

namespace Formula_1_API.Seeders
{
    public interface IDatabaseSeeder
    {
        Task SeedAll(int? limit = null);
    }
}

