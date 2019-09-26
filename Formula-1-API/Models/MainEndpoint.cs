using System;
using System.Collections.Generic;

namespace Formula_1_API.Models
{
    public class MainEndpoint
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public IEnumerable<Endpoint> Endpoints { get; set; }

        public MainEndpoint()
        {
        }
    }
}
