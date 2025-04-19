using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.HttpResults;

public class HttpResultModel<T>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; init; }

    public bool Success { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Error { get; init; }

    protected HttpResultModel(bool success, T? data, object? error)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    public static HttpResultModel<T?> Bad(object error)
    {
        return new HttpResultModel<T?>(false, default, error);
    }

    public static HttpResultModel<T> Ok(T? data)
    {
        return new HttpResultModel<T>(true, data, null);
    }
}

public sealed class HttpResultModel : HttpResultModel<object>
{
    private HttpResultModel(bool success, object? data, object? error) : base(success, data, error) {}

    public new static HttpResultModel Bad(object error)
    {
        return new HttpResultModel(false, default, error);
    }

    public new static HttpResultModel Ok(object? data)
    {
        return new HttpResultModel(true, data, null);
    }
}