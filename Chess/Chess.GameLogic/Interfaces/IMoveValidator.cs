using Chess.Data.Enums;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IMoveValidator
    {
        bool MoveIsValid(GameDto game, PieceDto piece, PiecePositionDto to, string playerEmail);

        bool CastlingIsValid(GameDto game, PieceDto king, PieceDto rook, CastlingInfo castlingInfo, string playerEmail);

        bool PawnPromotionIsValid(GameDto game, PieceDto piece, PiecePositionDto to, PieceName promotionTo, string playerEmail);
    }
}
