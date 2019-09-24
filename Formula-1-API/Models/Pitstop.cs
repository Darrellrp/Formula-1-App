using System;
namespace Formula_1_API.Models
{
    public class Pitstop
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int Stop { get; set; }
        public int Lap { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        //public string Milliseconds { get; set; }
        
        public Pitstop() { }

        
    }
}
