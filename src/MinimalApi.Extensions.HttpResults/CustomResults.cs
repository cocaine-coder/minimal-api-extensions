using Microsoft.AspNetCore.Http;

namespace MinimalApi.Extensions.HttpResults;

public partial class CustomResults {

    public static IResult Ok(object data)
    {
        return Results.Ok(HttpResultModel.Ok(data));
    }

    public static IResult Bad(object? error)
    {
        return Results.Ok(HttpResultModel.Bad(error));
    }
}