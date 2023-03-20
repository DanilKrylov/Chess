using Chess.Data.Enums;
using Chess.GameLogic.Models;

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

            if (pieces is null || piece is null)
            {
                throw new ArgumentException();
            }

            var resultPieces = pieces.WithoutPiece(from).WithoutPiece(to).ToList();
            resultPieces.Add(piece with { Position = to });

            return resultPieces;
        }

        public static void MovePiece(this List<PieceDto> pieces, PieceDto piece, PiecePositionDto to)
        {
            if (pieces is null || piece is null)
            {
                throw new ArgumentException();
            }

            pieces.RemovePieces(piece.Position, to);
            piece.SetIsMoved();
            pieces.Add(piece with { Position = to });
        }

        public static void PromotePawn(this List<PieceDto> pieces, PieceDto pawn, PiecePositionDto to, PieceName promotionTo)
        {
            pieces.RemovePieces(pawn.Position, to);
            pawn.SetIsMoved();
            pieces.Add(pawn with {  Position = to, Name = promotionTo });
        }

        public static bool CanBeSetedToPosition(this IEnumerable<PieceDto> pieces, PiecePositionDto position, Color pieceColor, out bool isEnemyOnCage)
        {
            isEnemyOnCage = false;
            if (position.PosX > 8 || position.PosX < 1 ||
                position.PosY > 8 || position.PosY < 1)
                return false;

            var pieceInCage = pieces.GetPiece(position);
            if (pieceInCage is not null)
            {
                if (pieceInCage.Color == pieceColor)
                    return false;

                isEnemyOnCage = true;
            }

            return true;
        }

        private static void RemovePieces(this List<PieceDto> pieces, params PiecePositionDto[] toRemovePositions)
        {
            foreach (var toRemovePosition in toRemovePositions)
            {
                var piece = pieces.GetPiece(toRemovePosition);
                if(piece != null)
                {
                    pieces.Remove(piece);
                }
            }
        }
    }
}
