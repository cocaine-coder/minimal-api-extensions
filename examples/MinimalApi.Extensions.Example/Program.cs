using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Example.Dtos;
using MinimalApi.Extensions.Example.Services;
using MinimalApi.Extensions.HttpResults;
using MinimalApi.Extensions.Scalar;
using MinimalApi.Extensions.Security;
using MinimalApi.Extensions.Validation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddJwtBearer(new SecurityJwtBearerOptions() { SecretKey = "forbidden_watch_123123asdfasfsafsadfsfsa" });
builder.Services.AddScalar(o => { o.UseJwtBearer = true; });

builder.Services.AddAutoValidation().RegisterAllValidators();
builder.Services.AutoRegisterAllServices();

var app = builder.Build();

app.MapPost("create-cat", (Cat cat) =>
{
    return TypedResults.Extensions.Ok(cat);
}).AddValidationFilter();

app.MapGet("/greet", ([FromServices] IGreetService greetService, string name) =>
{
    return TypedResults.Ok(greetService.SayHello(name));
}).RequireAuthorization();

app.MapPost("login", ([FromServices] SecurityJwtTokenService jwtTokenService) =>
{
    return TypedResults.Extensions.Ok(jwtTokenService.GenerateToken());
});

app.MapGet("result-null", () =>
{
    bool? value = null;
    return TypedResults.Extensions.Ok(value);
});

app.MapGet("result-empty", () =>
{
    return TypedResults.Extensions.Ok();
});

app.MapGet("result-bad", () =>
{
    return TypedResults.Extensions.Bad("1223123");
});

app.MapGet("result-mul", GetResultMul);

static Results<Custom200BadResult, Custom200OkResult<int>> GetResultMul(int code)
{
    if (code == 0) return TypedResults.Extensions.Ok(123);
    else return TypedResults.Extensions.Bad("123");
}

app.MapScalar();

app.Run();

[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(Cat))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(bool?))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{

}