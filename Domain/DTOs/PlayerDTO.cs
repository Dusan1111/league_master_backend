namespace Domain.DTOs
{
    public class PlayerCreateDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int LeagueId { get; set; }
        public int TeamId { get; set; }
    }
}
