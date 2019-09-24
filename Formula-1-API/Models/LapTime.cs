using System;
namespace Formula_1_API.Models
{
    public class LapTime
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public string Lap { get; set; }
        public int Position { get; set; } // in csv it is string
        public string Time { get; set; }
        public int Milliseconds { get; set; }


        public LapTime()
        {
        }
    }
}
