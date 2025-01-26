using CognitoDemo.Core.Interfaces;

namespace CognitoDemo.Core.Models;

public class Paginate<T> : IPaginate<T>
{
    public IReadOnlyList<T> Items { get; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }

    public Paginate(IReadOnlyList<T> items, int count, int pageIndex, int pageSize)
    {
        this.Items = items;
        this.TotalCount = count;
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }
}