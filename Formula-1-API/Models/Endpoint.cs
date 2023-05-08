using System;

namespace Formula_1_API.Models;

public class Endpoint
{
    public string CollectionLabel { get; set; }
    public string CollectionKey { get; set; }
    public string WebUrl { get; set; }
    public string ApiUrl { get; set; }

    public Endpoint(string label, string key, string webUrl, string apiUrl)
    {
        this.CollectionLabel = label;
        this.CollectionKey = key;
        this.WebUrl = webUrl;
        this.ApiUrl = apiUrl;
    }
}
