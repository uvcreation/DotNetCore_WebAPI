using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Business.Core;
using WebAPI.Business.Models;
using WebAPI.Repository.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDomain _productDomain;
        public ProductController(IProductDomain productDomain)
        {
            _productDomain = productDomain ?? throw new ArgumentNullException(nameof(productDomain));
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>ProductDto</returns>
        [HttpGet]
        [Route("GetAllProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GellAll()
        {
            var products = await _productDomain.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productDomain.GetProductById(id);
            return Ok(product);
        }

        /// <summary>
        /// Add products
        /// </summary>
        /// <param name="productModels"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProducts(List<ProductModel> productModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productDomain.AddProducts(productModels);
            return Ok();
        }

        /// <summary>
        /// Update products
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Updates(List<Product> products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productDomain.UpdateProducts(products);
            return Ok();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productDomain.RemoveProduct(id);
            return Ok();
        }
    }
}
