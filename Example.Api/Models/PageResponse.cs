using ExampleApi.Core;

namespace Example.Api.Models;

/// <summary>
/// PageResponse is a generic class that represents a paginated response for API calls.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PageResponse<T> : Pagination<T>, IApiResponse where T : class, IApiResponse
{
}

/// <summary>
/// PaginationExtensions is a static class that contains extension methods for the Pagination class.
/// </summary>
public static class PaginationExtensions
{
    /// <summary>
    /// Converts a Pagination object to a PageResponse object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <param name="pagination"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static PageResponse<TOut> ToPageResponse<T, TOut>(this Pagination<T> pagination, Func<T, TOut> selector) where T : class where TOut : class, IApiResponse
    {
        return new PageResponse<TOut>()
        {
            Items = pagination.Items.Select(selector).ToList(),
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            TotalItem = pagination.TotalItem,
        };
    }
}
