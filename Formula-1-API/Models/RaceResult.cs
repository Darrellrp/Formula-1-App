using System;
namespace Formula_1_API.Models
{
    public class RaceResult : Result
    {        
        public int DriverId { get; set; }
        public int Number { get; set; }
        public int Grid { get; set; }
        public int Position { get; set; }
        public string PositionText { get; set; }
        public int PositionOrder { get; set; }
        public int Laps { get; set; }
        public string Time { get; set; }
        public int Milliseconds { get; set; }
        public int FastestLap { get; set; }
        public int Rank { get; set; }
        public string FastestLapTime { get; set; }
        public string FastestLapSpeed { get; set; }
        public int StatusId { get; set; }

        public RaceResult(int id, int raceId, int driverId, int constructorId,
            int number, int grid, int position, string positionText, int positionOrder, int points,
            int laps, string time, int milliseconds, int fastestLap, int rank,
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
