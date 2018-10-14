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
    }
}
