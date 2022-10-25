﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula_1_App.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_App.Subjects
{
    public interface ISubject<T> where T : IEntity
    {
        Task NotifyAdd(T entity);
        Task NotifyAddMany(IEnumerable<T> entities);
        Task NotifyUpdate(T entity);
        Task NotifyRemove(T entity);
    }
}
