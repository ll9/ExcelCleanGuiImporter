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
        public string Path { get => PathPage.Text; }
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

        private void PathButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = "Excel File (*.xlsx) | *.xlsx" };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PathPage.Text = dialog.FileName;
            }
        }
    }
}
