namespace Domain.Entites
{
    public class Standing
    {
        public int Id { get; set; }
        public int ScoredGoals { get; set; }
        public int ReceivedGoals { get; set; }
        public int GoalsDifference { get; set; }
        public int NumberOfGamesPlayed { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }
        public int NumberOfDraws { get; set; }
        public int TotalPoints { get; set; }
        public League League { get; set; }
        public Team Team { get; set; }
    }
}