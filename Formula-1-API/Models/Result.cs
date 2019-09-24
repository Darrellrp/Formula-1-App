using System;
namespace Formula_1_API.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public int Points { get; set; }
        //public string Status { get; set; }

        public Result(int id, int raceId, int constructorId, int points)
        {
            this.Id = id;
            this.RaceId = raceId;
            this.ConstructorId = constructorId;
            this.Points = points;
            //this.Status = status;
        }
    }
}
