using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public int? NumberOfYellowCards { get; set; }
        public int? NumberOfRedCards { get; set; }
        public int? NumberOfTotalYellowCards { get; set; }
        public int? NumberOfTotalRedCards { get; set; }
        public int? NumberOfGoals { get; set; }
        public int? NumberOfAssists { get; set; }
        public DateTime? SuspendedUntil { get; set; }
        public string Image { get; set; }
        public int JerseyNumber { get; set; }
        public List<Team> Teams { get; }

        public Player()
        {

        }
    }
}