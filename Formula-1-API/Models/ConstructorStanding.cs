using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models
{
    public class ConstructorStanding : Standing, IIdentifier
    {     
        public int ConstructorId { get; set; }

        public ConstructorStanding(int? id, int constructorId, int raceId, float points, int position, string positionText, int wins)
            : base(id, raceId, points, position, positionText, wins)
        {
            this.ConstructorId = constructorId;
        }
    }
}
