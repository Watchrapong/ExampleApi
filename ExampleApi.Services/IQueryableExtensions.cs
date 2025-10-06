using System.Linq.Expressions;
using ExampleApi.Core;
using ExampleApi.Core.Dtos;
using ExampleApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Services;

public static class QueryableExtensions
{
    public static async Task<Pagination<TOut>> ToPaginationAsync<T, TOut>(this IQueryable<T> query, IPageQuery<T> pq, Expression<Func<T, TOut>> func, string? defaultOrderKey = null, SortTypes? defaultSortType = null, CancellationToken cancellationToken = default) where T : IEntity where TOut : class
    {
        query = pq.ApplyToQuery(query);

        var totalItems = query.Count();

        var items = await query
                            .ApplyOrderBy(pq, defaultOrderKey, defaultSortType)
                            .Skip((pq.Page - 1) * pq.PageSize)
                            .Take(pq.PageSize)
                            .Select(func)
                            .ToListAsync(cancellationToken);


        return PaginationBuilder.Create(pq.Page, pq.PageSize, totalItems, items);
    }

    private static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> query, IPageQuery<T> pq, string? defaultOrderKey = null, SortTypes? defaultSortType = null) where T : IEntity
    {
        var p = typeof(T)
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(pq.SortKey, StringComparison.CurrentCultureIgnoreCase));

        if (p == null)
        {
            query = defaultSortType != null && defaultSortType == SortTypes.Desc
                 ? query.OrderByDescending(p => EF.Property<string>(p, defaultOrderKey ?? nameof(IIdEntity.Id)))
                 : query.OrderBy(p => EF.Property<string>(p, defaultOrderKey ?? nameof(IIdEntity.Id)));

            return query;
        }

        query = pq.SortType == SortTypes.Desc
                 ? query.OrderByDescending(q => EF.Property<string>(q, p.Name))
                 : query.OrderBy(q => EF.Property<string>(q, p.Name));

        return query;
    }
}