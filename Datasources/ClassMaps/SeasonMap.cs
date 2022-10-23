using System;
using CsvHelper.Configuration;
using Formula_1_App.Models;

namespace Formula_1_App.Datasources.ClassMaps
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