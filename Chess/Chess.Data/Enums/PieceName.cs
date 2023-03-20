using System.Text.Json.Serialization;

namespace Chess.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PieceName
    {
        King,
        Queen,
        Knight,
        Bishop,
        Pawn,
        Rook,
    }
}
