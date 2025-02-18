using CognitoDemo.API.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CognitoDemo.API.Controllers
{
    public class AuthController : BaseController
    {
        public Task Login([FromBody] LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Register([FromBody] UserRegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
