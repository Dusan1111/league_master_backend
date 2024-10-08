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
            CreateMap<PlayerCreateDTO, Player>().ReverseMap();
            CreateMap<PlayerDetailsDTO, Player>().ReverseMap();

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
