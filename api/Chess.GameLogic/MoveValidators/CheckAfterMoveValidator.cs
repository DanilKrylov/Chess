using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.MoveValidators
{
    internal class CheckAfterMoveValidator : ICheckAfterMoveValidator
    {
        private readonly ICheckDetector _checkDetector;

        public CheckAfterMoveValidator(ICheckDetector checkDetector)
        {
            _checkDetector = checkDetector;
        }

        public bool IsCheckAfterMove(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto newPosition)
        {
            var piecesWithMovedCurrentPiece = piecesBeforeMove
                .GetPiecesWithMovedPiece(piece.Position, newPosition);

            return _checkDetector.IsCheckInPosition(piecesWithMovedCurrentPiece, piece.Color);
        }
    }
}
