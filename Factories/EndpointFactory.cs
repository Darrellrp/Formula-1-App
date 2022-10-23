using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Formula_1_App.Factories.Interfaces;

namespace Formula_1_App.Factories
{
    public class EndpointFactory : IFactory<Models.Endpoint>
    {
        public IEnumerable<Models.Endpoint> Create(string baseUrl, IEnumerable<string> endpoints)
        {            
            return endpoints.Select(e => new Models.Endpoint(
                Regex.Replace(e, "(\\B[A-Z])", " $1"),
                baseUrl + "/" + e.ToLower()
            ));
        }
    }
    
}
