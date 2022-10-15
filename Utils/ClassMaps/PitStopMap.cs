using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Utils.ClassMaps
{
    public class PitStopMap : ClassMap<PitStop>
    {
        public PitStopMap()
        {
            //AutoMap();
            Map(p => p.Id).Ignore();
        }
    }
}