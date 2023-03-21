using System.Text.Json.Serialization;

namespace Chess.GameLogic.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CastlingDirection
    {
        Short,
        Long,
    }
}
