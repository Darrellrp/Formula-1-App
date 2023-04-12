using System;

namespace Formula_1_API.Models;

public class Endpoint
{
    public string Label { get; set; }
    public string WebUrl { get; set; }
    public string CollectionKey { get; set; }

    public Endpoint(string name, string webUrl, string apiUrl)
    {
        this.Label = name;
        this.WebUrl = webUrl;
        this.CollectionKey = apiUrl;
    }
}
