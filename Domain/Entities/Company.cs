using System.Collections.Generic;

namespace Domain.Entites
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<League> Leagues { get; set; }
    }
}