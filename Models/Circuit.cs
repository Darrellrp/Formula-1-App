using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace Formula_1_App.Models;

public class Circuit : IIdentifier
{
    [Key]
    [BsonId]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Ref { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Country { get; set; }
    public string Lat { get; set; }
    public string Lng { get; set; }
    //public string Alt { get; set; }
    public string Url { get; set; }

    public Circuit(string _ref, string name, string location, string country, string lat, string lng, string url)
    {
        this.Ref = _ref;
        this.Name = name;
        this.Location = location;
        this.Country = country;
        this.Lat = lat;
        this.Lng = lng;
        this.Url = url;
    }
}
