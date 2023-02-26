using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Data.Enums
{
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
