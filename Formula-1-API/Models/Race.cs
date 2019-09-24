using System;
namespace Formula_1_API.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Round { get; set; }
        public int CircuitId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Url { get; set; }

        public Race()
        {
        }
    }
}
