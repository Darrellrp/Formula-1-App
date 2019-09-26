using System;
using System.Collections.Generic;

namespace Formula_1_API.Models
{
    public class MainEndpoint
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Source { get; set; }
        public IEnumerable<Endpoint> Endpoints { get; set; }

        public MainEndpoint(string name, string description, string version, string source, IEnumerable<Endpoint> endpoints)
        {
            this.Name = name;
            this.Description = description;
            this.Version = version;
            this.Source = source;
            this.Endpoints = endpoints;
        }
    }
}
