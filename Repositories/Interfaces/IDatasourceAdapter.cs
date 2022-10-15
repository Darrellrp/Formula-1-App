using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;
using Formula_1_App.Repositories.Adapters;

namespace Formula_1_App.Repositories.Interfaces
{
    public interface IDatasourceAdapter<T> : IRepository<T> where T : class
    {
        
    }
}
