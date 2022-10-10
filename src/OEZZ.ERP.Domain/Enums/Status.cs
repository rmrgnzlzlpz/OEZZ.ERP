using System.Text.Json.Serialization;

namespace OEZZ.ERP.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Active,
    Deleted
}