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
        public List<Player> Players { get; set; }
        public ICollection<Match> Matches { get; set; }

        public Team()
        {

        }
    }
}