using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var produtos = await _productService.GetProductsAsync();

            if(produtos == null)
            {
                return NotFound("Products not found");
            }

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var produto = await _productService.GetByIdAsync(id);

            if(produto == null)
            {
                return NotFound("Product not found");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if(productDTO == null)
            {
                return BadRequest("Invalid Product Data");
            }

            await _productService.AddAsync(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if(id != productDTO.Id)
            {
                return BadRequest("Invalid Data");
            }

            if(productDTO == null)
            {
                return BadRequest("Invalid Product Data");
            }

            await _productService.UpdateAsync(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDTO = await _productService.GetByIdAsync(id);

            if(productDTO == null)
            {
                return NotFound("Product not Found");
            }

            await _productService.RemoveAsync(id);
            
            return Ok(productDTO);
        }
    }
}
