using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula_1_API.Context
{
    public interface IDatabaseMigrator
    {
        Task Migrate();
    }
}