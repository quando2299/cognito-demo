using AutoMapper;
using CognitoDemo.API.DTOs.Products;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.API.MappingProfile;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<CreateProductRequest, CreateProductDto>();
        CreateMap<ProductDto, ProductResponse>();
    }
}