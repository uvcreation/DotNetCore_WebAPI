using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Business.Core;
using WebAPI.Business.Models;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;

namespace WebAPI.Business.Implementation
{
    /// <summary>
    /// Product Business - Get/Add/Update/Remove  
    /// </summary>
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductDomain(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Add products 
        /// </summary>
        /// <param name="productModels"></param>
        /// <returns></returns>
        public async Task AddProducts(List<ProductModel> productModels)
        {
            var products = _mapper.Map<List<ProductModel>, List<Product>>(productModels);
            await _productRepository.AddProducts(products);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        /// <summary>
        /// Remove product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveProduct(int id)
        {
            await _productRepository.RemoveProduct(id);
        }

        /// <summary>
        /// Update products
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public async Task UpdateProducts(List<Product> products)
        {
            await _productRepository.UpdateProducts(products);
        }
    }
}
