using System;

namespace Formula_1_App.Models;

public class RaceResult : Result
{
    public override int? Id { get; set; }
    public int DriverId { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Grid { get; set; }
    public string Position { get; set; } = string.Empty;
    public string PositionText { get; set; } = string.Empty;
    public int PositionOrder { get; set; }
    public int Laps { get; set; }
    public string Time { get; set; } = string.Empty;
    public string Milliseconds { get; set; } = string.Empty;
    public string FastestLap { get; set; } = string.Empty;
    public string Rank { get; set; } = string.Empty;
    public string FastestLapTime { get; set; } = string.Empty;
    public string FastestLapSpeed { get; set; } = string.Empty;
    public int StatusId { get; set; }

    public RaceResult() : base(int.MinValue, int.MinValue, int.MinValue, float.MinValue) { }

    public RaceResult(int? id, int raceId = int.MinValue, int constructorId = int.MinValue, float points = float.MinValue) : base(id, raceId, constructorId, points) { }

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
