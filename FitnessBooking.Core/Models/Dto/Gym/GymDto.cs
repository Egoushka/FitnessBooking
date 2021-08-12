using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBooking.Core.Models.Dto.Gym
{
    public class GymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<Infrastructure.Section> Sections { get; set; }
    }
}
