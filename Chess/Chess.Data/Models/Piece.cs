using Chess.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Data.Models
{
    public class Piece
    {
        public Guid GameId { get; set; }

        public int HorizontalPosition { get; set; }

        public int VerticalPosition { get; set; }

        public PieceName Name { get; set; }

        public Color Color { get; set; }
    }
}
