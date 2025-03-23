using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Extensions.Abstractions.Attributes;

namespace MinimalApi.Extensions.Example.Abstractions.Services;

public interface ICalculateService
{
    double Add(double a, double b);

    double Sub(double a, double b);

    double Mul(double a, double b);

    double Div(double a, double b);
}


[AutoDependencyInjection(ServiceLifetime.Singleton, typeof(ICalculateService))]
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