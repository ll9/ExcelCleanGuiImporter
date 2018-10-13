using ExcelGuiFun.Models;
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
    class DataColumnTypeGuesserTests
    {
        [Test]
        public void GuessType_EmptyDataTable_ThrowsArgumentNullException()
        {
            Assert.That(() => new DataColumnTypeGuesser(null), Throws.ArgumentNullException);
        }

        [Test]
        public void GuessType_NoRows_ThrowsArgumentNullException()
        {
            var dt = new DataTable();
            dt.Columns.Add("columnName");

            Assert.That(() => new DataColumnTypeGuesser(dt), Throws.ArgumentException);
        }

        [Test]
        public void GuessType_BoolRows_ReturnsTypeBool()
        {
            var dt = new DataTable();
            dt.Columns.Add("column");

            dt.Rows.Add(false);
            dt.Rows.Add(true);
            dt.Rows.Add("");

            var typeGuesser = new DataColumnTypeGuesser(dt);

            Assert.That(typeGuesser.GuessType(0), Is.EqualTo(DataType.System_Bool) );
        }

        [Test]
        public void GuessType_NumericRows_ReturnsTypeNumeric()
        {
            var dt = new DataTable();
            dt.Columns.Add("column");

            dt.Rows.Add(1);
            dt.Rows.Add(long.MaxValue);
            dt.Rows.Add("");

            var typeGuesser = new DataColumnTypeGuesser(dt);

            Assert.That(typeGuesser.GuessType(0), Is.EqualTo(DataType.System_Numeric));
        }

        [Test]
        public void GuessType_DateTimeRows_ReturnsTypeDate()
        {
            var dt = new DataTable();
            dt.Columns.Add("column");

            dt.Rows.Add(DateTime.Now);
            dt.Rows.Add(DateTime.Now.Subtract(DateTime.Now.AddDays(7)));
            dt.Rows.Add("");

            var typeGuesser = new DataColumnTypeGuesser(dt);

            Assert.That(typeGuesser.GuessType(0), Is.EqualTo(DataType.System_Date));
        }

        [Test]
        public void GuessType_TextRows_ReturnsTextType()
        {
            var dt = new DataTable();
            dt.Columns.Add("column");

            dt.Rows.Add("text");
            dt.Rows.Add("more Text");
            dt.Rows.Add("");

            var typeGuesser = new DataColumnTypeGuesser(dt);

            Assert.That(typeGuesser.GuessType(0), Is.EqualTo(DataType.System_Text));
        }

        [Test]
        public void GuessType_EmptyRows_ReturnsTextType()
        {
            var dt = new DataTable();
            dt.Columns.Add("column");

            dt.Rows.Add("");
            dt.Rows.Add("");
            dt.Rows.Add("");

            var typeGuesser = new DataColumnTypeGuesser(dt);

            Assert.That(typeGuesser.GuessType(0), Is.EqualTo(DataType.System_Text));
        }
    }
}
