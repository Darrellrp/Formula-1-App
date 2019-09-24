using System;
namespace Formula_1_API.Models
{
    public class ConstructorStanding : Standing
    {
        public int Id { get; set; }
        public int ConstructorId { get; set; }

        public ConstructorStanding(int id, int constructorId, int raceId, int points, int position, string positionText, int wins)
            : base(raceId, points, position, positionText, wins)
        {
            this.Id = id;
            this.ConstructorId = constructorId;
        }
    }
}
