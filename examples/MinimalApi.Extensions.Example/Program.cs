using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Example.Services;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AutoRegisterAllServices();

var app = builder.Build();

app.MapGet("/greet", ([FromServices] IGreetService greetService, string name) =>
{
    return Results.Ok(greetService.SayHello(name));
});

app.Run();


[JsonSerializable(typeof(string))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
