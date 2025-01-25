﻿using CognitoDemo.Domain.Common;

namespace CognitoDemo.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; } = string.Empty;
}