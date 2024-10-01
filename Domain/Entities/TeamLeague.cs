using Domain.Entites;

namespace Domain.Entities
{
    public class TeamLeague
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; }
        public int LeagueId { get; set; }
        public League League { get; }
    }
}
