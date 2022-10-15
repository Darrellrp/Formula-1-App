using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Formula_1_App.Models;
using _CsvHelper = CsvHelper;
using CsvHelper.Configuration;
using Formula_1_App.Utils.ClassMaps;

namespace Formula_1_App.Utils
{
    public class CsvReader
    {
        private readonly string basePath;

        public CsvReader(string basePath)
        {
            this.basePath = basePath;
        }

        public List<T> Read<T>(string filename)
        {
            var path = basePath + "/" + filename;

            using (var reader = new StreamReader(path))
            using (var csv = new _CsvHelper.CsvReader((_CsvHelper.IParser)reader))
            {
                //csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //csv.Configuration.Delimiter = ",";               

                var records = csv.GetRecords<T>().ToList();                

                return records.ToList();
            }
        }

        public List<T> Read<T, Map>(string filename) where Map : ClassMap
        {
            var path = basePath + "/" + filename;

            using (var reader = new StreamReader(path))
            using (var csv = new _CsvHelper.CsvReader((_CsvHelper.IParser)reader))
            {
                //csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //csv.Configuration.Delimiter = ",";
                //csv.Configuration.RegisterClassMap<Map>();

                var records = csv.GetRecords<T>().ToList();

                return records.ToList();
            }
        }
    }
}
