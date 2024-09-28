using Domain.Entites;

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
        public int TeamId { get; set; }
        public Team Team { get; }
    }
}
