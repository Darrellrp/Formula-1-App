using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Utils.ClassMaps
{
    public class LapTimeMap : ClassMap<LapTime>
    {
        public LapTimeMap()
        {
            //AutoMap();
            Map(l => l.Id).Ignore();
        }
    }
}