using System;
using System.Linq;
using Formula_1_API.Factories.Interfaces;
using Formula_1_API.Models;
using Formula_1_API.Datasources;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Controllers;

namespace Formula_1_API.Factories
{
    public class MainEndpointFactory
    {
        private const string _name = "Formula 1 REST API - Main endpoint";
        private const string _description = "This API contains data from 1950 all the way through the 2017 season, and consists of tables describing constructors, race drivers, lap times, pit stops and more.";
        private const string _version = "1.0";
        private const string _source = "https://www.kaggle.com/cjgdev/formula-1-race-data-19502017";
        private readonly Type[] _excludedControllers = {
            typeof(BaseController<>),
            typeof(MainController),
            typeof(ConfigurationController)
        };

        private const string _hostConfigurationKey = "HostDomain";

        private EndpointFactory _endpointFactory { get; set; }
        private IConfiguration _configuration { get; set; }

        public MainEndpointFactory(EndpointFactory endpointFactory, IConfiguration configuration)
        {
            _endpointFactory = endpointFactory;
            _configuration = configuration;
        }

        public MainEndpoint Create(ControllerBase controller)
        {
            var configuredHost = _configuration.GetValue<string>(_hostConfigurationKey);
            var host = !string.IsNullOrWhiteSpace(configuredHost) ? configuredHost : controller.Request.Host.ToString();
            var baseUrl = $"{controller.Request.Scheme}://{host}{controller.Request.PathBase}";
            var endpoints = GetEndpoints(baseUrl);

            return new MainEndpoint(_name, _description, _version, _source, endpoints);
        }

        private IEnumerable<Models.Endpoint> GetEndpoints(string baseUrl)
        {
            var type = typeof(ControllerBase);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    !_excludedControllers.Contains(t));

            var uris = types.Select(c => c.Name.Replace("Controller", string.Empty));

            return _endpointFactory.Create(baseUrl, uris);
        }
    }
}
