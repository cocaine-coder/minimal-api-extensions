using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.Attributes
{

    [AttributeUsage(AttributeTargets.Class)]
    public class AutoDependencyInjectionAttribute(ServiceLifetime lifetime, Type? interfaceType = null) : Attribute
    {
        public ServiceLifetime Lifetime { get; private set; } = lifetime;

        public Type? InterfaceType { get; private set; } = interfaceType;
    }
}
