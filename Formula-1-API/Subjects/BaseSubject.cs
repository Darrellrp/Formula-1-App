using System;
using System.Threading.Tasks;
using Formula_1_API.Hubs;
using Formula_1_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects
{
    public class BaseSubject<T> : ISubject<T> where T :IIdentifier
    {
        private readonly IHubContext<EntityHub> hubContext;

        public BaseSubject(IHubContext<EntityHub> _hubContext)
        {
            this.hubContext = _hubContext;
        }

        public async Task Update(T entity)
        {
            await this.hubContext.Clients.All.SendAsync("update" + entity.GetType().Name, entity);
        }
    }
}
