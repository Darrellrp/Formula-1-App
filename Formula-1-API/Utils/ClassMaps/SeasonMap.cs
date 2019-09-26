using System;
using CsvHelper.Configuration;
using Formula_1_API.Models;

namespace Formula_1_API.Utils.ClassMaps
{
    public class SeasonMap : ClassMap<Season>
    {
        public SeasonMap()
        {
            AutoMap();
            Map(s => s.Id).Ignore();
        }
    }
}