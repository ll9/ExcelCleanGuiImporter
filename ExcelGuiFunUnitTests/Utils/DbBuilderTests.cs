﻿using ExcelGuiFun.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFunUnitTests.Utils
{
    [TestFixture]
    class DbBuilderTests
    {
        private Mock<ISqliteService> sqliteService;
        private DbBuilder dbBuilder;

        [SetUp]
        public void Initialize()
        {
            sqliteService = new Mock<ISqliteService>();
            dbBuilder = new DbBuilder("table", sqliteService.Object);
        }

        [Test]
        public void CreateTable_WhenCalled_CreatesTable()
        {
            var table = new DataTable();
            table.Columns.Add("boolColumn", typeof(bool));
            table.Columns.Add("dateColumn", typeof(DateTime));
            table.Columns.Add("longColumn", typeof(long));
            table.Columns.Add("textColumn", typeof(string));
            table.Columns.Add("noTypeColumn");
            table.Rows.Add(table.NewRow());

            dbBuilder.CreateTable(table);
            sqliteService.Verify(x =>
                x.ExecuteQuery("CREATE TABLE table (boolColumn BOOLEAN, dateColumn DATETIME, longColumn BIGINT, textColumn TEXT, noTypeColumn TEXT)", null));
        }

        [Test]
        public void InsertData_WhenCalled_InsertsData()
        {

        }
    }
}
