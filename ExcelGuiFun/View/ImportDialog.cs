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
        private PathViewModel PathViewModel { get; set; } = new PathViewModel();
        public string Path { get => PathBox.Text; }
        public string Projektion { get; set; }
        public string XCoordinate { get => XBox.Text; }
        public string YCoordinate { get => YBox.Text; }
        public bool HasCoordinates { get; set; }
        public List<string> XCoordinateCandidates
        {
            set
            {
                XBox.DataSource = value;
            }
        }
        public List<string> YCoordinateCandidates
        {
            set
            {
                YBox.DataSource = value;
            }
        }

        public event EventHandler ReadingExcel;
        public event EventHandler StoringDb;

        public ImportDialog()
        {
            InitializeComponent();
            var presenter = new Presenter.Presenter(this);

            InitPathBinding();
            InitializePageCommitEvents();
        }

        private void InitializePageCommitEvents()
        {
            PathPage.Commit += (sender, e) => OnReadingExcel(sender, EventArgs.Empty);
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
                PathBox.Text = dialog.FileName;
            }
        }
    }
}
