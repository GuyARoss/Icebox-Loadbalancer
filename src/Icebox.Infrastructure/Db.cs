using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Icebox.Infrastructure
{
    public abstract class Db<T> where T : class
    {
        private readonly string _databaseKey = "icebox_db_instance";
        public abstract string TableName { get;  }

        public readonly SQLiteConnection DbConnection;

        public abstract Dictionary<string, string> TableColumns { get; } 

        public Db()
        {
            string dbFile = string.Format("{0}.sqlite", _databaseKey);

            bool exists = File.Exists(dbFile);
            if (!exists)
            {
                SQLiteConnection.CreateFile(dbFile);
            }
            DbConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3", dbFile));
            DbConnection.Open();
                        
            _createTable();
        }
        private void _createTable()
        {
            string tableColumns = "";

            int count = 0;
            foreach (var column in TableColumns)
            {
                count++;
                if (count == TableColumns.Count)
                {
                    tableColumns += string.Format("'{0}' {1} ", column.Key, column.Value);
                } else
                {
                    tableColumns += string.Format("'{0}' {1}, ", column.Key, column.Value);
                }
            }

            string sql = string.Format("CREATE TABLE `{0}` ({1})", TableName, tableColumns);
            _executeNonQueryCommand(sql);
        }

        protected async Task _executeNonQueryCommand(string request)
        {
            var command = new SQLiteCommand(request, DbConnection);
            await command.ExecuteNonQueryAsync();
        }
        protected async Task _executeNonQueryCommand(SQLiteCommand command)
        {
            await command.ExecuteNonQueryAsync();
        }
        protected IEnumerable<T> _exectuteQueryCommand(string request, Func<SQLiteDataReader, T> readerMapper)
        {
            var command = new SQLiteCommand(request, DbConnection);
            var reader = command.ExecuteReader();

            var rows = new List<T>();
            while (reader.Read())
            {
                rows.Add(readerMapper.Invoke(reader));
            }

            return rows;
        }
    }
}
