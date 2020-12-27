using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Core;
using WebAPI.Business.Dto;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;

namespace WebAPI.Business.Implementation
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductDomain(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddProducts(List<ProductDto> entity)
        {
            var products = _mapper.Map<List<ProductDto>, List<Product>>(entity);
            await _productRepository.AddProducts(products);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var products = await _productRepository.GetById(id);
            return _mapper.Map<Product, ProductDto>(products);
        }

        public async Task RemoveProduct(int id)
        {
            await _productRepository.RemoveProduct(id);
        }

        public async Task UpdateProduct(List<ProductDto> entity)
        {
            var products = _mapper.Map<List<ProductDto>, List<Product>>(entity);
            await _productRepository.UpdateProduct(products);
        }
    }
}
