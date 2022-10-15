using System;

namespace Formula_1_App.Models;

public class ResultStatus : IIdentifier
{
    public int? Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
