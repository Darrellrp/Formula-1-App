﻿using System;
using System.Collections.Generic;
using System.Linq;
using Formula_1_API.Models;
using Formula_1_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_API.Factories
{
    public static class EndpointFactory
    {
        public static IEnumerable<Endpoint> Create(string baseUrl, IEnumerable<string> endpoints)
        {            
            return endpoints.Select(e => new Endpoint(e, baseUrl + "/" + e.ToLower()));
        }

    }
    
}
