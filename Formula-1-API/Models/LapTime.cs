using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models;

public class LapTime : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public int RaceId { get; set; }
    public int DriverId { get; set; }
    public string Lap { get; set; } = string.Empty;
    public int Position { get; set; }
    public string Time { get; set; } = string.Empty;
    public int Milliseconds { get; set; }
    public override string? CollectionKey { get; set; } = "laptimes";
}
