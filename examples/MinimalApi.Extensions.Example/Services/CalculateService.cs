using MinimalApi.Extensions.Abstractions.Attributes;
using MinimalApi.Extensions.Example.Abstractions.Services;

namespace MinimalApi.Extensions.Example.Services;

[AutoDependencyInjection(ServiceLifetime.Singleton,typeof(ICalculateService))]
internal class CalculateService : ICalculateService
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Div(double a, double b)
    {
        return a / b;
    }

    public double Mul(double a, double b)
    {
        return a * b;
    }

    public double Sub(double a, double b)
    {
        return a - b;
    }
}
