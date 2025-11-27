using Newtonsoft.Json;

namespace SerilogCurrentFileNameSample.Classes.Configurations;
public static class JsonExtensions
{
    public static string ToJson<T>(this List<T> source) => JsonConvert.SerializeObject(source, Formatting.Indented);
}