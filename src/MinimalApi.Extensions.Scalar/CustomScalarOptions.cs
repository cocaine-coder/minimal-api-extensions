using Microsoft.OpenApi.Models;

namespace MinimalApi.Extensions.Scalar;

public class CustomScalarOptions
{
    public Action<OpenApiInfo>? OpenApiInfoAction { get; set; }

    public bool UseJwtBearer { get; set; }
}