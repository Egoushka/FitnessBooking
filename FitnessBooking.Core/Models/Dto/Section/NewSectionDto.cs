using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Dto.Section
{
    public class NewSectionDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int GymId { get; set; }
    }
}