namespace CognitoDemo.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangeAsync();
    Task BeginTransactionAsync();
    Task RollbackTransactionAsync();
    Task CommitTransactionAsync();
}