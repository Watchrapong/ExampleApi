namespace ExampleApi.Core;

public class Pagination<T> where T : class
{
    /// <summary>
    /// Current page number
    /// </summary>
    /// <example>1</example>
    public required int Page { get; set; }

    /// <summary>
    /// Number of items per page
    /// </summary>
    /// <example>10</example>
    public required int PageSize { get; set; }

    /// <summary>
    /// List of items on the current page
    /// </summary>
    /// <typeparam name="T">Type of items</typeparam>
    public required List<T> Items { get; set; } = [];

    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    /// <example>100</example>
    public int TotalItem { get; set; }

    /// <summary>
    /// Total number of pages based on the total number of items and page size
    /// </summary>
    /// <example>10</example>
    public int TotalPage => (int)Math.Ceiling((double)TotalItem / PageSize);
}


public static class PaginationBuilder
{
    public static Pagination<T> Create<T>(int page, int pageSize, int totalItem, List<T> items) where T : class
    {
        return new Pagination<T>()
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItem = totalItem
        };
    }

    public static Pagination<TOut> Select<T, TOut>(this Pagination<T> pagination, Func<T, TOut> selector) where T : class where TOut : class
    {
        return new Pagination<TOut>()
        {
            Items = pagination.Items.Select(selector).ToList(),
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            TotalItem = pagination.TotalItem
        };
    }
}