using MinimalApi.Extensions.HttpResults;
using MinimalApi.Extensions.Security;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions;

[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(byte))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(float))]
[JsonSerializable(typeof(char))]
[JsonSerializable(typeof(string))]

[JsonSerializable(typeof(bool[]))]
[JsonSerializable(typeof(byte[]))]
[JsonSerializable(typeof(int[]))]
[JsonSerializable(typeof(double[]))]
[JsonSerializable(typeof(float[]))]
[JsonSerializable(typeof(char[]))]
[JsonSerializable(typeof(string[]))]

[JsonSerializable(typeof(List<bool>))]
[JsonSerializable(typeof(List<byte>))]
[JsonSerializable(typeof(List<int>))]
[JsonSerializable(typeof(List<double>))]
[JsonSerializable(typeof(List<float>))]
[JsonSerializable(typeof(List<char>))]
[JsonSerializable(typeof(List<string>))]

[JsonSerializable(typeof(HttpResultModel))]
[JsonSerializable(typeof(JwtTokenResponse))]
public partial class MiminalApiJsonSerializerContext : JsonSerializerContext
{
}