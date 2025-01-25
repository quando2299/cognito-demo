using System.Linq.Expressions;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Domain.Common;
using CognitoDemo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CognitoDemo.Infrastructure.Repositories;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = context.GetDbSet<T>();

    public IQueryable<T> Table => _dbSet;
    public IQueryable<T> TableNoTracking => _dbSet.AsNoTracking();

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
}