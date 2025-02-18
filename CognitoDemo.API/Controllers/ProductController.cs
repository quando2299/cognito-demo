using AutoMapper;
using CognitoDemo.API.DTOs.Products;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CognitoDemo.API.Controllers
{
    //[Authorize]
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
            var response = mapper.Map<List<ProductResponse>>(result.Items);
            return Ok(new Paginate<ProductResponse>(response, result.TotalCount, pageIndex, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailResponse?>> Get(Guid id)
        {
            var model = await productService.GetDetailAsync(id);
            var response = mapper.Map<ProductDetailResponse>(model);

            return Ok(response);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ProductCreateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            var dto = mapper.Map<ProductCreateDto>(request);
            var result = await productService.CreateAsync(dto);
            var response = mapper.Map<ProductCreateResponse>(result);

            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
