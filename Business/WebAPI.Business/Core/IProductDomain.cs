using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Dto;

namespace WebAPI.Business.Core
{
    public interface IProductDomain
    {
        Task<ProductDto> GetProductById(int id);
        Task AddProducts(List<ProductDto> entity);
        Task UpdateProduct(List<ProductDto> entity);
        Task RemoveProduct(int id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
