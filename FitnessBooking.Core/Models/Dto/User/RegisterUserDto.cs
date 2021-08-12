namespace FitnessBooking.Core.Models.Dto.User
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public int RoleId { get; set; }
    }
}