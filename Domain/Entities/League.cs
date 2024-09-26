using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<SeasonLeague> SeasonLeagues { get; }
    }
}