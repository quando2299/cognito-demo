using CognitoDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognitoDemo.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(199);
        builder.Property(p => p.Price).HasPrecision(18, 2);
        builder.Property(p => p.Description).HasMaxLength(999).IsRequired(false);
    }
}