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
    public class Presenter
    {
        private DataTable _dataTable;

        public Presenter(IView view)
        {
            View = view;

            view.ReadingExcel += GetDataTable;
        }

        private void GetDataTable(object sender, EventArgs e)
        {
            _dataTable = ExcelReader.ExtractDataTable(View.Path);
        }

        public IView View { get; }
    }
}
