using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess.Factories
{
    public interface IDefaultSqlConnectionFactory
    {
        Task<SqlConnection> CreateConnectionAsync();
        string DbSchema { get; set; }
    }

    public class DefaultSqlConnectionFactory : IDefaultSqlConnectionFactory
    {
        private readonly string _connectionString;

        public DefaultSqlConnectionFactory(string connectionString, string schema)
        {
            schema = schema.Replace("[", string.Empty).Replace("]", string.Empty);
            _connectionString = connectionString ?? string.Empty;
            DbSchema = schema;
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            if (sqlConnection.State != ConnectionState.Open) await sqlConnection.OpenAsync();
            return sqlConnection;
        }

        public string DbSchema { get; set; }
    }
}
