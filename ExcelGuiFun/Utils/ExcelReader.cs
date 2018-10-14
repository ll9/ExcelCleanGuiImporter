using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils
{
    public class ExcelReader
    {

        /// <summary>
        /// Returns a DataTable from an Excel Worksheet
        /// Rules:
        /// #1 the first row used contains all column names
        /// #2 all table items are in the same range as the first row
        /// #3 an table ends when it has an empty row
        /// </summary>
        /// <param name="sheetPosition">the position/ index of the worksheet (starts at 1)</param>
        /// <returns></returns>
        public static DataTable ExtractDataTable(IXLWorksheet worksheet)
        {
            var dataTable = new DataTable();


            // Gets the range of the used Cells
            var firstRow = worksheet.FirstRowUsed().RowUsed();
            var columnNames = firstRow.Cells().Select(cell => cell.Value.ToString());

            // Add columns to the DataTable
            foreach (var columnName in columnNames)
            {
                dataTable.Columns.Add(columnName);
            }

            // Add row to the DataTable
            var currentRow = firstRow.RowBelow();

            while(!currentRow.IsEmpty()) 
            {
                dataTable.Rows.Add();
                var cells = currentRow.Cells();

                foreach (var item in cells.Select((cell, indexer) => new { Cell = cell, Index = indexer }))
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][item.Index] = item.Cell.Value;
                }
                currentRow = currentRow.RowBelow();
            }

            return dataTable;
        }

        public static DataTable ExtractDataTable(string path, int sheetPosition = 1)
        {
            var worksheet = new XLWorkbook(path).Worksheet(sheetPosition);

            return ExtractDataTable(worksheet);
        }

        public static DataTable ExtractDataTable(string path, string sheetName)
        {
            var worksheet = new XLWorkbook(path).Worksheet(sheetName);

            return ExtractDataTable(worksheet);
        }
    }
}
