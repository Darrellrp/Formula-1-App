using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace Formula_1_API.Models;

public class Circuit : Entity
{
    [Key]
    [BsonId]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public string Ref { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Lat { get; set; } = string.Empty;
    public string Lng { get; set; } = string.Empty;
    //public string Alt { get; set; }
    public string Url { get; set; } = string.Empty;
    public override string? CollectionKey { get; set; } = "circuits";
}
