namespace Orama_API.Model.Domain
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }

        public ICollection<Users> Users { get; set; } = new List<Users>();

    }
}