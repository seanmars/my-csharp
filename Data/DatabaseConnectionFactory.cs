using System;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Data.Abstractions;

namespace Data
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory(string connectionString) => _connectionString = connectionString ??
            throw new ArgumentNullException(nameof(connectionString));

        public async ValueTask<MySqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default(CancellationToken), bool openConnection = true)
        {
            try
            {
                var sqlConnection = new MySqlConnection(_connectionString);
                if (openConnection)
                {
                    await sqlConnection.OpenAsync(cancellationToken);
                }

                return sqlConnection;
            }
            catch
            {
                throw;
            }
        }
    }
}
