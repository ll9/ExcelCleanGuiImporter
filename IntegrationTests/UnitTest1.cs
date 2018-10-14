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

        private ExcelReader _reader;

        [SetUp]
        public void Initialize()
        {
            _reader = new ExcelReader(_excelPath);
        }

        [Test]
        public void ReadExcel_ExcelSheetHas9999Rows_ReturnsRowCountOf9999()
        {
            var result = _reader.ExtractDataTable().Rows.Count;

            Assert.That(result, Is.EqualTo(9999));
        }

        [Test]
        public void ReadExcel_ExcelSheetHas6Column_ReturnsColumnCountOf6()
        {
            var result = _reader.ExtractDataTable().Columns.Count;

            Assert.That(result, Is.EqualTo(6));
        }
    }
}
