namespace Domain.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }  
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}