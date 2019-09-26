using System;
using System.Linq;
using Formula_1_API.Models;
using Formula_1_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_API.Factories
{
    public static class MainEndpointFactory
    {
        public static MainEndpoint Create(ControllerBase controller)
        {
            var baseUrl = $"{controller.Request.Scheme}://{controller.Request.Host}{controller.Request.PathBase}/api";
            var endpoints = Helper.GetEndpoints();            

            var _endpoints = EndpointFactory.Create(baseUrl, endpoints);            
            

            var mainEndpoint = new MainEndpoint() {
                Name = "Formula 1 REST API - Main endpoint",
                Description = "This api contains data from 1950 all the way through the 2017 season, " +
                "and consists of tables describing constructors, race drivers, lap times, pit stops and more.",
                Version = "1.0",
                Endpoints = _endpoints
            };

            return mainEndpoint;
        }        
    }
}
