using System;
namespace Formula_1_API.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int Number { get; set; }
        public int Position { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }

        public Qualification()
        {
        }
    }
}
