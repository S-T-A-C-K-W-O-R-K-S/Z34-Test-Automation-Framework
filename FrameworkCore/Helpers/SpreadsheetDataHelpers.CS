using System.Data;
using System.IO;
using ExcelDataReader;

namespace FrameworkCore.Helpers
{
    public class SpreadsheetDataHelpers
    {
        public class Spreadsheet
        {
            public DataSet DataSet { get; set; }

            public Spreadsheet(string filePath, bool hasHeaders = true)
            {
                DataSet = GetData(filePath, hasHeaders);
            }

            private DataSet GetData(string filePath, bool hasHeaders)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        return reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() { UseHeaderRow = hasHeaders }
                        });
                    }
                }
            }

            public DataTable GetSheetByName(string tableName)
            {
                foreach (DataTable table in DataSet.Tables)
                {
                    if (table.TableName == tableName)
                        return table;
                };

                return null;
            }
        }
    }
}
