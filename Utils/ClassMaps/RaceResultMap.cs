using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Utils.ClassMaps
{
    public class RaceResultMap : ClassMap<RaceResult>
    {
        public RaceResultMap()
        {
            //AutoMap();
            Map(r => r.Position).Optional();
            Map(r => r.Time).Optional();
            Map(r => r.Milliseconds).Optional();
            Map(r => r.FastestLap).Optional();
            Map(r => r.Rank).Optional();
            Map(r => r.FastestLapTime).Optional();
            Map(r => r.FastestLapSpeed).Optional();
        }
    }
}