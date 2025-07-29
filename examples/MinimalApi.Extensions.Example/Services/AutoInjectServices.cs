using MinimalApi.Extensions.Attributes;

namespace MinimalApi.Extensions.Example.Services
{
    [AutoDependencyInjection(ServiceLifetime.Scoped, Key = "test")]
    public class KeyedScopedService { }

    [AutoDependencyInjection(ServiceLifetime.Scoped, Key = "try-test", UseTry = true)]
    public class TryKeyedScopedService { }

    public interface IMultiService1 { }
    public interface IMultiService2 { }

    [AutoDependencyInjection(ServiceLifetime.Scoped, InterfaceTypes = [typeof(IMultiService1), typeof(IMultiService2)])]
    public class MultiService : IMultiService1 , IMultiService2;
}
