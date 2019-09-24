using System;
namespace Formula_1_API.Models
{
    public class Standing
    {
        public int RaceId { get; set; }
        public int Points { get; set; }
        public int Position { get; set; }
        public string PositionText { get; set; }
        public int Wins { get; set; }

        public Standing() { }

        public Standing(int raceId, int points, int position, string positionText, int wins)
        {
            this.RaceId = raceId;
            this.Points = points;
            this.Position = position;
            this.PositionText = positionText;
            this.Wins = wins;
        }
    }
}
