using System;

namespace Formula_1_App.Models;

public class Endpoint
{
    public string Name { get; set; }
    public string Url { get; set; }

    public Endpoint(string name, string url)
    {
        this.Name = name;
        this.Url = url;
    }
}
