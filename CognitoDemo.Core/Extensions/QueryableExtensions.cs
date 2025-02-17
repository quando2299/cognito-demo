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
        var totalCount = await source.CountAsync();
        
        var items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new Paginate<T>(items, totalCount, pageIndex, pageSize);
    }
}