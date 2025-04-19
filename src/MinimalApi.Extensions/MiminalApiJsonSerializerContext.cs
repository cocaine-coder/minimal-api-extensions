using MinimalApi.Extensions.Security;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions;

[JsonSerializable(typeof(JwtTokenResponse))]
public partial class MiminalApiJsonSerializerContext : JsonSerializerContext
{
}