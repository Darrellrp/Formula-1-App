using System;

namespace Formula_1_App.Models;

public class ConstructorResult : Result, IEntity
{
    public string Status { get; set; }

    public ConstructorResult(int? id, int raceId, int constructorId, float points, string status)
        : base(id, raceId, constructorId, points)
    {
        Status = status;
    }
}
