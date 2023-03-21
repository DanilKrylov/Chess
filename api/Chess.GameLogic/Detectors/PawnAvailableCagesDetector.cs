using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class PawnAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        public PieceName PieceName => PieceName.Pawn;

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PieceDto piece)
        {
            var colorKoef = piece.Color == Color.White ? 1 : -1;
            var (posY, posX) = piece.Position;
            var availableCages = new List<PiecePositionDto>();
            var checkingPos = new PiecePositionDto(posY + 1 * colorKoef, posX);

            if (!pieces.PieceExists(checkingPos))
            {
                availableCages.Add(checkingPos);
                checkingPos = new PiecePositionDto(posY + 2 * colorKoef, posX);
                if (!piece.IsMoved && !pieces.PieceExists(checkingPos))
                {
                    availableCages.Add(checkingPos);
                }
            }

            if (posX != 1)
            {
                checkingPos = new PiecePositionDto(posY + 1 * colorKoef, posX - 1);
                AddAvailableCageIfPieceColorIsOposite(checkingPos, pieces, availableCages, piece.Color);
            }

            if (posX != 8)
            {
                checkingPos = new PiecePositionDto(posY + 1 * colorKoef, posX + 1);
                AddAvailableCageIfPieceColorIsOposite(checkingPos, pieces, availableCages, piece.Color);
            }

            return availableCages;
        }

        private void AddAvailableCageIfPieceColorIsOposite(PiecePositionDto checkingPos, IEnumerable<PieceDto> pieces, List<PiecePositionDto> availableCages, Color pawnColor)
        {
            var checkingPiece = pieces.GetPiece(checkingPos);
            if (checkingPiece?.Color == pawnColor.GetOpposite())
            {
                availableCages.Add(checkingPos);
            }
        }
    }
}
