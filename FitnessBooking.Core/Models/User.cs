using System.ComponentModel.DataAnnotations;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }

        public bool IsAppreciateToRequest(GetUserRequest request)
        {
            return Id == request.Id &&
                   (request.Email?.Equals(Email) ?? true) &&
                   (request.Name?.Equals(Name) ?? true) &&
                   request.RoleId == RoleId;
        }
    }
}