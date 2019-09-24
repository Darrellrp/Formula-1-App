using System;
namespace Formula_1_API.Models
{
    public class ConstructorResult : Result
    {
        public string Status { get; set; }

        public ConstructorResult(int id, int raceId, int constructorId, int points, string status)
            : base(id, raceId, constructorId, points)
        {
            this.Status = status;
        }
    }
}
