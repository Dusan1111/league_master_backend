using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LeagueStandingRecordDTO
    {
        //public int Id { get; set; }
        public int LeaguePosition { get; set; }
        public int ScoredGoals { get; set; }
        public int ReceivedGoals { get; set; }
        public int GoalsDifference { get; set; }
        public int NumberOfGamesPlayed { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }
        public int NumberOfDraws { get; set; }
        public int TotalPoints { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
