using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Core.Interfaces;

namespace CognitoDemo.Application.Interfaces;

public interface IProductService
{
    Task<IPaginate<ProductDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<ProductDetailDto?> GetDetailAsync(Guid id);
    Task<ProductDetailDto> CreateAsync(ProductCreateDto model);
}