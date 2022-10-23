using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Utils.ClassMaps
{
    public class RaceResultMap : ClassMap<RaceResult>
    {
        public RaceResultMap()
        {
            Map(r => r.Id).Name("Id");

            Map(r => r.RaceId).Name("RaceId");
            Map(r => r.DriverId).Name("DriverId");
            Map(r => r.ConstructorId).Name("ConstructorId");
            Map(r => r.Number).Name("Number");
            Map(r => r.Grid).Name("Grid");
            Map(r => r.Position).Name("Position");
            Map(r => r.PositionText).Name("PositionText");
            Map(r => r.PositionOrder).Name("PositionOrder");
            Map(r => r.Points).Name("Points");
            Map(r => r.Laps).Name("Laps");
            Map(r => r.PositionText).Name("PositionText");
            Map(r => r.PositionText).Name("PositionText");
            Map(r => r.PositionText).Name("PositionText");
            Map(r => r.PositionText).Name("PositionText");

            Map(r => r.Time).Name("Time").Optional();
            Map(r => r.Milliseconds).Name("Milliseconds").Optional();
            Map(r => r.FastestLap).Name("FastestLap").Optional();
            Map(r => r.Rank).Name("Rank").Optional();
            Map(r => r.FastestLapTime).Name("FastestLapTime").Optional();
            Map(r => r.FastestLapSpeed).Name("FastestLapSpeed").Optional();

            Map(r => r.StatusId).Name("StatusId");
        }
    }
}