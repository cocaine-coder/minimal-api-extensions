using Microsoft.AspNetCore.Http;

namespace MinimalApi.Extensions.HttpResults;

public static class Extensions
{
    public static Custom200OkResult<T> Ok<T>(this IResultExtensions resultExtensions, T? data = default)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return new Custom200OkResult<T>(data);
    }

    public static Custom200OkResult<object?> Ok(this IResultExtensions resultExtensions)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return new Custom200OkResult<object?>(null);
    }

    public static Custom200BadResult Bad(this IResultExtensions resultExtensions, string error)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return new Custom200BadResult(error);
    }
}