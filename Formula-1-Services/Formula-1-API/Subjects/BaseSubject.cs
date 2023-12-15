using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formula_1_API.Hubs;
using Formula_1_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects
{
    public class BaseSubject<T> : ISubject<T> where T : IEntity
    {
        private readonly IHubContext<EntityHub> _hubContext;

        public BaseSubject(IHubContext<EntityHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyAdd(T entity)
        {
            await _hubContext.Clients.All.SendAsync("add" + entity.GetType().Name, entity);
        }

        public async Task NotifyAddMany(IEnumerable<T> entities)
        {
            await _hubContext.Clients.All.SendAsync("add" + entities.ElementAt(0).GetType().Name, entities);
        }

        public async Task NotifyRemove(T entity)
        {
            await _hubContext.Clients.All.SendAsync("remove" + entity.GetType().Name, entity.Id);
        }

        public async Task NotifyUpdate(T entity)
        {
            await _hubContext.Clients.All.SendAsync("update" + entity.GetType().Name, entity);
        }
    }
}
