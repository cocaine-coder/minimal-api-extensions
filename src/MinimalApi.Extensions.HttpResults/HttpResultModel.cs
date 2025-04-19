using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.HttpResults;

public sealed class HttpResultModel
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; init; }

    public bool Success { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Error { get; init; }


    private HttpResultModel(bool success, object? data, object? error)
    {
        Data = data;
        Success = success;
        Error = error;
    }

    public static HttpResultModel Bad(object? error)
    {
        return new HttpResultModel(false, null, error);
    }

    public static HttpResultModel Ok(object? data = null)
    {
        return new HttpResultModel(true, data ?? new { }, null);
    }
}
