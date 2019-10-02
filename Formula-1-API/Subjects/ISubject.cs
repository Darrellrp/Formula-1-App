﻿using System;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects
{
    public interface ISubject<T> where T : IIdentifier
    {
        Task Update(T entity);
    }
}
