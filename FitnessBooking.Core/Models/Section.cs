using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        public int GymId { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }

        public bool IsAppreciateToRequest(GetSectionRequest other)
        {
            return (other.Id == null || Id == other.Id)
                   && (string.IsNullOrEmpty(other.Name) || Name == other.Name)
                   && (other.TypeId == null || TypeId == other.TypeId)
                   && (other.GymId == null || GymId == other.GymId)
                   && (other.CoachId == null || Coaches.All(section => section.Id.Equals(other.CoachId)));
        }

        private bool Equals(Section other)
        {
            return Id == other.Id && Name == other.Name && TypeId == other.TypeId && GymId == other.GymId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Section) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, TypeId, GymId);
        }
    }
}