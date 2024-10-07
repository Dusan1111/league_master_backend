namespace Domain.DTOs
{
    public class TeamCreateDTO
    {
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public byte[]? LogoImage { get; set; }
        public int SeasonLeagueId { get; set; }
    }
}
