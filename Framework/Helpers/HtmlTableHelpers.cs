using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public class HtmlTableHelpers
    {
        private static List<TableDataCollection> _tableDataCollections;

        public static void ReadTable(IWebElement table)
        {
            _tableDataCollections = new List<TableDataCollection>();

            ReadOnlyCollection<IWebElement> columns = table.FindElements(By.TagName("th"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));

            int rowIndex = 0;

            foreach (IWebElement row in rows)
            {
                int columnIndex = 0;
                ReadOnlyCollection<IWebElement> columnData = row.FindElements(By.TagName("td"));

                if (columnData.Count != 0)
                    foreach (IWebElement cell in columnData)
                    {
                        _tableDataCollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[columnIndex].Text != "" ? columns[columnIndex].Text : columnIndex.ToString(),
                            ColumnValue = cell.Text,
                            ControlElement = GetControl(cell)
                        });

                        columnIndex++;
                    }

                rowIndex++;
            }
        }

        private static ControlElement GetControl(IWebElement columnValue)
        {
            ControlElement controlElement = null;

            if (columnValue.FindElements(By.TagName("a")).Count > 0)
                controlElement = new ControlElement
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperlink"
                };

            if (columnValue.FindElements(By.TagName("input")).Count > 0)
                controlElement = new ControlElement
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };

            return controlElement;
        }

        public static void PerformActionOnCell(string columnIndex, string referenceColumnName, string referenceColumnValue, string controlElement = null)
        {
            foreach (int rowNumber in GetRowNumber(referenceColumnName, referenceColumnValue))
            {
                ControlElement cell = (from e in _tableDataCollections
                    where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                    select e.ControlElement).SingleOrDefault();

                if (controlElement != null && cell != null)
                {
                    if (cell.ControlType == "hyperlink")
                    {
                        IWebElement returnedControl = (from c in cell.ElementCollection
                            where c.Text == controlElement
                            select c).SingleOrDefault();

                        returnedControl?.Click();
                    }

                    if (cell.ControlType == "input")
                    {
                        IWebElement returnedControl = (from c in cell.ElementCollection
                            where c.GetAttribute("value") == controlElement
                            select c).SingleOrDefault();

                        returnedControl?.Click();
                    }
                }

                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetRowNumber(string columnName, string columnValue)
        {
            foreach (TableDataCollection table in _tableDataCollections)
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
        }

        public class TableDataCollection
        {
            public int RowNumber { get; set; }
            public string ColumnName { get; set; }
            public string ColumnValue { get; set; }
            public ControlElement ControlElement { get; set; }
        }

        public class ControlElement
        {
            public IEnumerable<IWebElement> ElementCollection { get; set; }
            public string ControlType { get; set; }
        }
    }
}