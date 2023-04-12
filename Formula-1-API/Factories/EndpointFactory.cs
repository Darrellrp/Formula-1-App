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
                Regex.Replace(endpoint, "(\\B[A-Z])", " $1"),
                baseUrl + "/" + endpoint.ToLower(),
                endpoint.ToLower()
            ));
        }
    }
}
