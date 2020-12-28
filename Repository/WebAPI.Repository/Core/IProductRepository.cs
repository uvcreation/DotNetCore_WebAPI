using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Core
{
    /// <summary>
    /// Product Repository - Get/Add/Update/Remove 
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetById(int id);

        /// <summary>
        /// Add products 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddProducts(List<Product> entity);

        /// <summary>
        /// Update products
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateProducts(List<Product> entity);

        /// <summary>
        /// Remove product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveProduct(int id);

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
