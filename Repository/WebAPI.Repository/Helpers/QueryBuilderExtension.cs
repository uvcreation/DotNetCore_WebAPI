using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Helpers
{
    public static class QueryBuilderExtension
    {
        /// <summary>
        /// Bulk query builder for product
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public static IList<string> GenerateSqlsBatches(this string sql, IList<Product> product)
        {
            var batchSql = sql.Split(';');
            var insertSql = batchSql[0];
            var valuesSql = batchSql[1];
            var batchSize = 1000;

            var sqlsToExecute = new List<string>();
            var numberOfBatches = (int)Math.Ceiling((double)product.Count / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var valueToInsert = product.Skip(i * batchSize).Take(batchSize);
                var valuesToInsert = valueToInsert.Select(u => string.Format(valuesSql, u.Name, u.Cost));
                sqlsToExecute.Add(insertSql + string.Join(',', valuesToInsert));
            }
            return sqlsToExecute;
        }
    }
}
