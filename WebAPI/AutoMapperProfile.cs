using AutoMapper;
using Domain.Core.Enums;
using Domain.DTOs;
using Domain.Entites;
using Domain.Entities;
using System.Linq;

namespace League_Master.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompetitionRecordDTO, SeasonLeague>().ReverseMap()
             .ForMember(dest => dest.SeasonName, opt => opt.MapFrom(src => src.Season.Name))
             .ForMember(dest => dest.LeagueName, opt => opt.MapFrom(src => src.League.Name));
    
            CreateMap<SeasonRecordDTO, Season>().ReverseMap();
            
            CreateMap<LeagueDetailsDTO, League>().ReverseMap();
            CreateMap<LeagueRecordDTO, League>().ReverseMap();
            
            CreateMap<PlayerCreateDTO, Player>().ReverseMap();
            CreateMap<PlayerDetailsDTO, Player>().ReverseMap();

            CreateMap<PlayerRecordDTO, Player>().ReverseMap()
                .ForMember(dest => dest.TeamNames, opt => opt
                    .MapFrom(src => string.Join(", ", src.PlayerTeams
                        .Where(pt => pt.PlayerId == src.Id)
                        .Select(pt => pt.Team.Name))));

            CreateMap<TeamCreateDTO, Team>().ReverseMap();
            CreateMap<TeamDetailsDTO, Team>()
                .ReverseMap()
                .ForMember(dest => dest.Players, opt => opt
                    .MapFrom(src => src.PlayerTeams.Select(pt => pt.Player).ToList()))
               .ForMember(dest => dest.LeagueId, opt => opt
                    .MapFrom(src => 2 ));
        }
    }
}
