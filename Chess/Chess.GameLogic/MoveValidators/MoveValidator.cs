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

        public MoveValidator(IMoveInAvailableCagesValidator availableCagesValidator, ICheckAfterMoveValidator checkValidator, IBasicMoveValidator basicValidator)
        {
            _availableCagesValidator = availableCagesValidator;
            _checkValidator = checkValidator;
            _basicValidator = basicValidator;
        }

        public bool MoveIsValid(GameDto game, PieceDto piece, PiecePositionDto to, string playerEmail)
        {
            return _basicValidator.IsMoveValidOnEmptyBoard(game, piece.Position, to, playerEmail) &&
                    _availableCagesValidator.IsMoveInAvailableCages(game.Pieces, piece.Position, to) &&
                   !_checkValidator.IsCheckAfterMove(game.Pieces, piece, to);
        }
    }
}
