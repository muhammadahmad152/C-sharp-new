using Ahmad_MVC.Models.Enum;

namespace Ahmad_MVC.Models.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Role Userrole { get; set; } = Role.none;
    }
}