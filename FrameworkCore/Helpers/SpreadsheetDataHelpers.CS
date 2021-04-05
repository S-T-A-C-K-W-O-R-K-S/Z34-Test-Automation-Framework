using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;

namespace FrameworkCore.Helpers
{
    public class SpreadsheetDataHelpers
    {
        public class Spreadsheet
        {
            public Spreadsheet(string filePath, bool hasHeaders = true)
            {
                DataSet = GetData(filePath, hasHeaders);
            }

            public DataSet DataSet { get; set; }

            private DataSet GetData(string filePath, bool hasHeaders)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                using var reader = ExcelReaderFactory.CreateReader(stream);
                return reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = tableReader => new ExcelDataTableConfiguration {UseHeaderRow = hasHeaders}
                });
            }

            public DataTable GetSheetByName(string tableName)
            {
                return DataSet.Tables.Cast<DataTable>().FirstOrDefault(table => table.TableName.Equals(tableName));
            }
        }
    }
}