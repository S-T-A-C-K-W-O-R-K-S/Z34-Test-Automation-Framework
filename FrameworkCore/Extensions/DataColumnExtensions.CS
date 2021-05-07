using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FrameworkCore.Extensions
{
	public static class DataColumnExtensions
	{
		public static IEnumerable<TCellValue> GetColumnValues<TCellValue>(this DataColumn column)
			=> column.Table.Select().Select(row => (TCellValue)Convert.ChangeType(row[column], typeof(TCellValue)));
	}
}