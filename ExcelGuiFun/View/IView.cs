using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.View
{
    interface IView
    {
        string Path { get; }
        string Projektion { get; }
        string XCoordinate { get; }
        string YCoordinate { get; }
        bool HasCoordinates { get; }

        event EventHandler ReadingExcel;
        event EventHandler StoringDb;

        void OnReadingExcel(object sender, EventArgs args);
        void OnStroringDb(object sender, EventArgs args);
    }
}
