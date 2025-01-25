using AutoMapper;
using CognitoDemo.API.DTOs.Products;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognitoDemo.API.Controllers
{
    public class ProductController(IMapper mapper, IProductService productService) : BaseController
    {
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
