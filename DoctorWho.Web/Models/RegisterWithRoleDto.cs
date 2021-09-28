using DoctorWho.Db.Authentication;

namespace DoctorWho.Web.Models
{
    public class RegisterWithRoleDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}