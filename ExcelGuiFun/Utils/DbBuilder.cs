﻿using ExcelGuiFun.Models;
using ExcelGuiFun.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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

        public void CreateTable(DataColumnCollection columnCollection)
        {
            var createStatement = $"CREATE TABLE {_tableName}";

            var columns = string.Join(
                ", ",
                columnCollection.Cast<DataColumn>().Select(col => $"[{col.ColumnName}] {col.DataType.GetSqlType()}")
            );


            var query = $"{createStatement} ({columns})";

            sqliteService.ExecuteQuery(query);
        }

        public void CreateTable(DataTable dataTable)
        {
            CreateTable(dataTable.Columns);
        }

        public void InsertData(DataRowCollection rows)
        {

            sqliteService.ExecuteTransaction((connection) =>
            {
                foreach (DataRow row in rows)
                {
                    InsertData(row, connection);
                }
            });
        }

        public void InsertData(DataRow row, SQLiteConnection connection = null)
        {
            var insertStatement = $"INSERT INTO {_tableName}";
            var columns = row.Table.Columns.Cast<DataColumn>().Select(col => $"[{col.ColumnName}]");
            var columnString = string.Join(", ", columns);

            var parameters = row.Table.Columns.Cast<DataColumn>()
                .Select((col, index) => new Tuple<string, object>($"@param{index}", DataTypeExtensions.GetDynamicValue(col.DataType, row[col])));
            var parametersString = string.Join(", ", parameters.Select(param => param.Item1));

            var query = $"{insertStatement}({columnString}) VALUES ({parametersString})";
            sqliteService.ExecuteQuery(query, connection, parameters);
        }
    }
}
