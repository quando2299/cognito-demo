using CognitoDemo.Core.Interfaces;
using CognitoDemo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CognitoDemo.Core.Extensions;

public static class QueryableExtensions
{
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int pageIndex,
        int pageSize)
    {
        // Only get count up to pageSize + 1 to determine if next page exists
        var items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize + 1)
            .ToListAsync();

        var hasNext = items.Count > pageSize;
        if (hasNext) items.RemoveAt(pageSize);

        // If you need exact total count (optional):
        // var totalCount = await source.CountAsync();
        
        // Estimate total count based on current page
        var totalCount = (pageIndex - 1) * pageSize + items.Count;
        if (hasNext) totalCount += 1;

        return new Paginate<T>(items, totalCount, pageIndex, pageSize);
    }
}