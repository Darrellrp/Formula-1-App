using System;
using CsvHelper.Configuration;
using Formula_1_API.Models;

namespace Formula_1_API.Datasources.ClassMaps
{
    public class PitStopMap : ClassMap<PitStop>
    {
        public PitStopMap()
        {
            Map(p => p.Id).Ignore();
            Map(p => p.RaceId).Name("RaceId");
            Map(p => p.DriverId).Name("DriverId");
            Map(p => p.Stop).Name("Stop");
            Map(p => p.Lap).Name("Lap");
            Map(p => p.Time).Name("Time");
            Map(p => p.Duration).Name("Duration");
            Map(p => p.Milliseconds).Name("Milliseconds");
        }
    }
}