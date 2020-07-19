using HtmlAgilityPack;
using System.Collections.Generic;

namespace FrameworkCore.Models
{
    public class HTMLTable
    {
        public Row Header { get; set; }
        public List<Row> Body { get; set; }

        public HTMLTable()
        {
            Body = new List<Row>();
        }
    }

    public class Row
    {
        public RowType Type { get; set; }
        public int Index { get; set; }
        public List<Cell> Cells { get; set; }

        public Row()
        {
            Cells = new List<Cell>();
        }
    }

    public class Cell
    {
        public (int Row, int Column) Index { get; set; }
        public HtmlNode Self { get; set; }
    }

    public enum RowType { Header, Body }
}
