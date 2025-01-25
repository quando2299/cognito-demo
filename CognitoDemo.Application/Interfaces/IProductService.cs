using CognitoDemo.Application.DTOs.Products;

namespace CognitoDemo.Application.Interfaces;

public interface IProductService
{
    Task<IQueryable<ProductDto>> GetAllAsync();
    // Task<Product> GetByIdAsync(int id);
    // Task<Product> CreateAsync(Product product);
    Task<ProductDto> CreateAsync(CreateProductDto model);
}