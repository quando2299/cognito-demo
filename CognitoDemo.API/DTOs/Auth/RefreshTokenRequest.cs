﻿namespace CognitoDemo.API.DTOs.Auth
{
    public class RefreshTokenRequest
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
