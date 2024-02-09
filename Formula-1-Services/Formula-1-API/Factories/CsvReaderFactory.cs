using System;
using Formula_1_API.Datasources;

namespace Formula_1_API.Factories
{
    public static class CsvReaderFactory
    {
        private const string BasePath = "Data/formula-1-race-data";

        public static CsvReader Create(string basePath = BasePath)
        {
            return new CsvReader(basePath);
        }
    }
}
