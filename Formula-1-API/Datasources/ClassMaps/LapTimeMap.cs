using System;
using CsvHelper.Configuration;
using Formula_1_API.Models;

namespace Formula_1_API.Datasources.ClassMaps
{
    public class LapTimeMap : ClassMap<LapTime>
    {
        public LapTimeMap()
        {
            Map(l => l.Id).Ignore();
            Map(l => l.RaceId).Name("raceId");
            Map(l => l.DriverId).Name("driverId");
            Map(l => l.Lap).Name("lap");
            Map(l => l.Position).Name("position");
            Map(l => l.Time).Name("time");
            Map(l => l.Milliseconds).Name("milliseconds");
        }
    }
}