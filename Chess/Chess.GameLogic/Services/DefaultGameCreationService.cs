using Chess.Data.Enums;
using Chess.Data.Interfaces;
using Chess.Data.Models;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Services
{
    internal class DefaultGameCreationService : IGameCreationService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRunningGamesService _runningGamesService;
        private readonly UserManager<Player> _userManager;

        public DefaultGameCreationService(IGameRepository gameRepository, IRunningGamesService runningGamesService, UserManager<Player> userManager)
        {
            _gameRepository = gameRepository;
            _runningGamesService = runningGamesService;
            _userManager = userManager;
        }

        public async Task<GameDto> StartNewGameAsync(string whitePlayerEmail, string blackPlayerEmail)
        {
            var pieces = new List<Piece>();

            AddPawnsToDefaultPositions(pieces);
            AddRocksToDefaultPositions(pieces);
            AddKnightsToDefaultPositions(pieces);
            AddBishopsToDefaultPositions(pieces);
            AddKingsToDefaultPositions(pieces);
            AddQueensToDefaultPositions(pieces);

            var game = new Game()
            {
                BlackPlayer = await _userManager.FindByEmailAsync(whitePlayerEmail),
                WhitePlayer = await _userManager.FindByEmailAsync(blackPlayerEmail),
                Pieces = pieces,
                MoveTurn = Color.White,
            };

            await _gameRepository.AddGameAsync(game);
            var pieceDtos = pieces.Select(c => new PieceDto(new PiecePositionDto(c.VerticalPosition, c.HorizontalPosition), c.Color, c.Name)).ToList();
            var gameDto = new GameDto(game.GameId, game.WhitePlayer.Email, game.BlackPlayer.Email, pieceDtos);
            _runningGamesService.TryAddRunningGame(gameDto);

            return gameDto;
        }

        private static void AddPawnsToDefaultPositions(List<Piece> pieceList)
        {
            foreach (var horizontalPosition in Enumerable.Range(1,8))
            {
                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 2,
                    Name = PieceName.Pawn,
                    Color = Color.White,
                });

                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 7,
                    Name = PieceName.Pawn,
                    Color = Color.Black,
                });
            }
        }

        private static void AddRocksToDefaultPositions(List<Piece> pieceList)
        {
            foreach (var horizontalPosition in new int[] { 1, 8 })
            {
                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Rock,
                    Color = Color.White,
                });

                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Rock,
                    Color = Color.Black,
                });
            }
        }

        private static void AddKnightsToDefaultPositions(List<Piece> pieceList)
        {
            foreach (var horizontalPosition in new int[] { 2, 7 })
            {
                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Knight,
                    Color = Color.White,
                });

                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Knight,
                    Color = Color.Black,
                });
            }
        }

        private static void AddBishopsToDefaultPositions(List<Piece> pieceList)
        {
            foreach (var horizontalPosition in new int[] { 3, 6})
            {
                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Bishop,
                    Color = Color.White,
                });

                pieceList.Add(new Piece()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Bishop,
                    Color = Color.Black,
                });
            }
        }

        private static void AddKingsToDefaultPositions(List<Piece> pieceList)
        {
            pieceList.Add(new Piece()
            {
                HorizontalPosition = 5,
                VerticalPosition = 1,
                Name = PieceName.King,
                Color = Color.White,
            });

            pieceList.Add(new Piece()
            {
                HorizontalPosition = 5,
                VerticalPosition = 8,
                Name = PieceName.King,
                Color = Color.Black,
            });
        }

        private static void AddQueensToDefaultPositions(List<Piece> pieceList)
        {
            pieceList.Add(new Piece()
            {
                HorizontalPosition = 4,
                VerticalPosition = 1,
                Name = PieceName.Queen,
                Color = Color.White,
            });

            pieceList.Add(new Piece()
            {
                HorizontalPosition = 4,
                VerticalPosition = 8,
                Name = PieceName.Queen,
                Color = Color.Black,
            });
        }
    }
}
