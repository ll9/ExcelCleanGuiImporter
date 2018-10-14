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
        private string _tableName;
        private ISqliteService sqliteService;

        public DbBuilder(string tableName, ISqliteService sqliteService)
        {
            _tableName = tableName;
            this.sqliteService = sqliteService;
        }

        //public  DataTable Convert(DataTable originalTable)
        //{
        //    CreateTable(originalTable);

        //    // Insert Rows
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        var newRow = dataTable.NewRow();
        //        foreach (var item in dataTable.Columns.Cast<DataColumn>().Select(col => new { col.ColumnName, col.DataType }))
        //        {
        //            newRow[item.ColumnName] = DataTypeExtensions.GetDynamicValue(item.DataType, row[item.ColumnName]);
        //        }
        //        dataTable.Rows.Add(newRow);
        //    }
        //    return dataTable;
        //}

        public void CreateTable(DataColumnCollection columnCollection)
        {
            var createStatement = $"CREATE TABLE {_tableName}";

            var columns = string.Join(
                ", ",
                columnCollection.Cast<DataColumn>().Select(col => $"{col.ColumnName} {col.DataType.GetSqlType()}")
            );


            var query = $"{createStatement} ({columns})";

            sqliteService.ExecuteQuery(query);
        }

        public void CreateTable(DataTable dataTable)
        {
            CreateTable(dataTable.Columns);
        }
    }
}
