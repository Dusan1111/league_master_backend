using Domain.Entites;

namespace Domain.Entities
{
    public class MatchLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Match Match { get; set; }
    }
}
