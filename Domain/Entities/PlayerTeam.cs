using Domain.Entites;

namespace Domain.Entities
{
    public class PlayerTeam
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int LeagueId { get; set; }
    }
}
