using ExcelGuiFun.Utils;
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
    class TypeSafeDataTableConverterTests
    {
        [Test]
        public void Convert_WhenCalled()
        {
            var table = new DataTable();
            table.Columns.Add("1");
            var row1 = table.NewRow();
            var row2 = table.NewRow();
            var row3 = table.NewRow();

            row1[0] = 1;
            row2[0] = 27;
            row3[0] = DBNull.Value;

            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);

            var result = TypeSafeDataTableConverter.Convert(table);
            Assert.That(result.Columns[0].DataType, Is.EqualTo(typeof(long?)));
        }
    }
}
