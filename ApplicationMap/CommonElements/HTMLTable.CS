using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace ApplicationMap.CommonElements
{
    // TODO: Implement Support For Irregular Matrix Tables
    // TODO: Migrate To HTML Table Extensions

    public static class HTMLTable
    {
        private static List<TableDataCollection> _tableDataCollectionsList;
        private static string[,] _tableDataCollectionsArray;

        public static void ReadTableToList(IWebElement table)
        {
            _tableDataCollectionsList = new List<TableDataCollection>();

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
                        _tableDataCollectionsList.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = !string.IsNullOrEmpty(columns[columnIndex].Text) ? columns[columnIndex].Text : columnIndex.ToString(),
                            CellValue = cell.Text,
                            ControlElement = GetControl(cell)
                        });

                        columnIndex++;
                    }

                rowIndex++;
            }
        }

        public static string[,] ReadTableToArray(IWebElement table)
        {
            ReadOnlyCollection<IWebElement> columns = table.FindElements(By.TagName("th"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));

            _tableDataCollectionsArray = new string[rows.Count, columns.Count];

            int rowIndex = 0;

            foreach (IWebElement row in rows)
            {
                int columnIndex = 0;
                ReadOnlyCollection<IWebElement> columnData = row.FindElements(By.TagName("td"));

                if (columnData.Count != 0)
                    foreach (IWebElement cell in columnData)
                    {
                        _tableDataCollectionsArray[rowIndex, columnIndex] = cell.Text;

                        columnIndex++;
                    }

                rowIndex++;
            }

            return _tableDataCollectionsArray;
        }

        private static ControlElement GetControl(ISearchContext columnValue)
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

        public static void PerformActionOnCell(string referenceColumnName, string referenceCellValue, string controlColumnIndex, string actionToPerform = null)
        {
            foreach (int rowNumber in GetRowNumber(referenceColumnName, referenceCellValue))
            {
                ControlElement controlElement = (from cell in _tableDataCollectionsList
                    where cell.ColumnName == controlColumnIndex && cell.RowNumber == rowNumber
                    select cell.ControlElement).SingleOrDefault();

                if (actionToPerform != null && controlElement != null)
                {
                    if (controlElement.ControlType == "hyperlink")
                    {
                        IWebElement returnedControl = (from c in controlElement.ElementCollection
                            where c.Text == actionToPerform
                            select c).SingleOrDefault();

                        returnedControl?.Click();
                    }

                    if (controlElement.ControlType == "input")
                    {
                        IWebElement returnedControl = (from c in controlElement.ElementCollection
                            where c.GetAttribute("value") == actionToPerform
                            select c).SingleOrDefault();

                        returnedControl?.Click();
                    }
                }

                else { controlElement?.ElementCollection?.First().Click(); }
            }
        }

        public static string GetCellValue(string[,] tableAsTwoDimensionalArray, int row, int column) { return tableAsTwoDimensionalArray[row, column]; }

        public static bool AssertValuePresence(string[,] tableAsTwoDimensionalArray, string value)
        {
            for (int i = 0; i < tableAsTwoDimensionalArray.GetLength(0); i++)
            for (int j = 0; j < tableAsTwoDimensionalArray.GetLength(1); j++)
                if (tableAsTwoDimensionalArray[i, j] == value)
                    return true;

            return false;
        }

        private static IEnumerable GetRowNumber(string columnName, string cellValue)
        {
            foreach (TableDataCollection table in _tableDataCollectionsList)
                if (table.ColumnName == columnName && table.CellValue == cellValue)
                    yield return table.RowNumber;
        }

        private class TableDataCollection
        {
            public int RowNumber { get; set; }
            public string ColumnName { get; set; }
            public string CellValue { get; set; }
            public ControlElement ControlElement { get; set; }
        }

        private class ControlElement
        {
            public IEnumerable<IWebElement> ElementCollection { get; set; }
            public string ControlType { get; set; }
        }
    }
}
