using Chess.Data.Enums;
using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Data.Interfaces
{
    public interface IPieceRepository
    {
        Task AddPieceToGame(PieceInGame pieceInGame);

        Task RemovePieceFromGame(Guid gameId, HorizontalPosition horizontalPosition, int verticalPosition);

        Task MovePiece(PieceInGame pieceInGame, Guid gameId, HorizontalPosition horizontalPosition, int verticalPosition);
    }
}
