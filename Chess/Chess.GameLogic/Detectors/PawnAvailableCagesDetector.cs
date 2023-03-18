using Chess.Data.Enums;
using Chess.Data.Models;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class PawnAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        public PieceName PieceName => PieceName.Pawn;

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var piece = pieces.GetPiece(position);
            if(piece is null)
            {
                throw new ArgumentException("piece does not exist");
            }

            var colorKoef = piece.Color == Color.White ? 1 : -1;
            var (vertPos, horPos) = position;
            var availableCages = new List<PiecePositionDto>();
            var checkingPos = new PiecePositionDto(vertPos + 1 * colorKoef, horPos);

            if (!pieces.PieceExists(checkingPos))
            {
                availableCages.Add(checkingPos);
                checkingPos = new PiecePositionDto(vertPos + 2 * colorKoef, horPos);
                if (vertPos == GetPawnVerticalStartPos(piece.Color) && !pieces.PieceExists(checkingPos))
                {
                    availableCages.Add(checkingPos);
                }
            }

            if (horPos != 1)
            {
                checkingPos = new PiecePositionDto(vertPos + 1 * colorKoef, horPos - 1);
                AddAvailableCageIfPieceColorIsOposite(checkingPos, pieces, availableCages, piece.Color);
            }

            if (horPos != 8)
            {
                checkingPos = new PiecePositionDto(vertPos + 1 * colorKoef, horPos + 1);
                AddAvailableCageIfPieceColorIsOposite(checkingPos, pieces, availableCages, piece.Color);
            }

            return availableCages;
        }

        private int GetPawnVerticalStartPos(Color color)
        {
            if (color == Color.White)
                return 2;

            return 7;
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
