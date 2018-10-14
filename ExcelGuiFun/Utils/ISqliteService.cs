using System;

namespace ExcelGuiFun.Utils
{
    public interface ISqliteService
    {
        void ExecuteQuery(string query);
        void ExecuteTransaction(Action action);
    }
}