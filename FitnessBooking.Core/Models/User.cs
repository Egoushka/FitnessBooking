namespace FitnessBooking.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
    }
}