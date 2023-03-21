using Chess.Data.Models;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Mapping
{
    public static class PieceMapper
    {
        public static Piece MapToPiece(PieceDto pieceDto)
        {
            Piece piece = new Piece();
            piece.Color = pieceDto.Color;
            piece.Name = pieceDto.Name;
            piece.VerticalPosition = 
        } 
    }
}
