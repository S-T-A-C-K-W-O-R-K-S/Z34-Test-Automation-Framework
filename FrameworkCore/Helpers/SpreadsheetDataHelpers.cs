using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace FrameworkCore.Helpers
{
    public static class SpreadsheetDataHelpers
    {
        private static readonly List<DataCollection> DataCollection = new List<DataCollection>();

        private static DataTable ExcelToDataTable(string fileName)
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = data => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table["DATASET"];

                    return resultTable;
                }
            }
        }

        public static void PopulateInMemoryCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            for (int col = 0; col < table.Columns.Count; col++)
            {
                DataCollection dataTable = new DataCollection
                {
                    RowNumber = row,
                    ColumnName = table.Columns[col].ColumnName,
                    ColumnValue = table.Rows[row - 1][col].ToString()
                };

                DataCollection.Add(dataTable);
            }
        }

        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in DataCollection
                    where colData.ColumnName == columnName && colData.RowNumber == rowNumber
                    select colData.ColumnValue).SingleOrDefault();

                return data;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: {exception.Message}");
                return null;
            }
        }
    }

    public class DataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}