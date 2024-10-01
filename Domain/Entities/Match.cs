using Domain.Entities;
using System;

namespace Domain.Entites
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }
        public int MatchLocationId { get; set; }
        public MatchLocation MatchLocation { get; set; }
    }
}