using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int JerseyNumber { get; set; }
        public int SuspendedFromRound { get; set; }
        public int SuspendedUntilRound { get; set; }

        public List<PlayerTeam> PlayerTeams { get; }
        public List<PlayerMatch> PlayerMatches { get; set; }
    }
}