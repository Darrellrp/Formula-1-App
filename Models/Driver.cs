using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public class Driver : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public string Ref { get; set; } = string.Empty;
    public int? Number { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Forename { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Dob { get; set; } = string.Empty; // Date of Birth
    public string Nationality { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
