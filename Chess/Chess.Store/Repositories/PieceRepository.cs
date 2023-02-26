using Chess.Data.Enums;
using Chess.Data.Interfaces;
using Chess.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Store.Repositories
{
    public class PieceRepository : IPieceRepository
    {
        private readonly ChessContext _db;

        public PieceRepository(ChessContext db)
        {
            _db = db;
        }

        public Task AddPieceToGame(PieceDto pieceInGame)
        {
            if(pieceInGame.GameId == default)
            {
                throw new ArgumentException("GameId field of pieceInGame must ne seted");
            }

            throw new NotImplementedException();
        }

        public Task MovePiece(PieceDto pieceInGame, Guid gameId, HorizontalPosition horizontalPosition, int verticalPosition)
        {
            throw new NotImplementedException();
        }

        public Task RemovePieceFromGame(Guid gameId, HorizontalPosition horizontalPosition, int verticalPosition)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePiece(PieceDto pieceInGame, Guid gameId, HorizontalPosition horizontalPosition, int verticalPosition)
        {
            var pieceToUpdate = await _db.PiecesInGames
                .FirstOrDefaultAsync(c => c.GameId == gameId && c.HorizontalPosition == horizontalPosition && c.VerticalPosition == verticalPosition);

            if(pieceToUpdate == null)
            {
                throw new ArgumentException("Invalid key params");
            }

            _db.Remove(pieceToUpdate);
            _db.Add(new PieceDto
            {
                GameId = gameId,
                HorizontalPosition = horizontalPosition,
                VerticalPosition = verticalPosition,
                Color = pieceToUpdate.Color,
                Name = pieceToUpdate.Name,
            });

            await _db.SaveChangesAsync();
        }
    }
}
