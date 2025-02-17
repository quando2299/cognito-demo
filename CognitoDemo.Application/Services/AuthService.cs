using AutoMapper;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Domain.Entities;

namespace CognitoDemo.Application.Services
{
    public class AuthService(IRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper) : IAuthService
    {

    }
}
