using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Repository.Core
{
    public interface IDapperRepositoryBase
    {
        Task<IEnumerable<T>> ExecuteBatchQueryAsync<T>(string sql);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object parameters = null);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql);
    }
}
