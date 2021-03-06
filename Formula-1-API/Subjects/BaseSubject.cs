﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula_1_API.Hubs;
using Formula_1_API.Models;
using Formula_1_API.Subjects.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects
{
    public class BaseSubject<T> : ISubject<T> where T : IIdentifier
    {
        private readonly IHubContext<EntityHub> hubContext;

        public BaseSubject(IHubContext<EntityHub> _hubContext)
        {
            this.hubContext = _hubContext;
        }

        public async Task NotifyAdd(T entity)
        {
            await this.hubContext.Clients.All.SendAsync("add" + entity.GetType().Name, entity);
        }

        public async Task NotifyAddMany(List<T> entities)
        {
            await this.hubContext.Clients.All.SendAsync("add" + entities[0].GetType().Name, entities);
        }

        public async Task NotifyRemove(T entity)
        {
            await this.hubContext.Clients.All.SendAsync("remove" + entity.GetType().Name, entity.Id);
        }

        public async Task NotifyUpdate(T entity)
        {
            await this.hubContext.Clients.All.SendAsync("update" + entity.GetType().Name, entity);
        }
    }
}
