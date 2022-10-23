using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula_1_App.Hubs;
using Formula_1_App.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_App.Subjects
{
    public class BaseSubject<T> : ISubject<T> where T : IEntity
    {
        private readonly IHubContext<EntityHub> _hubContext;

        public BaseSubject(IHubContext<EntityHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        public async Task NotifyAdd(T entity)
        {
            await this._hubContext.Clients.All.SendAsync("add" + entity.GetType().Name, entity);
        }

        public async Task NotifyAddMany(List<T> entities)
        {
            await this._hubContext.Clients.All.SendAsync("add" + entities[0].GetType().Name, entities);
        }

        public async Task NotifyRemove(T entity)
        {
            await this._hubContext.Clients.All.SendAsync("remove" + entity.GetType().Name, entity.Id);
        }

        public async Task NotifyUpdate(T entity)
        {
            await this._hubContext.Clients.All.SendAsync("update" + entity.GetType().Name, entity);
        }
    }
}
