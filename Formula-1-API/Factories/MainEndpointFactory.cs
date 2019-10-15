using System;
using System.Linq;
using Formula_1_API.Models;
using Formula_1_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_API.Factories
{
    public static class MainEndpointFactory
    {
        private static readonly string Name = "Formula 1 REST API - Main endpoint";
        private static readonly string Description = "This API contains data from 1950 all the way through the 2017 season, and consists of tables describing constructors, race drivers, lap times, pit stops and more.";
        private static readonly string Version = "1.0";
        private static readonly string Source = "https://www.kaggle.com/cjgdev/formula-1-race-data-19502017";


        public static MainEndpoint Create(ControllerBase controller)
        {
            var baseUrl = $"{controller.Request.Scheme}://{controller.Request.Host}{controller.Request.PathBase}/api";
            var uris = Helper.GetEndpoints();            

            var endpoints = EndpointFactory.Create(baseUrl, uris);


            var mainEndpoint = new MainEndpoint(Name, Description, Version, Source, endpoints);

            return mainEndpoint;
        }        
    }
}
