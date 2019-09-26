using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models
{
    public abstract class Result : IIdentifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public float Points { get; set; }

        protected Result(int? id, int raceId, int constructorId, float points)
        {
            this.Id = id;
            this.RaceId = raceId;
            this.ConstructorId = constructorId;
            this.Points = points;
        }
    }
}
