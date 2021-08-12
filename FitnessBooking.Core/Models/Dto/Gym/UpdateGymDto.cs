using FitnessBooking.Core.Models.Dto.Section;
using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Dto.Gym
{
    public class UpdateGymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}