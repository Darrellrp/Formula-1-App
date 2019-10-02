using System;
using System.Threading.Tasks;
using Formula_1_API.Hubs;
using Formula_1_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Subjects
{
    public class CircuitSubject : ISubject<Circuit>
    {
        private readonly BaseSubject<Circuit> baseSubject;

        public CircuitSubject(BaseSubject<Circuit> _baseSubject)
        {
            this.baseSubject = _baseSubject;
        }

        public async Task Update(Circuit entity)
        {
            await this.baseSubject.Update(entity);
        }
    }
}
