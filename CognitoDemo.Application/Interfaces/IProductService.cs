using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Core.Interfaces;

namespace CognitoDemo.Application.Interfaces;

public interface IProductService
{
    Task<IPaginate<ProductDto>> GetAllAsync(int pageIndex, int pageSize);
    // Task<Product> GetByIdAsync(int id);
    // Task<Product> CreateAsync(Product product);
    Task<ProductDto> CreateAsync(CreateProductDto model);
}