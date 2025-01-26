using AutoMapper;
using CognitoDemo.API.DTOs.Products;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognitoDemo.API.Controllers
{
    public class ProductController(IMapper mapper, IProductService productService) : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IPaginate<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IPaginate<ProductResponse>>> GetAll(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await productService.GetAllAsync(pageIndex, pageSize);
            var responses = mapper.Map<List<ProductResponse>>(result.Items);
            return Ok(new Paginate<ProductResponse>(responses, result.TotalCount, pageIndex, pageSize));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var dto = mapper.Map<CreateProductDto>(request);
            var result = await productService.CreateAsync(dto);
            var response = mapper.Map<ProductResponse>(result);

            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
