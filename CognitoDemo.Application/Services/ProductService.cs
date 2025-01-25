using AutoMapper;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.Application.Services;

public class ProductService(IRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    : IProductService
{
    public Task<IQueryable<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto model)
    {
        var product = mapper.Map<Product>(model);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangeAsync();
        
        return mapper.Map<ProductDto>(product);
    }
}