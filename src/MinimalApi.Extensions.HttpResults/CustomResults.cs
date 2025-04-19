using Microsoft.AspNetCore.Http;

namespace MinimalApi.Extensions.HttpResults;

public partial class CustomResults {

    public static Microsoft.AspNetCore.Http.HttpResults.Ok<HttpResultModel> Ok(object? data = null)
    {
        return TypedResults.Ok(HttpResultModel.Ok(data));
    }

    public static Microsoft.AspNetCore.Http.HttpResults.Ok<HttpResultModel> Bad(object error)
    {
        return TypedResults.Ok(HttpResultModel.Bad(error));
    }
}