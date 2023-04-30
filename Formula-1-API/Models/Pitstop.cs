using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models;

public class PitStop : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public int? RaceId { get; set; }
    public int? DriverId { get; set; }
    public int? Stop { get; set; }
    public int? Lap { get; set; }
    public string Time { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Milliseconds { get; set; } = string.Empty;
}
