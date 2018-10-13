using ExcelGuiFun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils
{
    class DataColumnTypeGuesser
    {
        private DataTable _dataTable;

        public DataColumnTypeGuesser(DataTable dataTable)
        {
            _dataTable = dataTable ?? throw new ArgumentNullException();
            if (_dataTable.Rows.Count == 0 || _dataTable.Columns.Count == 0)
            {
                throw new ArgumentException("Datatable has to contain at least one row/column");
            }
        }

        public DataType GuessType(int index)
        {
            // Retrun Text Type when there are only empty rows
            if (_dataTable.Rows.Cast<DataRow>().Distinct().Count() == 1 && string.IsNullOrEmpty(_dataTable.Rows[index][0].ToString()))
            {
                return DataType.System_Text;
            }

            // Return the first type where all rows match
            foreach (var type in Enum.GetValues(typeof(DataType)).Cast<DataType>())
            {
                int i;
                for (i = 0; i < _dataTable.Rows.Count; i++)
                {
                    var guessedType = GuessType(_dataTable.Rows[index][i].ToString());
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

        private DataType GuessType(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return (DataType.System_Bool | DataType.System_Date | DataType.System_Numeric | DataType.System_Text);
            }

            if (bool.TryParse(v, out var boolResult)) return DataType.System_Bool;
            if (DateTime.TryParse(v, out var dateResult)) return DataType.System_Date;
            if (long.TryParse(v, out var numericResult)) return DataType.System_Numeric;
            return DataType.System_Text;
        }
    }
}
