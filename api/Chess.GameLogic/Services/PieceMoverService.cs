using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Services
{
    internal class PieceMoverService : IPieceMoverService
    {
        private readonly IRunningGamesService _runningGamesService;
        private readonly IMoveValidator _moveValidator;

        public PieceMoverService(IRunningGamesService runningGamesService, IMoveValidator moveValidator)
        {
            _runningGamesService = runningGamesService;
            _moveValidator = moveValidator;
        }

        public bool TryCastl(CastlingInfo castlingInfo, string playerEmail, out GameDto gameAfterMove)
        {
            gameAfterMove = null;
            var game = _runningGamesService.GetRunningGame(castlingInfo.GameId);
            if (game == null)
                return false;

            var king = game.Pieces.First(p => p.Color == castlingInfo.KingCastlingColor && p.Name == PieceName.King);
            var rook = GetRookForCastling(castlingInfo, game.Pieces);
            if (!_moveValidator.CastlingIsValid(game, king, rook, castlingInfo, playerEmail))
                return false;

            game.Pieces.MovePiece(king, GetPosOfKingAfterCastling(king, castlingInfo));
            game.Pieces.MovePiece(rook, GetPosOfRockAfterCastling(rook, castlingInfo));

            game.ChangeMoveTurn();
            gameAfterMove = game;
            return true;
        }

        public bool TryPromotePawn(PawnPromotionInfo pawnPromotionInfo, string playerEmail, out GameDto gameAfterMove)
        {
            gameAfterMove = null;
            var game = _runningGamesService.GetRunningGame(pawnPromotionInfo.GameId);
            if (game == null)
                return false;

            var pawn = game.Pieces.GetPiece(pawnPromotionInfo.From);
            if(!_moveValidator.PawnPromotionIsValid(game, pawn, pawnPromotionInfo.To, pawnPromotionInfo.PromotionToPiece, playerEmail))
                return false;

            game.Pieces.PromotePawn(pawn, pawnPromotionInfo.To, pawnPromotionInfo.PromotionToPiece);

            game.ChangeMoveTurn();
            gameAfterMove = game; 
            return true;
        }

        public bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out GameDto gameAfterMove)
        {
            gameAfterMove = null;
            var game = _runningGamesService.GetRunningGame(pieceMoveInfo.GameId);
            if (game is null)
                return false;

            var pieces = game.Pieces;
            var piece = pieces.GetPiece(pieceMoveInfo.From);

            if (piece is null || !_moveValidator.MoveIsValid(game, piece, pieceMoveInfo.To, playerEmail))
                return false;

            game.Pieces.MovePiece(piece, pieceMoveInfo.To);
            game.ChangeMoveTurn();
            gameAfterMove = game;
            return true;
        }

        private PieceDto GetRookForCastling(CastlingInfo castlingInfo, List<PieceDto> pieces)
        {
            int posX = 1;
            int posY = 1;

            if (castlingInfo.CastlingDirection == CastlingDirection.Short)
                posX = 8;

            if (castlingInfo.KingCastlingColor == Color.Black) 
                posY = 8;

            return pieces.GetPiece(new PiecePositionDto(posY, posX));
        }

        private PiecePositionDto GetPosOfKingAfterCastling(PieceDto king, CastlingInfo castlingInfo)
        {
            if (castlingInfo.CastlingDirection == CastlingDirection.Short)
                return king.Position with { PosX = king.Position.PosX + 2 };

            return king.Position with { PosX = king.Position.PosX - 2 };
        }

        private PiecePositionDto GetPosOfRockAfterCastling(PieceDto rook, CastlingInfo castlingInfo)
        {
            if (castlingInfo.CastlingDirection == CastlingDirection.Short)
                return rook.Position with { PosX = rook.Position.PosX - 2 };

            return rook.Position with { PosX = rook.Position.PosX + 3 };
        }
    }
}
