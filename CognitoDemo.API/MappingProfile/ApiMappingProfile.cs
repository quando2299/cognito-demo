using AutoMapper;
using CognitoDemo.API.DTOs.Auth;
using CognitoDemo.API.DTOs.Products;
using CognitoDemo.Application.DTOs.Auth;
using CognitoDemo.Application.DTOs.Products;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.API.MappingProfile;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Product
        CreateMap<ProductCreateRequest, ProductCreateDto>();
        CreateMap<ProductDto, ProductResponse>();
        CreateMap<ProductDetailDto, ProductDetailResponse>();
        CreateMap<ProductDetailDto, ProductCreateResponse>();

        // Auth
        CreateMap<LoginRequest, LoginRequestDto>();
        CreateMap<UserRegisterRequest, UserRegisterRequestDto>();
        CreateMap<RefreshTokenRequest, RefreshTokenRequestDto>();
    }
}