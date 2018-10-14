using ExcelGuiFun.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelGuiFun.Presenter
{
    public class Presenter
    {
        private DataTable _dataTable;

        public Presenter(IView view)
        {
            View = view;

            view.ReadingExcel += GetDataTable;
            view.StoringDb += StoreDataToDb;
        }

        private void StoreDataToDb(object sender, EventArgs e)
        {
            const string tableName = "table";
            const string dbName = "temp.sqlite";
            var sqliteService = new SqliteService(tableName, Application.StartupPath+ "\\" + dbName);

            var dbBuilder = new DbBuilder(tableName, sqliteService);

            dbBuilder.CreateTable(_dataTable.Columns);
            dbBuilder.InsertData(_dataTable.Rows);
        }

        private void GetDataTable(object sender, EventArgs e)
        {
            _dataTable = ExcelReader.ExtractDataTable(View.Path);
            View.XCoordinateCandidates = _dataTable.Columns.Cast<DataColumn>()
                .Where(col => col.DataType == typeof(double))
                .Select(col => col.ColumnName)
                .ToList();
            View.YCoordinateCandidates = _dataTable.Columns.Cast<DataColumn>()
                .Where(col => col.DataType == typeof(double))
                .Select(col => col.ColumnName)
                .ToList();
        }

        public IView View { get; }
    }
}
