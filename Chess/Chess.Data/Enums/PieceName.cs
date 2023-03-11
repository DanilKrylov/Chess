using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        Rock,
    }
}
