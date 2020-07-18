using System.Linq;
using FrameworkCore.Models;
using HtmlAgilityPack;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
        //public static HtmlNode GetHTTPTableNode(this IWebElement element)
        //{
        //    // TODO: Implement GetHTTPTableNode via HtmlAgilityPack

        //    return null;
        //}

        //public static IList<HtmlNode> GetHTTPTableNodes()
        //{
        //    // TODO: Implement GetHTTPTableNodes via HtmlAgilityPack

        //    return null;
        //}

        ///* * * * *
        // * https://dotnetfiddle.net/UXCBxf
        // * https://stackoverflow.com/questions/13005098/parsing-html-table-in-c-sharp
        // * https://html-agility-pack.net/documentation
        // */

        public static HTMLTable ParseHTMLTableByXPath(string pageSource, string tableXPath)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(pageSource);

            HTMLTable HTMLTable = new HTMLTable();

            var sections = from table in document.DocumentNode.SelectNodes(tableXPath).Cast<HtmlNode>()
                           from section in table.SelectNodes("thead|tbody|tfoot").Cast<HtmlNode>()
                           select section;
            /*
            for (var section in sections)

                from row in section.SelectNodes("tr").Cast<HtmlNode>()
                from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                select new { Table = table.Id, CellText = cell.InnerText };

            foreach (var cell in query)
            {
                var foo = cell.Table;
                var bar = cell.CellText;
            }
                        */

            foreach (var section in sections)
            {
                var rows = from row in section.SelectNodes("tr").Cast<HtmlNode>()
                           select row;

                foreach (var row in rows)
                {
                    var cells = from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                                select cell;

                    var sdf = cells;
                }

                switch (section.Name)
                {
                    case "thead":
                        break;

                    case "tbody":
                        break;

                    case "tfoot":
                        break;
                }
            }

            return HTMLTable;
        }
    }
}
