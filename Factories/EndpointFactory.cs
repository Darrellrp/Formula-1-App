using System;
using System.Collections.Generic;
using System.Linq;
using Formula_1_App.Models;
using Formula_1_App.Utils;
using Microsoft.AspNetCore.Mvc;
using Endpoint = Formula_1_App.Models.Endpoint;

namespace Formula_1_App.Factories
{
    public static class EndpointFactory
    {
        public static IEnumerable<Endpoint> Create(string baseUrl, IEnumerable<string> endpoints)
        {            
            return endpoints.Select(e => new Endpoint(e, baseUrl + "/" + e.ToLower()));
        }

    }
    
}
