using ExcelGuiFun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils
{
    public class TypeSafeDataTableConverter
    {
        public static DataTable Convert(DataTable originalTable)
        {
            var dataTable = new DataTable();

            var typeGuesser = new ColumnTypeGuesser(originalTable);
            foreach (DataColumn column in originalTable.Columns)
            {
                var type = typeGuesser.GuessType(column).GetRealType();
                dataTable.Columns.Add(column.ColumnName, type);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var columnName in dataTable.Columns.Cast<DataColumn>().Select(col => col.ColumnName))
                {
                    //newRow[columnName] = row[columnName];
                }
            }
        }
    }
}
