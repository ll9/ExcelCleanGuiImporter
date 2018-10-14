using ExcelGuiFun.View;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    class PresenterTest
    {
        public static void Main()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var excelFilePath = path + "\\hugedummy.xlsx";

            var gui = new Mock<IView>();
            gui.SetupGet(view => view.Path).Returns(excelFilePath);
            gui.SetupGet(view => view.XCoordinate).Returns("PLZ");
            gui.SetupGet(view => view.YCoordinate).Returns("PLZ");
        }
    }
}
