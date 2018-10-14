using ExcelGuiFun.Utils;
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
            dbBuilder = new DbBuilder("myTable", sqliteService.Object);
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
            var table = new DataTable();
            table.Columns.Add("boolColumn", typeof(bool));
            table.Columns.Add("dateColumn", typeof(DateTime));
            table.Columns.Add("longColumn", typeof(long));
            table.Columns.Add("textColumn", typeof(string));
            table.Columns.Add("noTypeColumn");

            var row = table.NewRow();
            row[0] = true;
            row[1] = DateTime.Now;
            row[2] = long.MaxValue;
            row[3] = "string";
            row[4] = "";

            var parameters = new Tuple<string, object>[] {
                new Tuple<string, object>("param0", true),
                new Tuple<string, object>("param1", DateTime.Now),
                new Tuple<string, object>("param2", long.MaxValue),
                new Tuple<string, object>("param3", "string"),
                new Tuple<string, object>("param4", "")
            };
            var query = $"INSERT INTO table([boolColumn], [dateColumn], [longColumn], [textColumn], [noTypeColumn]) " +
                $"VALUES ({string.Join(", ", parameters.Select(p => p.Item1))})";

            dbBuilder.InsertData(row);

            sqliteService.Verify(x =>
                x.ExecuteQuery(query, It.IsAny<IEnumerable<Tuple<string, object>>>()));
        }

        [Test]
        public void InsertData_InsertNull_InsertsNull()
        {
            var table = new DataTable();
            table.Columns.Add("boolColumn", typeof(bool));

            var row = table.NewRow();
            row[0] = DBNull.Value;

            var parameters = new Tuple<string, object>[] {
                new Tuple<string, object>("param0", null),
            };
            var query = $"INSERT INTO table([boolColumn]) " +
                $"VALUES ({string.Join(", ", parameters.Select(p => p.Item1))})";

            dbBuilder.InsertData(row);

            sqliteService.Verify(x =>
                x.ExecuteQuery(query, It.IsAny<IEnumerable<Tuple<string, object>>>()));
        }
    }
}
