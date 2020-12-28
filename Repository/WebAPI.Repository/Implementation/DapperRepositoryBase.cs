using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Implementation
{
    /// <summary>
    /// Manage dapper operations
    /// </summary>
    public class DapperRepositoryBase : IDapperRepositoryBase
    {
        private readonly string connectionString;
        public DapperRepositoryBase(IOptions<DatabaseSetting> options)
        {
            connectionString = options.Value.MySqlConnection;
        }

        /// <summary>
        /// Execute the sql batch query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ExecuteBatchQueryAsync<T>(string sql)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql);
            }
        }

        /// <summary>
        /// Execute the sql parameterized query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Execute the sql query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql);
            }
        }

        /// <summary>
        /// Open the connection
        /// </summary>
        /// <returns></returns>
        private async Task<MySqlConnection> GetOpenConnectionAsync()
        {
            var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
