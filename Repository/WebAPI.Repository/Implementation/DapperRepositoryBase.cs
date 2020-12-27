using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Implementation
{
    public class DapperRepositoryBase : IDapperRepositoryBase
    {
        private readonly string connectionString;
        public DapperRepositoryBase(IOptions<DatabaseSetting> options)
        {
            connectionString = options.Value.MySqlConnection;
        }

        public async Task<IEnumerable<T>> ExecuteBatchQueryAsync<T>(string sql)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.QueryAsync<T>(sql);
            }
        }

        private async Task<IDbConnection> GetOpenConnectionAsync()
        {
            var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
