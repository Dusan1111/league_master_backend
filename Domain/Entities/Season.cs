using Domain.Entites;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SeasonLeague> SeasonLeagues { get; }
        
    }
}
