using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonkeyFinder.DataAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly AsyncLocal<DbConnection> AsyncLocal = new AsyncLocal<DbConnection>();
        private readonly string _connectionString;
        private readonly object _lock = new object();

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            if (IsConnectionStateOk())
            {
                return AsyncLocal.Value;
            }

            lock (_lock)
            {
                if (IsConnectionStateOk())
                {
                    return AsyncLocal.Value;
                }

                var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Disposed += OnDisposed;
                sqlConnection.Open();
                AsyncLocal.Value = sqlConnection;
            }

            return AsyncLocal.Value;
        }

        private bool IsConnectionStateOk()
        {
            var dbConnection = AsyncLocal.Value;

            if (dbConnection == null)
            {
                return false;
            }

            return dbConnection.State != ConnectionState.Closed && dbConnection.State != ConnectionState.Broken;
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            var dbConnection = sender as DbConnection;

            if (dbConnection == null)
            {
                return;
            }

            dbConnection.Disposed -= OnDisposed;
            lock (_lock)
            {
                AsyncLocal.Value = null;
            }
        }
    }
}
