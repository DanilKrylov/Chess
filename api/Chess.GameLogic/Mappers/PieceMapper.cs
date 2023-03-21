using Chess.Data.Models;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Mappers
{
    internal static class PieceMapper
    {
        public static Piece MapToPiece(PieceDto pieceDto, Guid gameId)
        {
            return new Piece
            {
                Color = pieceDto.Color,
                Name = pieceDto.Name,
                PosX = pieceDto.Position.PosX,
                PosY = pieceDto.Position.PosY,
                GameId = gameId
            };
        }

        public static PieceDto MapToPieceDto(Piece piece) =>
            new PieceDto(new PiecePositionDto(piece.PosY, piece.PosX), piece.Color, piece.Name);

        public static IEnumerable<Piece> MapToPieces(IEnumerable<PieceDto> pieces, Guid gameId) =>
            pieces.Select(p => MapToPiece(p, gameId));

        public static IEnumerable<PieceDto> MapToPieceDtoes(IEnumerable<Piece> pieces) =>
            pieces.Select(p => MapToPieceDto(p));
    }
}
