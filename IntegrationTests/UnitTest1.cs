using System;
using System.IO;
using ExcelGuiFun.Utils;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class UnitTest1
    {
        public void TestMethod1()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var excelFilePath = path + "\\hugedummy.xlsx";

            if (!File.Exists(excelFilePath))
            {
                throw new FileNotFoundException();
            }

            var reader = new ExcelReader(excelFilePath);
            var table = reader.ExtractDataTable();
        }
    }
}
