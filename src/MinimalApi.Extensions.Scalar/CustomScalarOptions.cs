#if NET9_0
using Microsoft.OpenApi.Models;
#elif NET10_0_OR_GREATER
using Microsoft.OpenApi;
#endif

namespace MinimalApi.Extensions.Scalar;

public class CustomScalarOptions
{
    public Action<OpenApiInfo>? OpenApiInfoAction { get; set; }

    public bool UseJwtBearer { get; set; }
}