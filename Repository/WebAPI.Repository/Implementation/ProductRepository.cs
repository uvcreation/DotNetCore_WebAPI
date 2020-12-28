using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Helpers;

namespace WebAPI.Repository.Implementation
{
    /// <summary>
    /// Product Repository - Get/Add/Update/Remove 
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IDapperRepositoryBase _dapperRepositoryBase;
        private readonly ICommandText _commandText;
        public ProductRepository(IDapperRepositoryBase dapperRepositoryBase, ICommandText commandText)
        {
            _dapperRepositoryBase = dapperRepositoryBase ?? throw new ArgumentNullException(nameof(dapperRepositoryBase));
            _commandText = commandText ?? throw new ArgumentNullException(nameof(commandText));
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.GetProducts);
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetById(int id)
        {
            var parameters = new { Id = id };
            var products = await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.GetProductById, parameters);
            return products.FirstOrDefault();
        }

        /// <summary>
        /// Add products 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddProducts(List<Product> entity)
        {
            var bathSqls = _commandText.AddProduct.GenerateInsertSqlsBatches(entity);
            foreach (var sql in bathSqls)
            {
                await _dapperRepositoryBase.ExecuteBatchQueryAsync<Product>(sql);
            }
        }

        /// <summary>
        /// Update products
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateProducts(List<Product> entity)
        {
            var bathSqls = _commandText.UpdateProduct.GenerateUpdateSqlsBatches(entity);
            foreach (var sql in bathSqls)
            {
                await _dapperRepositoryBase.ExecuteBatchQueryAsync<Product>(sql);
            }
        }

        /// <summary>
        /// Remove product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveProduct(int id)
        {
            var parameters = new { Id = id };
            await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.RemoveProduct, parameters);
        }
    }
}
