using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;

namespace MinimalApi.Extensions.HttpResults;

public class Custom200OkResult<T>(T? data) : IResult, IEndpointMetadataProvider
{
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status200OK, typeof(T), ["application/json"]));
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var dataStr = "null";

        if (data is not null)
        {
            var jsonSerializerOptions = httpContext.RequestServices.GetService<IOptions<JsonOptions>>()!.Value.SerializerOptions;
            dataStr = JsonSerializer.Serialize(data, jsonSerializerOptions.GetTypeInfo(typeof(T)));
        }

        httpContext.Response.StatusCode = StatusCodes.Status200OK;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync($$"""{"success":true,"data":{{dataStr}}}""");
    }
}

public class Custom200BadResult(string error) : IResult, IEndpointMetadataProvider
{
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status200OK, typeof(string), ["application/json"]));
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status200OK;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync($$"""{"success":false,"error":{{error}}}""");
    }
}

public class Custom200BadWithCodeResult(int code, string error) : IResult, IEndpointMetadataProvider
{
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status200OK, typeof(string), ["application/json"]));
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status200OK;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync($$"""{"success":false,"code":{{code}},"error":{{error}}}""");
    }
}