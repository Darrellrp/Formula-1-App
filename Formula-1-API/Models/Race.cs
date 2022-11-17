using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models;

public class Race : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public string Year { get; set; } = string.Empty;
    public string Round { get; set; } = string.Empty;
    public int CircuitId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
