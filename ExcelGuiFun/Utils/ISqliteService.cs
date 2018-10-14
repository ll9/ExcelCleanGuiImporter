using System;
using System.Collections.Generic;

namespace ExcelGuiFun.Utils
{
    public interface ISqliteService
    {
        void ExecuteQuery(string query, IEnumerable<Tuple<string, object>> parameters = null);
        void ExecuteTransaction(Action action);
    }
}