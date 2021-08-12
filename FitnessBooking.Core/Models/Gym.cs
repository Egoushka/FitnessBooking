using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Infrastructure
{
    public class Gym
    {
        public Gym()
        {
            Sections = new HashSet<Section>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}