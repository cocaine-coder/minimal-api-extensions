using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Example.Services;
using MinimalApi.Extensions.HttpResults;
using MinimalApi.Extensions.Scalar;
using MinimalApi.Extensions.Security;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, MiminalApiJsonSerializerContext.Default);
});

builder.Services.AddJwtBearer(new CustomJwtBearerOptions() { SecretKey = "forbidden_watch_123123asdfasfsafsadfsfsa" });
builder.Services.AddScalar(o => { o.UseJwtBearer = true; });

builder.Services.AutoRegisterAllServices();

var app = builder.Build();

app.MapGet("/greet", ([FromServices] IGreetService greetService, string name) =>
{
    return Results.Ok(greetService.SayHello(name));
}).RequireAuthorization();

app.MapPost("login", ([FromServices] IJwtTokenGenerator jwtTokenGenerator) =>
{
    return TypedResults.Extensions.Ok(jwtTokenGenerator.GenerateToken());
}).Produces<JwtTokenResponse>();

app.MapGet("json", () =>
{
    return TypedResults.Ok("123123");
});

app.MapScalar();

app.Run();