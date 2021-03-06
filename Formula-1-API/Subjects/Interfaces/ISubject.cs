﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects.Interfaces
{
    public interface ISubject<T> where T : IIdentifier
    {
        Task NotifyAdd(T entity);
        Task NotifyAddMany(List<T> entities);
        Task NotifyUpdate(T entity);
        Task NotifyRemove(T entity);
    }
}
