using System;
using System.IO;
using ClosedXML.Excel;
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
        private static readonly IXLWorkbook testWorkBook = new XLWorkbook(_excelPath);
        private static readonly IXLWorksheet testWorksheet = testWorkBook.Worksheet(1);
        private static readonly IXLWorksheet shiftedWorksheet = testWorkBook.Worksheet(2);

        [Test]
        public void ReadExcel_ExcelSheetHas9999Rows_ReturnsRowCountOf9999()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet).Rows.Count;

            Assert.That(result, Is.EqualTo(9999));
        }

        [Test]
        public void ReadExcel_ExcelSheetHas8Column_ReturnsColumnCountOf8()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet).Columns.Count;

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void ReadExcel_ExcelSheetHas8Column_ReadsCorrectColumnNames()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet).Columns;

            Assert.That(result[0].ColumnName, Is.EqualTo("ID"));
            Assert.That(result[1].ColumnName, Is.EqualTo("Straße"));
            Assert.That(result[7].ColumnName, Is.EqualTo("Y"));
        }

        [Test]
        public void ReadExcel_WhenCalled_FirstRowIsCorrect()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet);

            Assert.That(result.Rows[0][0], Is.EqualTo(""));
            Assert.That(result.Rows[0][1], Is.EqualTo("Nußbaumstrasse"));
            Assert.That(result.Rows[0][2], Is.EqualTo("83123"));
            Assert.That(result.Rows[0][3], Is.EqualTo("TRUE"));
            Assert.That(result.Rows[0][4], Is.EqualTo("22,34"));
            Assert.That(result.Rows[0][5], Is.EqualTo("21.09.2018 00:00:00"));
            Assert.That(result.Rows[0][6], Is.EqualTo("6,2"));
            Assert.That(result.Rows[0][7], Is.EqualTo("51,3"));
        }

        [Test]
        public void ReadExcel_FirstCellIsEmpty_EmptyCellIsRead()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet);

            Assert.That(result.Rows[0]["ID"], Is.EqualTo(""));
        }

        [Test]
        public void ReadExcel_LastCellIsEmpty_EmptyCellIsRead()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet);

            Assert.That(result.Rows[1][7], Is.EqualTo(""));
        }

        [Test]
        public void ReadExcel_TableDoesNotStartAtFirstCell_ReadsColumnNamesProperly()
        {
            var result = ExcelReader.ExtractDataTable(shiftedWorksheet);

            Assert.That(result.Columns.Count, Is.EqualTo(2));
            Assert.That(result.Columns[0].ColumnName, Is.EqualTo("ID"));
            Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Name"));
        }
    }
}
