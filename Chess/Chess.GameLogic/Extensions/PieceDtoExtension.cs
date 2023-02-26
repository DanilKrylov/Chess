using Chess.Data.Enums;
using Chess.Data.Models;
using Chess.GameLogic.DtoModels;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Extensions
{
    internal static class PieceDtoExtension
    {
        public static PieceDto GetPiece(this IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            return pieces.FirstOrDefault(piece => piece.Position == position);
        }

        public static IEnumerable<PieceDto> WithoutPiece(this IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            return pieces.Where(piece => piece.Position != position);
        }

        public static bool PieceExists(this IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            return pieces.Any(piece => piece.Position == position);
        }

        public static IEnumerable<PieceDto> GetPiecesWithMovedPiece(this IEnumerable<PieceDto> pieces, PiecePositionDto from, PiecePositionDto to)
        {
            var piece = pieces.GetPiece(from);

            if(pieces is null)
            {
                throw new ArgumentException();
            }

            var resultPieces = pieces.WithoutPiece(from).ToList();
            resultPieces.Add(piece with { Position = to });

            return resultPieces;
        }

        public static bool CanBeSetedToPosition(this IEnumerable<PieceDto> pieces, PiecePositionDto position, Color pieceColor, out bool isEnemyOnCage)
        {
            isEnemyOnCage = false;
            var pieceInCage = pieces.GetPiece(position);
            if (pieceInCage is not null)
            {
                if (pieceInCage.Color == pieceColor)
                    return false;

                isEnemyOnCage = true;
            }

            return true;
        }
    }
}
