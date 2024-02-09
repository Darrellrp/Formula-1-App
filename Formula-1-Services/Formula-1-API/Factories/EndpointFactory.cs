using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Formula_1_API.Factories.Interfaces;

namespace Formula_1_API.Factories
{
    public class EndpointFactory : IFactory<Models.Endpoint>
    {
        public IEnumerable<Models.Endpoint> Create(string baseUrl, IEnumerable<string> endpoints)
        {
            return endpoints.Select(endpoint => new Models.Endpoint(
                label: endpoint.AddSpacesToPascalCase(),
                key: endpoint.ToLower(),
                webUrl: Path.Combine(baseUrl, endpoint.ToLower()),
                apiUrl: Path.Combine(baseUrl, "api", endpoint.ToLower())
            ));
        }
    }
}
