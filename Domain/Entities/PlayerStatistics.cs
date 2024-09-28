namespace Domain.Entities
{
    public class PlayerStatistics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AcquiredMinute { get; set; }

        public int StatisticalCategoryId { get; set; }
        public StatisticalCategory StatisticalCategory { get; set; }
        public int PlayerMatchId { get; set; }
        public PlayerMatch PlayerMatch { get; set; }
    }
}