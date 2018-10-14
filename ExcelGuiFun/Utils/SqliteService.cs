using System;
using System.Data.SQLite;

namespace ExcelGuiFun.Utils
{
    public class SqliteService : ISqliteService
    {
        private string _tableName;
        private string _dbPath;

        public SqliteService(string tableName, string dbPath)
        {
            _tableName = tableName;
            _dbPath = dbPath;
        }

        public void ExecuteQuery(string query)
        {
            using (SQLiteConnection connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ExecuteTransaction(Action action)
        {
            using (var connection = GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                action();
                transaction.Commit();
            }
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection($"Data Source={_dbPath}");
            connection.Open();
            return connection;
        }
    }
}