using ExcelGuiFun.View;
using ExcelGuiFun.ViewModels;
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
        public PathViewModel PathViewModel { get; set; } = new PathViewModel();
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
            InitPathBinding();

        }

        private void InitPathBinding()
        {
            PathBox.DataBindings.Add("Text", PathViewModel, nameof(PathViewModel.Path), false, DataSourceUpdateMode.OnPropertyChanged);
            //PathBox.DataBindings.Add("Text", PathViewModel, nameof(PathViewModel.Path));
            PathPage.DataBindings.Add(nameof(PathPage.AllowNext), PathViewModel, nameof(PathViewModel.HasPath));

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
