using MinimalApi.Extensions.Attributes;

namespace MinimalApi.Extensions.Example.Services
{
    public interface IKeyedTestService { }

    [AutoDependencyInjection(ServiceLifetime.Scoped, key: "test")]
    public class KeyedTestService { }
}
