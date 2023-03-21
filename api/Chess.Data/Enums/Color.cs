using System.Text.Json.Serialization;

namespace Chess.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Color
    {
        White,
        Black,
    }

    public static class ColorExtensions
    {
        public static Color GetOpposite(this Color color)
        {
            if(color == Color.Black) 
                return Color.White;

            return Color.Black;
        }
    }
}
