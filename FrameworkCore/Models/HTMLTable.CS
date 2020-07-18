using System.Collections.Generic;

namespace FrameworkCore.Models
{
    public class HTMLTable
    {
        public Row Header { get; set; }
        public List<Row> Body { get; set; }
        public Row Footer { get; set; }
    }

    public class Row
    {
        public enum Type { Header, Body, Footer }
        public int Index { get; set; }
        public List<Cell> Cells { get; set; }
    }

    public class Cell
    {
        public (int Row, int Column) Index { get; set; }
        public string Text { get; set; }
    }
}
