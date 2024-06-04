using System.Text.Json.Serialization;

namespace StructuredDataSamples.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Gender>))]
public enum Gender
{
    Male,
    Female
}