using System;
using System.ComponentModel.DataAnnotations;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Models
{
    public class Coach
    {
        [Key] public int Id { get; set; }

        public int SectionId { get; set; }
        public int UserId { get; set; }

        public bool IsAppreciateToRequest(GetCoachRequest other)
        {
            return other.SectionId == null || SectionId == other.SectionId;
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

            return obj.GetType() == GetType() && Equals((Coach) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, SectionId, UserId);
        }
    }
}