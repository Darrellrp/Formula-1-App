using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models;

public class Qualification : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public int RaceId { get; set; }
    public int DriverId { get; set; }
    public int ConstructorId { get; set; }
    public int Number { get; set; }
    public int Position { get; set; }
    public string Q1 { get; set; } = string.Empty;
    public string Q2 { get; set; } = string.Empty;
    public string Q3 { get; set; } = string.Empty;
    public override string? CollectionKey { get; set; } = "qualifications";
}
