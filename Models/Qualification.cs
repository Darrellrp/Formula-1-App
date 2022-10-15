using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public class Qualification : IIdentifier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public int RaceId { get; set; }
    public int DriverId { get; set; }
    public int ConstructorId { get; set; }
    public int Number { get; set; }
    public int Position { get; set; }
    public string Q1 { get; set; } = string.Empty;
    public string Q2 { get; set; } = string.Empty;
    public string Q3 { get; set; } = string.Empty;
}
