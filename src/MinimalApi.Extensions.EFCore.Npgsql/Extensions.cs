using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System.Text.Json;

namespace MinimalApi.Extensions.EFCore.Npgsql;

public static class Extensions
{
    public static NpgsqlDbContextOptionsBuilder ConfigureJson(
        this NpgsqlDbContextOptionsBuilder builder,
        bool enableDynamicJson = true,
        Action<JsonSerializerOptions>? jsonSerializerOptionsAction = default)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            AllowOutOfOrderMetadataProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        jsonSerializerOptionsAction?.Invoke(jsonSerializerOptions);

        return builder.ConfigureDataSource(ds =>
        {
            if (enableDynamicJson) ds.EnableDynamicJson();
            ds.ConfigureJsonOptions(jsonSerializerOptions);
        });
    }
}
