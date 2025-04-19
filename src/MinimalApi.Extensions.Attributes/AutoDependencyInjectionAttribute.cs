using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.Attributes
{

    [AttributeUsage(AttributeTargets.Class)]
    public class AutoDependencyInjectionAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; private set; }

        public Type InterfaceType { get; private set; }

        public AutoDependencyInjectionAttribute(ServiceLifetime lifetime, Type interfaceType = null)
        {
            Lifetime = lifetime;
            InterfaceType = interfaceType;
        }
    }
}
