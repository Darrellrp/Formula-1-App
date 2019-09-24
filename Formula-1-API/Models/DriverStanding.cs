using System;
namespace Formula_1_API.Models
{
    public class DriverStanding : Standing
    {
        public int Id { get; set; }
        public int DriverId { get; set; }

        public DriverStanding() {}

        public DriverStanding(int id, int driverId, int raceId, int points, int position, string positionText, int wins)
            : base(raceId, points, position, positionText, wins)
        {
            this.Id = id;
            this.DriverId = driverId;
        }
    }
}
