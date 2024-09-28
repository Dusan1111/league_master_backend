using Domain.Entites;

namespace Domain.Entities
{
    public class PlayerMatch
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }   
        public Player Player { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}