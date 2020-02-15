using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Data.Abstractions
{
    public interface IDatabaseConnectionFactory
    {
        ValueTask<MySqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default(CancellationToken), bool openConnection = true);
    }
}
