using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.MoveValidators
{
    internal class MoveValidator : IMoveValidator
    {
        private readonly IMoveInAvailableCagesValidator _availableCagesValidator;
        private readonly ICheckAfterMoveValidator _checkValidator;
        private readonly IBasicMoveValidator _basicValidator;
        private readonly ICheckDetector _checkDetector;

        public MoveValidator(IMoveInAvailableCagesValidator availableCagesValidator, ICheckAfterMoveValidator checkValidator, IBasicMoveValidator basicValidator, ICheckDetector checkDetector)
        {
            _availableCagesValidator = availableCagesValidator;
            _checkValidator = checkValidator;
            _basicValidator = basicValidator;
            _checkDetector = checkDetector;
        }

        public bool MoveIsValid(GameDto game, PieceDto piece, PiecePositionDto to, string playerEmail)
        {
            return _basicValidator.IsMoveValidOnEmptyBoard(game, piece.Position, to, playerEmail) &&
                    _availableCagesValidator.IsMoveInAvailableCages(game.Pieces, piece.Position, to) &&
                   !_checkValidator.IsCheckAfterMove(game.Pieces, piece, to);
        }

        public bool CastlingIsValid(GameDto game, PieceDto king, PieceDto rook, CastlingInfo castlingInfo, string playerEmail)
        {
            if (rook is null || king is null || rook.Name != PieceName.Rook || rook.IsMoved || king.IsMoved)
                return false;

            if (_checkDetector.IsCheckInPosition(game.Pieces, king.Color))
                return false;


            var cagesForKingMove = GetCagesThatMustNotBeAttakedForCastling(king, castlingInfo);

            foreach (var cage in cagesForKingMove)
            {
                if (game.Pieces.PieceExists(cage) || _checkValidator.IsCheckAfterMove(game.Pieces, king, cage))
                    return false;
            }

            return true;
        }

        public bool PawnPromotionIsValid(GameDto game, PieceDto pawn, PiecePositionDto to, PieceName promotionTo, string playerEmail)
        {
            return pawn is not null && MoveIsValid(game, pawn, to, playerEmail) &&
                   pawn.Position.PosY == GetPrepromotePosY(pawn.Color) &&
                   IsPromotionToAvailablePiece(promotionTo);
        }

        private List<PiecePositionDto> GetCagesThatMustNotBeAttakedForCastling(PieceDto king, CastlingInfo castlingInfo)
        {
            var cages = new List<PiecePositionDto>();

            if (castlingInfo.CastlingDirection == CastlingDirection.Short)
            {
                cages.Add(king.Position with { PosX = king.Position.PosX + 1 });
                cages.Add(king.Position with { PosX = king.Position.PosX + 2 });
            }
            else
            {
                cages.Add(king.Position with { PosX = king.Position.PosX - 1 });
                cages.Add(king.Position with { PosX = king.Position.PosX - 2 });
            }

            return cages;
        }

        private bool IsPromotionToAvailablePiece(PieceName promotionTo)
        {
            return promotionTo == PieceName.Queen || promotionTo == PieceName.Knight ||
                   promotionTo == PieceName.Bishop || promotionTo == PieceName.Rook;
        }

        private int GetPrepromotePosY(Color color)
        {
            return color == Color.White ? 7 : 2;
        }
    }
}
