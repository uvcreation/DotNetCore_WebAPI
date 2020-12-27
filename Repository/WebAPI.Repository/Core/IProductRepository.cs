using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Core
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task AddProducts(List<Product> entity);
        Task UpdateProduct(List<Product> entity);
        Task RemoveProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
