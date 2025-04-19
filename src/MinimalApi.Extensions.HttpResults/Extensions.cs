using Microsoft.AspNetCore.Http;

namespace MinimalApi.Extensions.HttpResults;

public static class Extensions {

    public static Microsoft.AspNetCore.Http.HttpResults.Ok<HttpResultModel> Ok(this IResultExtensions resultExtensions, object? data = null)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return TypedResults.Ok(HttpResultModel.Ok(data));
    }

    public static Microsoft.AspNetCore.Http.HttpResults.Ok<HttpResultModel> Bad(this IResultExtensions resultExtensions, object error)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return TypedResults.Ok(HttpResultModel.Bad(error));
    }
}