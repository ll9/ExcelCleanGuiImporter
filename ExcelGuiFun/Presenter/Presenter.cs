using ExcelGuiFun.Utils;
using ExcelGuiFun.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Presenter
{
    class Presenter
    {
        private DataTable _dataTable;

        public Presenter(IView view)
        {
            View = view;

            view.ReadingExcel += GetDataTable;
        }

        private void GetDataTable(object sender, EventArgs e)
        {
            var reader = new ExcelReader(View.Path);
            _dataTable = reader.ExtractDataTable();
        }

        public IView View { get; }
    }
}
