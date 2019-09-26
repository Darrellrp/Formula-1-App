﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;

namespace Formula_1_API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> FindById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
