using ExcelGuiFun.Models;
using ExcelGuiFun.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils
{
    public class DbBuilder
    {
        private static string _tableName;

        public static DataTable Convert(DataTable originalTable)
        {
            CreateTable(originalTable);

            // Insert Rows
            foreach (DataRow row in dataTable.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var item in dataTable.Columns.Cast<DataColumn>().Select(col => new { col.ColumnName, col.DataType }))
                {
                    newRow[item.ColumnName] = DataTypeExtensions.GetDynamicValue(item.DataType, row[item.ColumnName]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private static void CreateTable(DataTable originalTable)
        {
            var query = $"CREATE TABLE {_tableName}";

            var typeGuesser = new ColumnTypeGuesser(originalTable);

            var columns = string.Join(
                ",",
                originalTable.Columns.Cast<DataColumn>().Select(col => $"{col.ColumnName} {col.DataType.GetSqlType()}")
            );
                

            var finalQuery = $"{query} ({columns})";
        }
    }
}
