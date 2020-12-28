using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Helpers
{
    /// <summary>
    /// Query builder extension
    /// </summary>
    public static class QueryBuilderExtension
    {
        /// <summary>
        /// Bulk insert sql query builder
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public static IList<string> GenerateInsertSqlsBatches(this string sql, IList<Product> product)
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

        /// <summary>
        /// Bulk update sql query builder
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public static IList<string> GenerateUpdateSqlsBatches(this string sql, IList<Product> product)
        {
            var batchSql = sql.Split(';');
            var insertSql = batchSql[0];
            var valuesSql = batchSql[1];
            var duplicateCheck = batchSql[2];
            var batchSize = 1000;

            var sqlsToExecute = new List<string>();
            var numberOfBatches = (int)Math.Ceiling((double)product.Count / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var valueToInsert = product.Skip(i * batchSize).Take(batchSize);
                var valuesToInsert = valueToInsert.Select(u => string.Format(valuesSql, u.Id, u.Name, u.Cost));
                sqlsToExecute.Add(insertSql + string.Join(',', valuesToInsert) + duplicateCheck);
            }

            return sqlsToExecute;
        }
    }
}
