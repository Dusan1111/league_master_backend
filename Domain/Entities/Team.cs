using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public int StandingId { get; set; }
        public Standing Standing { get; set; }
        public ICollection<Match> Matches { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public byte[] LogoImage { get; set; }
        public List<PlayerTeam> PlayerTeams { get; }
        public List<Player> Players { get; }
        public Team()
        {

        }
    }
}