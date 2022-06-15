using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.Core.Models
{
    public class Administrator
    {
        [Key] public int Id { get; set; }

        public int UserId { get; set; }
        public int GymId { get; set; }
    }
}