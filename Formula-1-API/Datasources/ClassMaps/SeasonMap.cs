using System;
using CsvHelper.Configuration;
using Formula_1_API.Models;

namespace Formula_1_API.Datasources.ClassMaps
{
    public class SeasonMap : ClassMap<Season>
    {
        public SeasonMap()
        {
            Map(s => s.Id).Ignore();
            Map(s => s.Url).Name("Url");
            Map(s => s.Year).Name("Year");
        }
    }
}