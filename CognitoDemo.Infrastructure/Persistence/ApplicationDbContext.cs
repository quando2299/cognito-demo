using CognitoDemo.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CognitoDemo.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly IEnumerable<Type> _entityTypes;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Get all types from Domain assembly that inherit from BaseEntity
        _entityTypes = typeof(BaseEntity).Assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && t.IsClass && t.IsSubclassOf(typeof(BaseEntity)));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dynamically register all entities
        foreach (var type in _entityTypes)
        {
            modelBuilder.Entity(type);
        }

        // Apply configurations from separate configuration classes
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    // Override SaveChanges to handle CreatedAt and UpdatedAt
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = null;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    // Optional: Add a generic method to get DbSet
    public DbSet<T> GetDbSet<T>() where T : BaseEntity
    {
        return Set<T>();
    }
}