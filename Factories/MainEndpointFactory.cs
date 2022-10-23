using System;
using System.Linq;
using Formula_1_App.Factories.Interfaces;
using Formula_1_App.Models;
using Formula_1_App.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_App.Factories
{
    public class MainEndpointFactory
    {
        private readonly string _name = "Formula 1 REST API - Main endpoint";
        private readonly string _description = "This API contains data from 1950 all the way through the 2017 season, and consists of tables describing constructors, race drivers, lap times, pit stops and more.";
        private readonly string _version = "1.0";
        private readonly string _source = "https://www.kaggle.com/cjgdev/formula-1-race-data-19502017";
        private readonly string[] _excludedControllers = { "Base`1", "Main", "Configuration", "WeatherForecast" };

        private EndpointFactory _endpointFactory { get; set; }

        public MainEndpointFactory(EndpointFactory endpointFactory)
        {
            _endpointFactory = endpointFactory;
        }

        public MainEndpoint Create(ControllerBase controller)
        {
            var baseUrl = $"{controller.Request.Scheme}://{controller.Request.Host}{controller.Request.PathBase}/api";
            var endpoints = GetEndpoints(baseUrl);                        

            return new MainEndpoint(_name, _description, _version, _source, endpoints);
        }

        private IEnumerable<Models.Endpoint> GetEndpoints(string baseUrl)
        {
            var type = typeof(ControllerBase);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract);
            
            var uris = types.Select(c => c.Name)
                .Select(n => n.Replace("Controller", ""))
                .Where(n => !_excludedControllers.Contains(n));

            var endpoints = _endpointFactory.Create(baseUrl, uris);

            return endpoints;
        }
    }
}
