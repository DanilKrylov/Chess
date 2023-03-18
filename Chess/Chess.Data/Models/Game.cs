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
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }

        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }

        public Color MoveTurn { get; set; }

        public bool IsEnded { get; set; } = false;

        public bool IsDraw { get; set; } = false;

        public string WinnerPlayerEmail { get; set; } = string.Empty;

        public List<Piece> Pieces { get; set; }
    }
}
