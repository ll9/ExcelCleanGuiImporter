using System;
using System.Collections.Generic;

namespace ExcelGuiFun
{
    public interface IView
    {
        bool HasCoordinates { get; set; }
        string Path { get; }
        string Projektion { get; set; }
        string XCoordinate { get; }
        List<string> XCoordinateCandidates { set; }
        string YCoordinate { get; }
        List<string> YCoordinateCandidates { set; }

        event EventHandler ReadingExcel;
        event EventHandler StoringDb;

        void OnReadingExcel(object sender, EventArgs args);
        void OnStroringDb(object sender, EventArgs args);
    }
}