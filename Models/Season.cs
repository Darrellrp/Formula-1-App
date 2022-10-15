using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public class Season : IIdentifier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public int Year { get; set; }
    public string Url { get; set; } = string.Empty;
}
