using AutoMapper;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Core.Extensions;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Core.Models;
using CognitoDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CognitoDemo.Application.Services;

public class ProductService(IRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    : IProductService
{
    public async Task<IPaginate<ProductDto>> GetAllAsync(int pageIndex = 1, int pageSize = 10)
    {
        var query = productRepository.TableNoTracking;
        var products = await query.ToPaginateAsync(pageIndex, pageSize);
        
        var dtos = mapper.Map<List<ProductDto>>(products.Items);
        return new Paginate<ProductDto>(dtos, products.TotalCount, pageIndex, pageSize);
    }

    public async Task<ProductDetailDto> CreateAsync(ProductCreateDto model)
    {
        await unitOfWork.BeginTransactionAsync();
        var product = mapper.Map<Product>(model);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangeAsync();

        var response = mapper.Map<ProductDetailDto>(product);

        await unitOfWork.CommitTransactionAsync();

        return response;
    }

    public async Task<ProductDetailDto?> GetDetailAsync(Guid id)
    {
        var query = await productRepository.TableNoTracking.Where(m => m.Id == id).FirstOrDefaultAsync();

        if (query == null) return null;

        var model = mapper.Map<ProductDetailDto>(query);

        return model;
    }
}