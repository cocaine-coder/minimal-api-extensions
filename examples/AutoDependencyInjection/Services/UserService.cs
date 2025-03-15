using MinimalApi.AutoDependencyInjection;

using AutoDependencyInjectionTest.Abstractions;

namespace AutoDependencyInjection.Services;

[AutoDependencyInjection(ServiceLifetime.Scoped, typeof(IUserService))]
public class UserService : IUserService
{
    public string GetName() => "Nick";
}