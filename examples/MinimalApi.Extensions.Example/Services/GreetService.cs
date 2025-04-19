using MinimalApi.Extensions.Attributes;

namespace MinimalApi.Extensions.Example.Services;

public interface IGreetService
{
    string SayHello(string name);
}

[AutoDependencyInjection(ServiceLifetime.Singleton, typeof(IGreetService))]
internal class GreetService : IGreetService
{
    public string SayHello(string name)
    {
        return $"你好，{name}";
    }
}
