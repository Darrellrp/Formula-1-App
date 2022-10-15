using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public class LapTime : IIdentifier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public int RaceId { get; set; }
    public int DriverId { get; set; }
    public string Lap { get; set; }
    public int Position { get; set; } // in csv it is string
    public string Time { get; set; }
    public int Milliseconds { get; set; }


    public LapTime(int raceId, int driverId, string lap, int position, string time, int milliseconds)
    {
        this.RaceId = raceId;
        this.DriverId = driverId;
        this.Lap = lap;
        this.Position = position;
        this.Time = time;
        this.Milliseconds = milliseconds;
    }
}
