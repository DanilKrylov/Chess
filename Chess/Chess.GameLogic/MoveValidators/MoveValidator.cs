using Chess.Data.Enums;
using Chess.Data.Models;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
