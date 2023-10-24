using Application.Dtos;
using Application.Services;
using Application.Services.IProducts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productServices.GetProduct(id);

            if (product is null)
            {
                return NotFound($"The product with ID = {id} not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest productRequest)
        {
            if (productRequest is null)
            {
                return BadRequest("Product values are empty.");
            }

            await _productServices.AddProduct(productRequest);
            return Ok(productRequest);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductRequest productRequest)
        {
            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Product values are empty.");
            }

            if (productRequest is null)
            {
                return BadRequest("Product values are empty.");
            }

            var product = await _productServices.GetProduct(id);

            if (product is null)
            {
                return NotFound("Product does not exist.");
            }

            await _productServices.UpdateProduct(productRequest);
            return Ok();
        }
    }
}
