using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class AutoDependencyInjectionAttribute(ServiceLifetime lifetime) : Attribute
{
    public ServiceLifetime Lifetime { get; } = lifetime;

    public Type[]? InterfaceTypes { get; set; }

    public string? Key { get; set; }

    public bool UseTry { get; set; }
}
