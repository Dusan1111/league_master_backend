using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        // public List<SeasonLeague> SeasonLeagues { get; }
    }
}