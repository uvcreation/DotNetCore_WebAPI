using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Business.Models;
using WebAPI.Repository.Entities;

namespace WebAPI.Business.Core
{
    /// <summary>
    /// Product Business - Get/Add/Update/Remove  
    /// </summary>
    public interface IProductDomain
    {
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int id);

        /// <summary>
        /// Add products 
        /// </summary>
        /// <param name="productModels"></param>
        /// <returns></returns>
        Task AddProducts(List<ProductModel> productModels);

        /// <summary>
        /// Update products
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        Task UpdateProducts(List<Product> products);

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
