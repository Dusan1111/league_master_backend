namespace Domain.Entites
{
    public class Round
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }

        public Round()
        {

        }
    }
}