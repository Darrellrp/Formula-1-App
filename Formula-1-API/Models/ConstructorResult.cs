using System;

namespace Formula_1_API.Models;

public class ConstructorResult : Result, IEntity
{
    public string Status { get; set; }
    public override string? CollectionKey { get; set; } = "constructorresults";

    public ConstructorResult(int? id, int raceId, int constructorId, float points, string status)
        : base(id, raceId, constructorId, points)
    {
        Status = status;
    }
}
