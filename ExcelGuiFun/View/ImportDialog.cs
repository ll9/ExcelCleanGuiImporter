using ExcelGuiFun.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelGuiFun
{
    public partial class ImportDialog : Form, IView
    {
        public string Path { get; set; }
        public string Projektion { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public bool HasCoordinates { get; set; }

        public event EventHandler ReadingExcel;
        public event EventHandler StoringDb;

        public ImportDialog()
        {
            InitializeComponent();
        }


        public void OnReadingExcel(object sender, EventArgs args)
        {
            ReadingExcel?.Invoke(sender, EventArgs.Empty);
        }

        public void OnStroringDb(object sender, EventArgs args)
        {
            StoringDb?.Invoke(sender, EventArgs.Empty);
        }
    }
}
