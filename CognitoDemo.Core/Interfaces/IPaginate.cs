namespace CognitoDemo.Core.Interfaces;

public interface IPaginate<T>
{
    IReadOnlyList<T> Items { get; }
    int PageIndex { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}