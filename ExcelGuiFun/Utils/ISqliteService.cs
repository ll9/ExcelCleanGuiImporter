using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ExcelGuiFun.Utils
{
    public interface ISqliteService
    {
        void ExecuteQuery(string query, SQLiteConnection con = null, IEnumerable<Tuple<string, object>> parameters = null);
        void ExecuteTransaction(Action<SQLiteConnection> action);
    }
}