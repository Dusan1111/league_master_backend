using System.Collections.Generic;

namespace Domain.DTOs
{
    public class TeamCreateDTO
    {
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public byte[]? LogoImage { get; set; }
        public int SeasonLeagueId { get; set; }
    }
    public class TeamDetailsDTO
    {
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public byte[]? LogoImage { get; set; }
        public int SeasonLeagueId { get; set; }
        public int LeagueId { get; set; }
        public List<PlayerDetailsDTO> Players { get; set; }

        public List<LeagueDetailsDTO> Leagues { get; set; }
    }
}
