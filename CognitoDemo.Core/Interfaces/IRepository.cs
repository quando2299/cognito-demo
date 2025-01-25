using System.Linq.Expressions;
using CognitoDemo.Domain.Common;

namespace CognitoDemo.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
}