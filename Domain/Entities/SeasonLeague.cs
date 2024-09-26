using Domain.Entites;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SeasonLeague
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; }
        public int LeagueId { get; set; }
        public League League { get; }
        public string RoundName { get; set; }
        public List<Team> Teams { get; set; }
    }
}
