using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Utils.ClassMaps
{
    public class SeasonMap : ClassMap<Season>
    {
        public SeasonMap()
        {
            //AutoMap();
            Map(s => s.Id).Ignore();
        }
    }
}