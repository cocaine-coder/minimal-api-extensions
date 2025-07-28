using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AutoDependencyInjectionAttribute(
    ServiceLifetime lifetime,
    Type? interfaceType = null,
    string? key = null,
    bool useTry = false
) : Attribute
{
    public ServiceLifetime Lifetime { get; } = lifetime;

    public Type? InterfaceType { get; } = interfaceType;

    public string? Key { get; } = key;

    public bool UseTry { get; } = useTry;
}
