﻿namespace CognitoDemo.API.DTOs.Products
{
    public record ProductResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
