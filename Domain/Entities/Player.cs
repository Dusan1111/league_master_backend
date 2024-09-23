using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
     //   public string Position { get; set; }
    //    public int JerseyNumber { get; set; }
     //   public byte[] Image { get; set; }
        public int? NumberOfYellowCards { get; set; }
        public int? NumberOfRedCards { get; set; }
        public int? NumberOfTotalYellowCards { get; set; }
        public int? NumberOfTotalRedCards { get; set; }
        public int? NumberOfGoals { get; set; }
        public int? NumberOfAssists { get; set; }
        public int SuspendedFromRound { get; set; }
        public int SuspendedUntilRound { get; set; }
        public List<PlayerTeam> PlayerTeams { get; }
        public List<Team> Teams { get; }
        public Player()
        {

        }
    }
}