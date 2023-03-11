using AutoMapper;
using Chess.Authorize.DtoModels;
using Chess.Data.Models;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.AutomaperSetup
{
    internal class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Piece, PieceDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => new PiecePositionDto(src.VerticalPosition, src.HorizontalPosition)));

            CreateMap<Game, GameDto>()
                .ForMember(dest => dest.WhitePlayerEmail, opt => opt.MapFrom(src => src.WhitePlayer.Email))
                .ForMember(dest => dest.BlackPlayerEmail, opt => opt.MapFrom(src => src.BlackPlayer.Email))
                .ForMember(dest => dest.MoveTurn, opt => opt.MapFrom(src => src.MoveTurn))
                .ForMember(dest => dest.Pieces, opt => opt.MapFrom(src => src.Pieces.Select(p => new PieceDto(
                    new PiecePositionDto(p.HorizontalPosition, p.VerticalPosition), p.Color, p.Name))));

            CreateMap<LoginDto, Player>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
