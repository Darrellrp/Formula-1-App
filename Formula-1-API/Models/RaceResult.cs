using System;
namespace Formula_1_API.Models
{
    public class RaceResult : Result
    {        
        public int DriverId { get; set; }
        public string Number { get; set; }
        public int Grid { get; set; }
        public string Position { get; set; }
        public string PositionText { get; set; }
        public int PositionOrder { get; set; }
        public int Laps { get; set; }
        public string Time { get; set; }
        public string Milliseconds { get; set; }
        public string FastestLap { get; set; }
        public string Rank { get; set; }
        public string FastestLapTime { get; set; }
        public string FastestLapSpeed { get; set; }
        public int StatusId { get; set; }

        public RaceResult(int? id, int raceId, int driverId, int constructorId,
            string number, int grid, string position, string positionText, int positionOrder, float points,
            int laps, string time, string milliseconds, string fastestLap, string rank,
            string fastestLapTime, string fastestLapSpeed, int statusId)
            : base(id, raceId, constructorId, points)
        {
            this.DriverId = driverId;
            this.Number = number;
            this.Grid = grid;
            this.Position = position;
            this.PositionText = positionText;
            this.PositionOrder = positionOrder;
            this.Laps = laps;
            this.Time = time;
            this.Milliseconds = milliseconds;
            this.FastestLap = fastestLap;
            this.Rank = rank;
            this.FastestLapTime = fastestLapTime;
            this.FastestLapSpeed = fastestLapSpeed;
            this.StatusId = statusId;
        }
    }
}
