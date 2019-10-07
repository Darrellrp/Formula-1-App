using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories.Adapters;

namespace Formula_1_API.Repositories.Interfaces
{
    public interface IDatasourceAdapter<T> : IRepository<T> where T : class
    {
        
    }
}
