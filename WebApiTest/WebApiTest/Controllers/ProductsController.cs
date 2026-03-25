using ApiProduct.Application.Dto.Product.Request.Add;
using ApiProduct.Application.Dto.Product.Request.Update;
using ApiProduct.Application.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region [Properties]

        private readonly IProductService _productService;

        #endregion

        #region [Constructor]
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region [Apis]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetById(id);

            if(response is null)
                return NotFound();

            return Ok(response);
        } 

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDto request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _productService.AddProduct(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestDto request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _productService.UpdateProduct(request);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        #endregion
    }
}
