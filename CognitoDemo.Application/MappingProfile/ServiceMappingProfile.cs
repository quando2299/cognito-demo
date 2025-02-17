using AutoMapper;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.Application.MappingProfile;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        // Product
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductDetailDto>();

        // Auth

    }
}