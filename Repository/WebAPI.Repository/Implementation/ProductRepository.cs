using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Helpers;

namespace WebAPI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDapperRepositoryBase _dapperRepositoryBase;
        private readonly ICommandText _commandText;
        public ProductRepository(IDapperRepositoryBase dapperRepositoryBase, ICommandText commandText)
        {
            _dapperRepositoryBase = dapperRepositoryBase;
            _commandText = commandText;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.GetProducts);
        }

        public async Task<Product> GetById(int id)
        {
            var products = await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.GetProductById);
            return products.FirstOrDefault();
        }

        public async Task AddProducts(List<Product> entity)
        {
            var bathSqls = _commandText.AddProduct.GenerateSqlsBatches(entity);
            foreach (var sql in bathSqls)
            {
                await _dapperRepositoryBase.ExecuteBatchQueryAsync<Product>(sql);
            }
        }

        public async Task UpdateProduct(List<Product> entity)
        {
            var bathSqls = _commandText.UpdateProduct.GenerateSqlsBatches(entity.ToList());
            foreach (var sql in bathSqls)
            {
                await _dapperRepositoryBase.ExecuteBatchQueryAsync<Product>(sql);
            }
        }

        public async Task RemoveProduct(int id)
        {
            var parameters = new { Id = id };
            await _dapperRepositoryBase.ExecuteQueryAsync<Product>(_commandText.RemoveProduct, parameters);
        }
    }
}
