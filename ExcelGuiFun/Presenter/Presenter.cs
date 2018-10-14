using ExcelGuiFun.Models;
using ExcelGuiFun.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            const string tableName = "myTable";
            const string dbName = "temp.sqlite";
            string dbPath = Application.StartupPath + "\\" + dbName;

            if (File.Exists(dbPath)) File.Delete(dbPath);
            var sqliteService = new SqliteService(tableName, dbPath);

            var dbBuilder = new DbBuilder(tableName, sqliteService);

            dbBuilder.CreateTable(_dataTable.Columns);
            dbBuilder.InsertData(_dataTable.Rows);
        }

        private void GetDataTable(object sender, EventArgs e)
        {
            _dataTable = ExcelReader.ExtractDataTable(View.Path);
            View.XCoordinateCandidates = _dataTable.Columns.Cast<DataColumn>()
                .Select(col => col.ColumnName)
                .ToList();
            View.YCoordinateCandidates = _dataTable.Columns.Cast<DataColumn>()
                .Select(col => col.ColumnName)
                .ToList();
        }

        public IView View { get; }
    }
}
