using System;
using System.Collections.Generic;
using System.Linq;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class Gym
    {
        public Gym()
        {
            Sections = new HashSet<Section>();
        }
        public int Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public bool Equals(GetGymRequest other)
        {
            return Name == other.Name 
                   && Location == other.Location 
                   && Sections.All(section => section.Equals(other.SectionRequest));
        }
        protected bool Equals(Gym other)
        {
            return Id == other.Id 
                   && Name == other.Name 
                   && Location == other.Location 
                   && Description == other.Description 
                   && Equals(Sections, other.Sections);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Gym) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Location, Description, Sections);
        }
    }
}