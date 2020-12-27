using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Business.Core;
using WebAPI.Business.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDomain _productDomain;

        public ProductController(IProductDomain productDomain)
        {
            _productDomain = productDomain;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<ActionResult<ProductDto>> GellAll()
        {
            var products = await _productDomain.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productDomain.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProducts(List<ProductDto> entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productDomain.AddProducts(entity);
            return Ok();
        }

        //TODO: Testing pending for 1000 record / sec 
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult> Update(List<ProductDto> entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productDomain.UpdateProduct(entity);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteProductById/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productDomain.RemoveProduct(id);
            return Ok();
        }
    }
}
