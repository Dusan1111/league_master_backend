namespace Domain.DTOs
{
    public class LeagueCreateDTO
    {
        public string Name { get; set; }
        public int NumberOfRounds { get; set; }
    }

    public class LeagueDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
