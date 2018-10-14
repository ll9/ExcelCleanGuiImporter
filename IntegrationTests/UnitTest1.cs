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
        public void ReadExcel_WhenCalled()
        {
            var result = _reader.ExtractDataTable().Rows.Count;

            Assert.That(result, Is.EqualTo(9999));
        }
    }
}
