using FitnessBooking.Core.Enums;

namespace FitnessBooking.Core.Models.Dto.User
{
    public class AuthenticateUserDto
    {
        public AuthenticateUserDto(Models.User user) : this(user.Id, user.Email, user.Name, user.Password,
            (Roles) user.RoleId)
        {
        }

        public AuthenticateUserDto(int id, string email, string name, string password, Roles roles)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
            Role = roles;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}