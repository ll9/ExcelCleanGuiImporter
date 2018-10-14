using ExcelGuiFun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils
{
    public class ColumnTypeGuesser
    {
        private DataTable _dataTable;

        public ColumnTypeGuesser(DataTable dataTable)
        {
            _dataTable = dataTable ?? throw new ArgumentNullException();
            if (_dataTable.Rows.Count == 0 || _dataTable.Columns.Count == 0)
            {
                throw new ArgumentException("Datatable has to contain at least one row/column");
            }
        }

        /// <summary>
        /// Guesses type of the DataTable column
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public DataType GuessType(int columnIndex)
        {
            // Retrun Text Type when there are only empty rows
            if (_dataTable.Rows.Cast<DataRow>().Select(row => row[columnIndex]).Distinct().Count() == 1 && string.IsNullOrEmpty(_dataTable.Rows[columnIndex][0].ToString()))
            {
                return DataType.System_Text;
            }

            // Return the first type where all rows match
            foreach (var type in Enum.GetValues(typeof(DataType)).Cast<DataType>())
            {
                int i;
                for (i = 0; i < _dataTable.Rows.Count; i++)
                {
                    var guessedType = GuessType(_dataTable.Rows[i][columnIndex].ToString());
                    if (!guessedType.HasFlag(type))
                    {
                        break;
                    }
                }
                if (i == _dataTable.Rows.Count)
                {
                    return type;
                }
            }

            return DataType.System_Text;
        }

        public DataType GuessType(DataColumn column)
        {
            return GuessType(_dataTable.Columns.IndexOf(column));
        }

        private DataType GuessType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return (DataType.System_Bool | DataType.System_Date | DataType.System_Numeric | DataType.System_Text);
            }

            if (bool.TryParse(value, out var boolResult)) return DataType.System_Bool;
            if (DateTime.TryParse(value, out var dateResult)) return DataType.System_Date;
            if (long.TryParse(value, out var numericResult)) return DataType.System_Numeric;
            return DataType.System_Text;
        }
    }
}
