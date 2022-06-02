using System;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int UserId { get; set; }
        public bool Equals(GetCoachRequest other)
        {
            return SectionId == other.SectionId;
        }
        protected bool Equals(Coach other)
        {
            return Id == other.Id 
                   && SectionId == other.SectionId 
                   && UserId == other.UserId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coach) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, SectionId, UserId);
        }
    }
}