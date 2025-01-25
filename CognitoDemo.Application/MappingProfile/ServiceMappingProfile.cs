using AutoMapper;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.Application.MappingProfile;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}