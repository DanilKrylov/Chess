using Chess.Data.Enums;
using Chess.Data.Models;
using GamesManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Helpers
{
    internal class DefaultGameCreator : IGameCreator
    {
        private readonly UserManager<Player> _userManager;

        public DefaultGameCreator(UserManager<Player> userManager)
        {
            _userManager = userManager;
        }


        public async Task<Game> CreateGameAsync(string whitePlayerEmail, string blackPlayerEmail)
        {
            var pieces = new List<PieceInGame>();

            AddPawnsToDefaultPositions(pieces);
            AddRocksToDefaultPositions(pieces);
            AddKnightsToDefaultPositions(pieces);
            AddBishopsToDefaultPositions(pieces);
            AddKingsToDefaultPositions(pieces);
            AddQueensToDefaultPositions(pieces);

            return new Game()
            {
                Pieces = pieces,
                WhitePlayer = await _userManager.FindByEmailAsync(whitePlayerEmail),
                BlackPlayer = await _userManager.FindByEmailAsync(blackPlayerEmail),
                MoveTurn = Color.White,
            };
        }

        private static void AddPawnsToDefaultPositions(List<PieceInGame> pieceList)
        {
            foreach (var horizontalPosition in (HorizontalPosition[])Enum.GetValues(typeof(HorizontalPosition)))
            {
                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 2,
                    Name = PieceName.Pawn,
                    Color = Color.White,
                });

                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 7,
                    Name = PieceName.Pawn,
                    Color = Color.Black,
                });
            }
        }

        private static void AddRocksToDefaultPositions(List<PieceInGame> pieceList)
        {
            foreach (var horizontalPosition in new HorizontalPosition[] { HorizontalPosition.A, HorizontalPosition.H })
            {
                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Rock,
                    Color = Color.White,
                });

                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Rock,
                    Color = Color.Black,
                });
            }
        }

        private static void AddKnightsToDefaultPositions(List<PieceInGame> pieceList)
        {
            foreach (var horizontalPosition in new HorizontalPosition[] { HorizontalPosition.B, HorizontalPosition.G })
            {
                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Knight,
                    Color = Color.White,
                });

                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Knight,
                    Color = Color.Black,
                });
            }
        }

        private static void AddBishopsToDefaultPositions(List<PieceInGame> pieceList)
        {
            foreach (var horizontalPosition in new HorizontalPosition[] { HorizontalPosition.C, HorizontalPosition.F })
            {
                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 1,
                    Name = PieceName.Bishop,
                    Color = Color.White,
                });

                pieceList.Add(new PieceInGame()
                {
                    HorizontalPosition = horizontalPosition,
                    VerticalPosition = 8,
                    Name = PieceName.Bishop,
                    Color = Color.Black,
                });
            }
        }

        private static void AddKingsToDefaultPositions(List<PieceInGame> pieceList)
        {
            pieceList.Add(new PieceInGame()
            {
                HorizontalPosition = HorizontalPosition.E,
                VerticalPosition = 1,
                Name = PieceName.King,
                Color = Color.White,
            });

            pieceList.Add(new PieceInGame()
            {
                HorizontalPosition = HorizontalPosition.E,
                VerticalPosition = 8,
                Name = PieceName.King,
                Color = Color.Black,
            });
        }

        private static void AddQueensToDefaultPositions(List<PieceInGame> pieceList)
        {
            pieceList.Add(new PieceInGame()
            {
                HorizontalPosition = HorizontalPosition.D,
                VerticalPosition = 1,
                Name = PieceName.Queen,
                Color = Color.White,
            });

            pieceList.Add(new PieceInGame()
            {
                HorizontalPosition = HorizontalPosition.D,
                VerticalPosition = 8,
                Name = PieceName.Queen,
                Color = Color.Black,
            });
        }
    }
}
