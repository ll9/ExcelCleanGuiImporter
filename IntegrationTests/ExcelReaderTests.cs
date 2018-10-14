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
        private static readonly IXLWorksheet testWorksheet = new XLWorkbook(_excelPath).Worksheet(1);

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

            Assert.That(result.Rows[0]["ID"], Is.EqualTo(""));
        }

        [Test]
        public void ReadExcel_FirstCellIsEmpty_EmptyCellIsRead()
        {
            var result = ExcelReader.ExtractDataTable(testWorksheet);

            Assert.That(result.Rows[0]["ID"], Is.EqualTo(""));
        }
    }
}
