using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess.Factories
{
    public interface IDataAccessFactory
    {
        /// <summary>
        /// Loads data model as Enumerable from stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> LoadData<T, U>(string procedureName, U parameters, string connectionId = "Default");

        /// <summary>
        /// Saves data model through stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        Task SaveData<T>(string procedureName, T parameters, string connectionId = "Default");
    }

    internal class DataAccessFactory : IDataAccessFactory
    {
        private readonly IDefaultSqlConnectionFactory _databaseConnectionFactory;

        public DataAccessFactory(IDefaultSqlConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>
            (string procedureName, U parameters, string connectionId = "Default")
        {
            await using var sqlConnection = await _databaseConnectionFactory.CreateConnectionAsync();
            return await sqlConnection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>
            (string procedureName, T parameters, string connectionId = "Default")
        {
            await using var sqlConnection = await _databaseConnectionFactory.CreateConnectionAsync();
            await sqlConnection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
