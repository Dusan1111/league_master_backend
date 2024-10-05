using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public byte[] LogoImage { get; set; }
        public List<TeamLeague> TeamLeagues { get; set; }
        public List<PlayerTeam> PlayerTeams { get; }  
    }
}