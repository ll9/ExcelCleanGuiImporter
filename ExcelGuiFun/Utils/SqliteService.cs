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

        public void ExecuteQuery(string query, Tuple<string, object>[] parameters = null)
        {
            using (SQLiteConnection connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                if (parameters != null)
                {
                    AddCommandParameters(parameters, command);
                }
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

        private static void AddCommandParameters(Tuple<string, object>[] parameters, SQLiteCommand command)
        {
            foreach (var commandParameter in parameters)
            {
                command.Parameters.AddWithValue(commandParameter.Item1, commandParameter.Item2);
            }
        }
    }
}