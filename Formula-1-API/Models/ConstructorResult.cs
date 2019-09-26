using System;
namespace Formula_1_API.Models
{
    public class ConstructorResult : Result, IIdentifier
    {
        public string Status { get; set; }

        public ConstructorResult(int? id, int raceId, int constructorId, float points, string status)
            : base(id, raceId, constructorId, points)
        {
            this.Status = status;
        }
    }
}
