using Domain.Core.Enums;
using Domain.Entites;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SeasonLeague
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public int NumberOfRounds { get; set; }
        public int NumberOfPlayOffRounds { get; set; }
        public CompetitionStatusEnum Status { get; set; }
        
        public List<TeamLeague> TeamLeagues { get; set; }
    }
}
