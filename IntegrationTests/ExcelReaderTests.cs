using System;
using System.IO;
using ExcelGuiFun.Utils;
using Moq;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class ExcelReaderTests
    {
        private static readonly string _basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static readonly string _excelPath = _basePath + "\\hugedummy.xlsx";

        private ExcelReader _reader = new ExcelReader(_excelPath);

        [Test]
        public void ReadExcel_ExcelSheetHas9999Rows_ReturnsRowCountOf9999()
        {
            var result = _reader.ExtractDataTable().Rows.Count;

            Assert.That(result, Is.EqualTo(9999));
        }

        [Test]
        public void ReadExcel_ExcelSheetHas8Column_ReturnsColumnCountOf8()
        {
            var result = _reader.ExtractDataTable().Columns.Count;

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void ReadExcel_ExcelSheetHas8Column_ReadsCorrectColumnNames()
        {
            var result = _reader.ExtractDataTable().Columns;

            Assert.That(result[0].ColumnName, Is.EqualTo("ID"));
            Assert.That(result[1].ColumnName, Is.EqualTo("Straße"));
            Assert.That(result[7].ColumnName, Is.EqualTo("Y"));
        }

        [Test]
        public void ReadExcel_WhenCalled_FirstRowIsCorrect()
        {
            var result = _reader.ExtractDataTable();

            Assert.That(result.Rows[0]["ID"], Is.EqualTo(""));
        }

        [Test]
        public void ReadExcel_FirstCellIsEmpty_EmptyCellIsRead()
        {
            var result = _reader.ExtractDataTable();

            Assert.That(result.Rows[0]["ID"], Is.EqualTo(""));
        }
    }
}
