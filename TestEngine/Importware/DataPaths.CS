using System;
using System.IO;

namespace TestEngine.Importware
{
    public static class DataPaths
    {
        private static readonly string BasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Importware");

        public static string UserCredentialsSpreadsheet = Path.Combine(BasePath, "UserCredentials", "CREDENTIALS.XLSX");

        public static string AvocadoPricesMetadata = Path.Combine(BasePath, "AvocadoPrices", "1-Metadata");
        public static string AvocadoPricesData = Path.Combine(BasePath, "AvocadoPrices", "2-Data");
        public static string AvocadoPricesNotebook = Path.Combine(BasePath, "AvocadoPrices", "3-DataVisualization");
    }
}