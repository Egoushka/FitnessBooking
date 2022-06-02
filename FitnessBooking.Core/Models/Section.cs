using System;
using System.Collections.Generic;
using System.Linq;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
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

        public bool Equals(GetSectionRequest other)
        {
            return Id == other.Id 
                   && Name == other.Name 
                   && TypeId == other.TypeId 
                   && GymId == other.GymId 
                   && Coaches.All(section => section.Id.Equals(other.CoachId));;
        }

        private bool Equals(Section other)
        {
            return Id == other.Id && Name == other.Name && TypeId == other.TypeId && GymId == other.GymId;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Section) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, TypeId, GymId);
        }
    }
}