using System.Collections.Generic;

namespace FitnessBooking.Core.Models.Infrastructure
{
    public class Section
    {
        public Section()
        {
            Coaches = new HashSet<Coach>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int GymId { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
    }
}