using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Repository.Core
{
    /// <summary>
    /// Manage dapper operations
    /// </summary>
    public interface IDapperRepositoryBase
    {
        /// <summary>
        /// Execute the sql batch query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteBatchQueryAsync<T>(string sql);

        /// <summary>
        /// Execute the sql parameterized query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object parameters = null);

        /// <summary>
        /// Execute the sql query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql);
    }
}
