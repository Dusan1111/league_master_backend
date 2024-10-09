using AutoMapper;
using Domain.DTOs;
using Domain.Entites;
using System.Linq;

namespace League_Master.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<LeagueDetailsDTO, League>().ReverseMap()
                .ForMember(dest => dest.SeasonName, opt => opt
                    .MapFrom((src, dest) => src.SeasonLeagues
                        .Where(sl => sl.LeagueId == dest.Id)
                        .Select(sl => sl.Season.Name) 
                        .FirstOrDefault())); 

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
