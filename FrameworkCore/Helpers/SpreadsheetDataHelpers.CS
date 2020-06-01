using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace FrameworkCore.Helpers
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
    }

    public static class SpreadsheetDataHelpers
    {
        private static readonly List<Cell> DataCollection = new List<Cell>();

        private static DataTable ExcelToDataTable(string fileName, string sheetName = "DATASET")
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
                    DataTable resultTable = table[sheetName];

                    return resultTable;
                }
            }
        }

        public static void PopulateDataCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            for (int col = 0; col < table.Columns.Count; col++)
            {
                Cell dataTable = new Cell
                {
                    RowNumber = row,
                    ColumnName = table.Columns[col].ColumnName,
                    Value = table.Rows[row - 1][col].ToString()
                };

                DataCollection.Add(dataTable);
            }
        }

        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static string ReadCellData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in DataCollection
                    where colData.ColumnName == columnName && colData.RowNumber == rowNumber
                    select colData.Value).SingleOrDefault();

                return data;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: {exception.Message}");
                return null;
            }
        }
    }
}
