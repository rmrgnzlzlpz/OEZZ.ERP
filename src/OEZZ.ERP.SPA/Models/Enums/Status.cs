using System.Text.Json.Serialization;

namespace OEZZ.ERP.SPA.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Active,
    Deleted
}