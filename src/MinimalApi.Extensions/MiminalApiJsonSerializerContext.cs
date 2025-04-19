using MinimalApi.Extensions.HttpResults;
using MinimalApi.Extensions.Security;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions;

[JsonSerializable(typeof(HttpResultModel))]
[JsonSerializable(typeof(JwtTokenResponse))]
public partial class MiminalApiJsonSerializerContext : JsonSerializerContext
{
}