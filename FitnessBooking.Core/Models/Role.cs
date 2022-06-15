using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.Core.Models
{
    public class Role
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
    }
}