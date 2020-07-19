using System;
using System.Linq;
using FrameworkCore.Helpers;
using FrameworkCore.Models;
using HtmlAgilityPack;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
        public static HTMLTable ParseHTMLTableByXPath(string pageSource, string tableXPath)
        {
            // Generate Virtual Document From Web Page Source
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(pageSource);

            // Instantiate A New HTMLTable Object
            HTMLTable HTMLTable = new HTMLTable();

            // Get The List Of Table Sections (Footer Not Included In This Implementation)
            var sections = from table in document.DocumentNode.SelectNodes(tableXPath).Cast<HtmlNode>()
                           from section in table.SelectNodes("thead|tbody").Cast<HtmlNode>()
                           select section;

            foreach (var section in sections)
            {
                // Get The List Of Rows In Each Table Section
                var rows = from row in section.SelectNodes("tr").Cast<HtmlNode>()
                           select row;

                for (var rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
                {
                    var currentRow = rows.ToList()[rowIndex];

                    // Instantiate A New 1-Indexed Row Object (The First Row Will Have Index 1, For Consistency With Dataset Dimensions)
                    Row row = new Row() { Index = rowIndex + 1 };

                    // Get The List Of Cells In Each Section Row
                    var cells = from cell in currentRow.SelectNodes("th|td").Cast<HtmlNode>()
                                select cell;

                    // Instantiate All Cells And Add Them To The Current Row
                    for (var columnIndex = 0; columnIndex < cells.Count(); columnIndex++)
                    {
                        var currentCell = cells.ToList()[columnIndex];

                        // Cells Are 1-Indexed (The First Cell Will Have Index (1, 1), For Consistency With Dataset Dimensions)
                        row.Cells.Add(new Cell() { Index = (rowIndex + 1, columnIndex + 1), Self = currentCell });
                    }

                    // Set The Row Type And Append The Row To The Correct Table Section
                    switch (section.Name)
                    {
                        case "thead":
                            row.Type = RowType.Header;
                            HTMLTable.Header = row;
                            break;

                        case "tbody":
                            row.Type = RowType.Body;
                            HTMLTable.Body.Add(row);
                            break;

                        default:
                            LogHelpers.WriteToLog($"[ERROR] :: Invalid Table Section Name: {section.Name}");
                            throw new ArgumentOutOfRangeException(nameof(section.Name), section.Name, $"Invalid Table Section Name: {section.Name}");
                    }
                }
            }

            return HTMLTable;
        }
    }
}
