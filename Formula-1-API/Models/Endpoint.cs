using System;

namespace Formula_1_API.Models;

public class Endpoint
{
    public string Label { get; set; }
    public string Key { get; set; }
    public string WebUrl { get; set; }
    public string ApiUrl { get; set; }

    public Endpoint(string label, string key, string webUrl, string apiUrl)
    {
        this.Label = label;
        this.Key = key;
        this.WebUrl = webUrl;
        this.ApiUrl = apiUrl;
    }
}
